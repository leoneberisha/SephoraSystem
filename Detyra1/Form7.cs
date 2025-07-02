using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Detyra1
{
    public partial class Form7 : Form
    {
        string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";
        private Form8 form8Reference;
        private bool isEditMode = false;
        private int editingId;

        public Form7()
        {
            InitializeComponent();
        }

        public Form7(Form8 form8)
        {
            InitializeComponent();
            form8Reference = form8;
        }

        public Form7(Form8 form8, int id, string emriFurnitorit, string emriMaskares, string sasia, string cmimiBlerjes, string cmimiShitjes, string aktiv, string totali, bool isEdit)
        {
            InitializeComponent();
            form8Reference = form8;
            isEditMode = isEdit;
            editingId = id;

            textBox1.Text = emriFurnitorit;
            textBox2.Text = emriMaskares;
            textBox3.Text = sasia;
            textBox4.Text = cmimiBlerjes;
            textBox5.Text = cmimiShitjes;
            textBox6.Text = aktiv;
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

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd;

                if (isEditMode)
                {
                    string updateQuery = "UPDATE maskara SET emriFurnitorit=@emriFurnitorit, emriMaskares=@emriMaskares, sasia=@sasia, cmimiBlerjes=@cmimiBlerjes, cmimiShitjes=@cmimiShitjes, totali=@totali, aktiv=@aktiv WHERE id=@id";
                    cmd = new MySqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@id", editingId);
                }
                else
                {
                    string insertQuery = "INSERT INTO maskara(emriFurnitorit, emriMaskares, sasia, cmimiBlerjes, cmimiShitjes, totali, aktiv) VALUES(@emriFurnitorit, @emriMaskares, @sasia, @cmimiBlerjes, @cmimiShitjes, @totali, @aktiv)";
                    cmd = new MySqlCommand(insertQuery, conn);
                }

                cmd.Parameters.AddWithValue("@emriFurnitorit", textBox1.Text);
                cmd.Parameters.AddWithValue("@emriMaskares", textBox2.Text);
                cmd.Parameters.AddWithValue("@sasia", textBox3.Text);
                cmd.Parameters.AddWithValue("@cmimiBlerjes", textBox4.Text);
                cmd.Parameters.AddWithValue("@cmimiShitjes", textBox5.Text);
                cmd.Parameters.AddWithValue("@aktiv", textBox6.Text);

                cmd.ExecuteNonQuery();
                conn.Close();
            }

            form8Reference.LoadMaskara();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO maskara(emriFurnitorit, emriMaskares, sasia, cmimiBlerjes, cmimiShitjes, totali, aktiv) " +
                               "VALUES(@emriFurnitorit, @emriMaskares, @sasia, @cmimiBlerjes, @cmimiShitjes, @totali, @aktiv)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@emriFurnitorit", textBox1.Text);
                cmd.Parameters.AddWithValue("@emriMaskares", textBox2.Text);
                cmd.Parameters.AddWithValue("@sasia", textBox3.Text);
                cmd.Parameters.AddWithValue("@cmimiBlerjes", textBox4.Text);
                cmd.Parameters.AddWithValue("@cmimiShitjes", textBox5.Text);
                cmd.Parameters.AddWithValue("@aktiv", textBox6.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            form8Reference.LoadMaskara(); // rifreskon Form8
            this.Close();
        }

    }
}

