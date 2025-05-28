using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Detyra1
{
    public partial class Form9 : Form
    {
        string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";
        private bool isEditMode = false;
        private int editingId;
        private Form10 Form10Reference;

        public Form9()
        {
            InitializeComponent();
        }

        public Form9(Form10 form10)
        {
            InitializeComponent();
            Form10Reference = form10;
        }

        public Form9(Form10 form10, int id, string emriFurnitorit, string emriBuzekuqit, string nuanca,
                     string sasia, string cmimiBlerjes, string cmimiShitjes, string totali, bool isEdit)
        {
            InitializeComponent();
            Form10Reference = form10;
            isEditMode = isEdit;
            editingId = id;

            textBox1.Text = emriFurnitorit;
            textBox2.Text = emriBuzekuqit;
            textBox3.Text = nuanca;
            textBox4.Text = sasia;
            textBox5.Text = cmimiBlerjes;
            textBox6.Text = cmimiShitjes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                decimal sasia = decimal.Parse(textBox4.Text);
                decimal cmimiShitjes = decimal.Parse(textBox6.Text);
                decimal totali = sasia * cmimiShitjes;

                string query = "INSERT INTO buzekuq(emriFurnitorit, emriBuzekuqit, nuanca, sasia, cmimiBlerjes, cmimiShitjes, totali) " +
                               "VALUES (@emriFurnitorit, @emriBuzekuqit, @nuanca, @sasia, @cmimiBlerjes, @cmimiShitjes, @totali)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@emriFurnitorit", textBox1.Text);
                cmd.Parameters.AddWithValue("@emriBuzekuqit", textBox2.Text);
                cmd.Parameters.AddWithValue("@nuanca", textBox3.Text);
                cmd.Parameters.AddWithValue("@sasia", sasia);
                cmd.Parameters.AddWithValue("@cmimiBlerjes", textBox5.Text);
                cmd.Parameters.AddWithValue("@cmimiShitjes", cmimiShitjes);
                cmd.Parameters.AddWithValue("@totali", totali);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            Form10Reference.LoadBuzekuq();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd;

                decimal sasia = decimal.Parse(textBox4.Text);
                decimal cmimiShitjes = decimal.Parse(textBox6.Text);
                decimal totali = sasia * cmimiShitjes;

                if (isEditMode)
                {
                    string updateQuery = "UPDATE buzekuq SET emriFurnitorit=@emriFurnitorit, emriBuzekuqit=@emriBuzekuqit, nuanca=@nuanca, " +
                                         "sasia=@sasia, cmimiBlerjes=@cmimiBlerjes, cmimiShitjes=@cmimiShitjes, totali=@totali WHERE id=@id";
                    cmd = new MySqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@id", editingId);
                }
                else
                {
                    string insertQuery = "INSERT INTO buzekuq(emriFurnitorit, emriBuzekuqit, nuanca, sasia, cmimiBlerjes, cmimiShitjes, totali) " +
                                         "VALUES (@emriFurnitorit, @emriBuzekuqit, @nuanca, @sasia, @cmimiBlerjes, @cmimiShitjes, @totali)";
                    cmd = new MySqlCommand(insertQuery, conn);
                }

                cmd.Parameters.AddWithValue("@emriFurnitorit", textBox1.Text);
                cmd.Parameters.AddWithValue("@emriBuzekuqit", textBox2.Text);
                cmd.Parameters.AddWithValue("@nuanca", textBox3.Text);
                cmd.Parameters.AddWithValue("@sasia", sasia);
                cmd.Parameters.AddWithValue("@cmimiBlerjes", textBox5.Text);
                cmd.Parameters.AddWithValue("@cmimiShitjes", cmimiShitjes);
                cmd.Parameters.AddWithValue("@totali", totali);

                cmd.ExecuteNonQuery();
                conn.Close();
            }

            Form10Reference.LoadBuzekuq();
            this.Close();
        }
    }
}
