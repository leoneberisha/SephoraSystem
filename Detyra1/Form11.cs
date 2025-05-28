using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Detyra1
{
    public partial class Form11 : Form
    {
        private Form12 form12Reference;
        private int editingId = -1;
        private bool isEditMode = false;
        private string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";

        // Konstruktori për shtim
        public Form11(Form12 form12)
        {
            InitializeComponent();
            form12Reference = form12;
        }

        // Konstruktori për editim
        public Form11(Form12 form12, int id, string emriFurnitorit, string emriBlush, string nuanca,
                      string cmimiBlerjes, string cmimiShitjes, string sasia, string stoku)
        {
            InitializeComponent();
            form12Reference = form12;
            editingId = id;
            isEditMode = true;

            textBox1.Text = emriFurnitorit;
            textBox2.Text = emriBlush;
            textBox3.Text = nuanca;
            textBox4.Text = cmimiBlerjes;
            textBox5.Text = cmimiShitjes;
            textBox6.Text = sasia;
            textBox7.Text = stoku;
        }

        private void button2_Click(object sender, EventArgs e) => this.Close();

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();
            textBox5.Clear(); textBox6.Clear(); textBox7.Clear();
        }

        private void button4_Click(object sender, EventArgs e) // Shto
        {
            if (!decimal.TryParse(textBox5.Text, out decimal cmimiShitjes) ||
                !decimal.TryParse(textBox6.Text, out decimal sasia))
            {
                MessageBox.Show("Shkruaj sasi dhe çmim shitje valid.");
                return;
            }

            decimal totali = sasia * cmimiShitjes;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"INSERT INTO blush(emri_furnitorit, emriBlush, nuanca, cmimiBlerjes, cmimiShitjes, sasia, stoku, totali)
                                 VALUES(@emri_furnitorit, @emriBlush, @nuanca, @cmimiBlerjes, @cmimiShitjes, @sasia, @stoku, @totali)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@emri_furnitorit", textBox1.Text);
                cmd.Parameters.AddWithValue("@emriBlush", textBox2.Text);
                cmd.Parameters.AddWithValue("@nuanca", textBox3.Text);
                cmd.Parameters.AddWithValue("@cmimiBlerjes", textBox4.Text);
                cmd.Parameters.AddWithValue("@cmimiShitjes", cmimiShitjes);
                cmd.Parameters.AddWithValue("@sasia", sasia);
                cmd.Parameters.AddWithValue("@stoku", textBox7.Text);
                cmd.Parameters.AddWithValue("@totali", totali);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            MessageBox.Show("Blushi u shtua me sukses.");
            form12Reference.LoadBlush();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) // Përditëso
        {
            if (!decimal.TryParse(textBox5.Text, out decimal cmimiShitjes) ||
                !decimal.TryParse(textBox6.Text, out decimal sasia))
            {
                MessageBox.Show("Shkruaj sasi dhe çmim shitje valid.");
                return;
            }

            decimal totali = sasia * cmimiShitjes;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"UPDATE blush SET
                                 emri_furnitorit=@emri_furnitorit,
                                 emriBlush=@emriBlush,
                                 nuanca=@nuanca,
                                 cmimiBlerjes=@cmimiBlerjes,
                                 cmimiShitjes=@cmimiShitjes,
                                 sasia=@sasia,
                                 stoku=@stoku,
                                 totali=@totali
                                 WHERE id=@id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@emri_furnitorit", textBox1.Text);
                cmd.Parameters.AddWithValue("@emriBlush", textBox2.Text);
                cmd.Parameters.AddWithValue("@nuanca", textBox3.Text);
                cmd.Parameters.AddWithValue("@cmimiBlerjes", textBox4.Text);
                cmd.Parameters.AddWithValue("@cmimiShitjes", cmimiShitjes);
                cmd.Parameters.AddWithValue("@sasia", sasia);
                cmd.Parameters.AddWithValue("@stoku", textBox7.Text);
                cmd.Parameters.AddWithValue("@totali", totali);
                cmd.Parameters.AddWithValue("@id", editingId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            MessageBox.Show("Blushi u përditësua me sukses.");
            form12Reference.LoadBlush();
            this.Close();
        }
    }
}
