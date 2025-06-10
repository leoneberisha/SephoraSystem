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
            textBox9.Text = aktiv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = @"INSERT INTO fondatine
                            (emri_furnitorit, emri_fondatines, nuanca, stoku, sasia, cmimiBlerjes, cmimiShitjes, totali, aktiv)
                             VALUES 
                            (@emri_furnitorit, @emri_fondatines, @nuanca, @stoku, @sasia, @cmimiBlerjes, @cmimiShitjes, @totali, @aktiv)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    int sasia = int.Parse(textBox5.Text);
                    decimal cmimiShitjes = decimal.Parse(textBox7.Text);
                    decimal totali = sasia * cmimiShitjes;

                    cmd.Parameters.AddWithValue("@emri_furnitorit", textBox1.Text);
                    cmd.Parameters.AddWithValue("@emri_fondatines", textBox2.Text);
                    cmd.Parameters.AddWithValue("@nuanca", textBox3.Text);
                    cmd.Parameters.AddWithValue("@stoku", textBox4.Text);
                    cmd.Parameters.AddWithValue("@sasia", sasia);
                    cmd.Parameters.AddWithValue("@cmimiBlerjes", textBox6.Text);
                    cmd.Parameters.AddWithValue("@cmimiShitjes", cmimiShitjes);
                    cmd.Parameters.AddWithValue("@totali", totali);
                    cmd.Parameters.AddWithValue("@aktiv", textBox9.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                form6Reference?.LoadFondatine();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gabim: " + ex.Message);
            }
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
            textBox9.Clear();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            LlogaritTotalin();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            LlogaritTotalin();
        }

        private void LlogaritTotalin()
        {
            if (int.TryParse(textBox5.Text.Trim(), out int sasia) &&
                decimal.TryParse(textBox7.Text.Trim(), out decimal cmimiShitjes))
            {
                decimal totali = sasia * cmimiShitjes;
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!isEditMode)
            {
                MessageBox.Show("Nuk jeni në mënyrën e përditësimit.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = @"UPDATE fondatine SET 
                                emri_furnitorit = @furnitor,
                                emri_fondatines = @emri,
                                nuanca = @nuanca,
                                stoku = @stoku,
                                sasia = @sasia,
                                cmimiBlerjes = @blerja,
                                cmimiShitjes = @shitja,
                                totali = @totali,
                                aktiv = @aktiv
                             WHERE id = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    int sasia = int.Parse(textBox5.Text);
                    decimal cmimiShitjes = decimal.Parse(textBox7.Text);
                    decimal totali = sasia * cmimiShitjes;

                    cmd.Parameters.AddWithValue("@id", editingId);
                    cmd.Parameters.AddWithValue("@furnitor", textBox1.Text);
                    cmd.Parameters.AddWithValue("@emri", textBox2.Text);
                    cmd.Parameters.AddWithValue("@nuanca", textBox3.Text);
                    cmd.Parameters.AddWithValue("@stoku", textBox4.Text);
                    cmd.Parameters.AddWithValue("@sasia", sasia);
                    cmd.Parameters.AddWithValue("@blerja", textBox6.Text);
                    cmd.Parameters.AddWithValue("@shitja", cmimiShitjes);
                    cmd.Parameters.AddWithValue("@totali", totali);
                    cmd.Parameters.AddWithValue("@aktiv", textBox9.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                form6Reference?.LoadFondatine();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gabim gjatë përditësimit:\n" + ex.Message);
            }
        }
    }
}
