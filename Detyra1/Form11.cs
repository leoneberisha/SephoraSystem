using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Detyra1
{
    public partial class Form11 : Form
    {
        private string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";
        private bool isEditMode = false;
        private int editingId;
        private Form12 form12Reference;

        public Form11()
        {
            InitializeComponent();
        }

        public Form11(Form12 form12)
        {
            InitializeComponent();
            form12Reference = form12;
        }

        public Form11(Form12 form12, int id, string emriFurnitorit, string emriBlush, string nuanca,
                      string sasia, string cmimiBlerjes, string cmimiShitjes, string stoku, bool isEdit)
        {
            InitializeComponent();
            form12Reference = form12;
            isEditMode = isEdit;
            editingId = id;

            textBox1.Text = emriFurnitorit;
            textBox2.Text = emriBlush;
            textBox3.Text = nuanca;
            textBox4.Text = sasia;
            textBox5.Text = cmimiBlerjes;
            textBox6.Text = cmimiShitjes;
            textBox7.Text = stoku;
        }

        private void button1_Click(object sender, EventArgs e)
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
            textBox7.Clear();
        }

        private void button2_Click(object sender, EventArgs e) // Shto ose Përditëso
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                decimal sasia = decimal.Parse(textBox4.Text);
                decimal cmimiShitjes = decimal.Parse(textBox6.Text);
                decimal totali = sasia * cmimiShitjes;

                conn.Open();
                MySqlCommand cmd;

                if (isEditMode)
                {
                    string updateQuery = @"UPDATE blush SET 
                                            emri_furnitorit=@emri_furnitorit,
                                            emriBlush=@emriBlush,
                                            nuanca=@nuanca,
                                            sasia=@sasia,
                                            cmimiBlerjes=@cmimiBlerjes,
                                            cmimiShitjes=@cmimiShitjes,
                                            stoku=@stoku,
                                            totali=@totali
                                            WHERE id=@id";
                    cmd = new MySqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@id", editingId);
                }
                else
                {
                    string insertQuery = @"INSERT INTO blush(emri_furnitorit, emriBlush, nuanca, sasia, cmimiBlerjes, cmimiShitjes, stoku, totali)
                                           VALUES (@emri_furnitorit, @emriBlush, @nuanca, @sasia, @cmimiBlerjes, @cmimiShitjes, @stoku, @totali)";
                    cmd = new MySqlCommand(insertQuery, conn);
                }

                cmd.Parameters.AddWithValue("@emri_furnitorit", textBox1.Text);
                cmd.Parameters.AddWithValue("@emriBlush", textBox2.Text);
                cmd.Parameters.AddWithValue("@nuanca", textBox3.Text);
                cmd.Parameters.AddWithValue("@sasia", sasia);
                cmd.Parameters.AddWithValue("@cmimiBlerjes", textBox5.Text);
                cmd.Parameters.AddWithValue("@cmimiShitjes", cmimiShitjes);
                cmd.Parameters.AddWithValue("@stoku", textBox7.Text);
                cmd.Parameters.AddWithValue("@totali", totali);

                cmd.ExecuteNonQuery();
                conn.Close();
            }

            form12Reference.LoadBlush();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                decimal sasia = decimal.Parse(textBox4.Text);
                decimal cmimiShitjes = decimal.Parse(textBox6.Text);
                decimal totali = sasia * cmimiShitjes;

                conn.Open();
                MySqlCommand cmd;

                if (isEditMode)
                {
                    string updateQuery = @"UPDATE blush SET 
                                    emri_furnitorit=@emri_furnitorit,
                                    emriBlush=@emriBlush,
                                    nuanca=@nuanca,
                                    sasia=@sasia,
                                    cmimiBlerjes=@cmimiBlerjes,
                                    cmimiShitjes=@cmimiShitjes,
                                    stoku=@stoku,
                                    totali=@totali
                                    WHERE id=@id";
                    cmd = new MySqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@id", editingId);
                }
                else
                {
                    string insertQuery = @"INSERT INTO blush(emri_furnitorit, emriBlush, nuanca, sasia, cmimiBlerjes, cmimiShitjes, stoku, totali)
                                   VALUES (@emri_furnitorit, @emriBlush, @nuanca, @sasia, @cmimiBlerjes, @cmimiShitjes, @stoku, @totali)";
                    cmd = new MySqlCommand(insertQuery, conn);
                }

                cmd.Parameters.AddWithValue("@emri_furnitorit", textBox1.Text);
                cmd.Parameters.AddWithValue("@emriBlush", textBox2.Text);
                cmd.Parameters.AddWithValue("@nuanca", textBox3.Text);
                cmd.Parameters.AddWithValue("@sasia", sasia);
                cmd.Parameters.AddWithValue("@cmimiBlerjes", textBox5.Text);
                cmd.Parameters.AddWithValue("@cmimiShitjes", cmimiShitjes);
                cmd.Parameters.AddWithValue("@stoku", textBox7.Text);
                cmd.Parameters.AddWithValue("@totali", totali);

                cmd.ExecuteNonQuery();
                conn.Close();
            }

            form12Reference.LoadBlush();
            this.Close();
        }

    }
}

