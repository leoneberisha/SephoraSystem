using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Detyra1
{
    public partial class Form15 : Form
    {
        private Form16 form16Reference;
        private int editingId;
        private bool isEditMode = false;

        public Form15(Form16 form)
        {
            InitializeComponent();
            form16Reference = form;
        }

        public Form15(Form16 form, int id, string emri, string mbiemri, string produkti,
                      string sasia, string cmimi, string statusi)
        {
            InitializeComponent();
            form16Reference = form;
            editingId = id;
            isEditMode = true;

            textBox1.Text = emri;
            textBox2.Text = mbiemri;
            textBox3.Text = produkti;
            textBox4.Text = sasia;
            textBox5.Text = cmimi;

            if (statusi == "Pending") radioButton1.Checked = true;
            else if (statusi == "Shipped") radioButton2.Checked = true;
            else if (statusi == "Delivered") radioButton3.Checked = true;
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
            radioButton1.Checked = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string emri = textBox1.Text.Trim();
            string mbiemri = textBox2.Text.Trim();
            string produkti = textBox3.Text.Trim();

            if (!int.TryParse(textBox4.Text.Trim(), out int sasia) ||
                !decimal.TryParse(textBox5.Text.Trim(), out decimal cmimi))
            {
                MessageBox.Show("Shkruaj sasi dhe çmim valid.");
                return;
            }

            string statusi = "";
            if (radioButton1.Checked) statusi = "Pending";
            else if (radioButton2.Checked) statusi = "Shipped";
            else if (radioButton3.Checked) statusi = "Delivered";

            decimal totali = sasia * cmimi;
            string nrFatures = "FA" + DateTime.Now.ToString("yyyyMMddHHmmss");

            using (MySqlConnection conn = new MySqlConnection("server=localhost;database=sephorasistem;uid=root;pwd=;"))
            {
                conn.Open();

                string query = @"INSERT INTO porosit (emri_klientit, mbiemri_klientit, produkti,
                          sasia, cmimi, statusi, totali, nr_fatures)
                         VALUES (@emri, @mbiemri, @produkti, @sasia, @cmimi, @statusi, @totali, @nrFatures)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@emri", emri);
                cmd.Parameters.AddWithValue("@mbiemri", mbiemri);
                cmd.Parameters.AddWithValue("@produkti", produkti);
                cmd.Parameters.AddWithValue("@sasia", sasia);
                cmd.Parameters.AddWithValue("@cmimi", cmimi);
                cmd.Parameters.AddWithValue("@statusi", statusi);
                cmd.Parameters.AddWithValue("@totali", totali);
                cmd.Parameters.AddWithValue("@nrFatures", nrFatures);

                cmd.ExecuteNonQuery();

                long insertedId = cmd.LastInsertedId;

                string emriKlientit = emri + " " + mbiemri;
                Form19 fatura = new Form19((int)insertedId, emriKlientit);
                fatura.Show();

                conn.Close();
            }

            form16Reference?.GetType().GetMethod("LoadPorosite")?.Invoke(form16Reference, null);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection("server=localhost;database=sephorasistem;uid=root;pwd=;"))
            {
                conn.Open();
                MySqlCommand cmd;

                decimal sasia = decimal.Parse(textBox4.Text);
                decimal cmimi = decimal.Parse(textBox5.Text);
                decimal totali = sasia * cmimi;
                string statusi = radioButton1.Checked ? "Pending" :
                                 radioButton2.Checked ? "Shipped" :
                                 radioButton3.Checked ? "Delivered" : "";

                string nrFatures = "FA" + DateTime.Now.ToString("yyyyMMddHHmmss");

                if (isEditMode)
                {
                    string updateQuery = @"UPDATE porosit SET 
                                      emri_klientit = @emri,
                                      mbiemri_klientit = @mbiemri,
                                      produkti = @produkti,
                                      sasia = @sasia,
                                      cmimi = @cmimi,
                                      statusi = @statusi,
                                      totali = @totali
                                   WHERE id = @id";

                    cmd = new MySqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@id", editingId);
                }
                else
                {
                    string insertQuery = @"INSERT INTO porosit
                                   (emri_klientit, mbiemri_klientit, produkti, sasia, cmimi, statusi, totali, nr_fatures)
                                   VALUES (@emri, @mbiemri, @produkti, @sasia, @cmimi, @statusi, @totali, @nrFatures)";
                    cmd = new MySqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@nrFatures", nrFatures);
                }

                cmd.Parameters.AddWithValue("@emri", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@mbiemri", textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@produkti", textBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@sasia", sasia);
                cmd.Parameters.AddWithValue("@cmimi", cmimi);
                cmd.Parameters.AddWithValue("@statusi", statusi);
                cmd.Parameters.AddWithValue("@totali", totali);

                cmd.ExecuteNonQuery();
                conn.Close();
            }

            form16Reference?.GetType().GetMethod("LoadPorosite")?.Invoke(form16Reference, null);
            this.Close();
        }
    }
}
