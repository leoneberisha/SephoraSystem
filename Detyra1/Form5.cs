using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Detyra1
{
    public partial class Form5 : Form
    {
        string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";
        private Form6 form6Reference;
        private bool isEditMode = false;
        private int editingId;

        public Form5()
        {
            InitializeComponent();
        }

        public Form5(Form6 form6)
        {
            InitializeComponent();
            form6Reference = form6;
        }

        public Form5(Form6 form6, int id, string emri_furnitorit, string emri_fondatines, string nuanca, string stoku, string sasia, string cmimiBlerjes, string cmimiShitjes, string totali, string aktiv, bool isEdit)
        {
            InitializeComponent();
            form6Reference = form6;
            isEditMode = isEdit;
            editingId = id;

            textBox1.Text = emri_furnitorit;
            textBox2.Text = emri_fondatines;
            textBox3.Text = nuanca;
            textBox4.Text = stoku;
            textBox5.Text = sasia;
            textBox6.Text = cmimiBlerjes;
            textBox7.Text = cmimiShitjes;
            textBox8.Text = totali;
            textBox9.Text = aktiv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO fondatine(emri_furnitorit, emri_fondatines, nuanca, stoku, sasia, cmimiBlerjes, cmimiShitjes, totali, aktiv) " +
                               "VALUES (@emri_furnitorit, @emri_fondatines, @nuanca, @stoku, @sasia, @cmimiBlerjes, @cmimiShitjes, @totali, @aktiv)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@emri_furnitorit", textBox1.Text);
                cmd.Parameters.AddWithValue("@emri_fondatines", textBox2.Text);
                cmd.Parameters.AddWithValue("@nuanca", textBox3.Text);
                cmd.Parameters.AddWithValue("@stoku", textBox4.Text);
                cmd.Parameters.AddWithValue("@sasia", textBox5.Text);
                cmd.Parameters.AddWithValue("@cmimiBlerjes", textBox6.Text);
                cmd.Parameters.AddWithValue("@cmimiShitjes", textBox7.Text);
                cmd.Parameters.AddWithValue("@totali", textBox8.Text);
                cmd.Parameters.AddWithValue("@aktiv", textBox9.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            form6Reference.LoadFondatine();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd;

                if (isEditMode)
                {
                    string updateQuery = "UPDATE fondatine SET emri_furnitorit=@emri_furnitorit, emri_fondatines=@emri_fondatines, nuanca=@nuanca, stoku=@stoku, sasia=@sasia, cmimiBlerjes=@cmimiBlerjes, cmimiShitjes=@cmimiShitjes, totali=@totali, aktiv=@aktiv WHERE id=@id";
                    cmd = new MySqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@id", editingId);
                }
                else
                {
                    string insertQuery = "INSERT INTO fondatine(emri_furnitorit, emri_fondatines, nuanca, stoku, sasia, cmimiBlerjes, cmimiShitjes, totali, aktiv) " +
                                         "VALUES (@emri_furnitorit, @emri_fondatines, @nuanca, @stoku, @sasia, @cmimiBlerjes, @cmimiShitjes, @totali, @aktiv)";
                    cmd = new MySqlCommand(insertQuery, conn);
                }

                cmd.Parameters.AddWithValue("@emri_furnitorit", textBox1.Text);
                cmd.Parameters.AddWithValue("@emri_fondatines", textBox2.Text);
                cmd.Parameters.AddWithValue("@nuanca", textBox3.Text);
                cmd.Parameters.AddWithValue("@stoku", textBox4.Text);
                cmd.Parameters.AddWithValue("@sasia", textBox5.Text);
                cmd.Parameters.AddWithValue("@cmimiBlerjes", textBox6.Text);
                cmd.Parameters.AddWithValue("@cmimiShitjes", textBox7.Text);
                cmd.Parameters.AddWithValue("@totali", textBox8.Text);
                cmd.Parameters.AddWithValue("@aktiv", textBox9.Text);

                cmd.ExecuteNonQuery();
                conn.Close();
            }

            form6Reference.LoadFondatine();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }
    }
}
