using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Detyra1
{
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            LoadPorosite();
        }

        private void LoadPorosite()
        {
            using (MySqlConnection conn = new MySqlConnection("server=localhost;database=sephorasistem;uid=root;pwd=;"))
            {
                string query = @"SELECT id, emri_klientit AS 'Emri', mbiemri_klientit AS 'Mbiemri',
                                produkti AS 'Produkti', sasia AS 'Sasia', cmimi AS 'Çmimi',
                                statusi AS 'Statusi', totali AS 'Totali', data
                                 FROM porosit";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.ReadOnly = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form15 form = new Form15(this);
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                int id = Convert.ToInt32(row.Cells["id"].Value);
                string emri = row.Cells["Emri"].Value.ToString();
                string mbiemri = row.Cells["Mbiemri"].Value.ToString();
                string produkti = row.Cells["Produkti"].Value.ToString();
                string sasia = row.Cells["Sasia"].Value.ToString();
                string cmimi = row.Cells["Çmimi"].Value.ToString();
                string statusi = row.Cells["Statusi"].Value.ToString();

                Form15 form = new Form15(this, id, emri, mbiemri, produkti, sasia, cmimi, statusi);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Zgjedh një rresht për të edituar.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string kerkimi = textBox1.Text.Trim();

            using (MySqlConnection conn = new MySqlConnection("server=localhost;database=sephorasistem;uid=root;pwd=;"))
            {
                string query = @"SELECT id, emri_klientit AS 'Emri', mbiemri_klientit AS 'Mbiemri',
                                produkti AS 'Produkti', sasia AS 'Sasia', cmimi AS 'Çmimi',
                                statusi AS 'Statusi', totali AS 'Totali', data
                         FROM porosit
                         WHERE emri_klientit LIKE @kerko";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kerko", "%" + kerkimi + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.ReadOnly = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "A jeni i sigurt që dëshironi të fshini këtë porosi?",
                    "Konfirmo fshirjen",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                    using (MySqlConnection conn = new MySqlConnection("server=localhost;database=sephorasistem;uid=root;pwd=;"))
                    {
                        string query = "DELETE FROM porosit WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    button2_Click(null, null); // Rifresko me filtrimin ekzistues
                }
            }
            else
            {
                MessageBox.Show("Zgjedh një rresht për të fshirë.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                string emri = dataGridView1.SelectedRows[0].Cells["Emri"].Value.ToString();

                Form19 fatura = new Form19(id, emri);
                fatura.Show();
            }
            else
            {
                MessageBox.Show("Zgjedh një porosi për të gjeneruar faturën.");
            }
        }

    }
}
