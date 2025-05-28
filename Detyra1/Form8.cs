using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Detyra1
{
    public partial class Form8 : Form
    {
        string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";

        public Form8()
        {
            InitializeComponent();
            LoadMaskara();
        }

        public void LoadMaskara()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, emriFurnitorit AS 'Furnitori', emriMaskares AS 'Maskara', sasia AS 'Sasia', cmimiBlerjes AS 'Blerja', cmimiShitjes AS 'Shitja', totali AS 'Totali', aktiv AS 'Aktiv' FROM maskara";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                dataGridView1.AllowUserToAddRows = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7(this);
            form7.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string emriFurnitorit = selectedRow.Cells["Furnitori"].Value.ToString();
                string emriMaskares = selectedRow.Cells["Maskara"].Value.ToString();
                string sasia = selectedRow.Cells["Sasia"].Value.ToString();
                string cmimiBlerjes = selectedRow.Cells["Blerja"].Value.ToString();
                string cmimiShitjes = selectedRow.Cells["Shitja"].Value.ToString();
                string totali = selectedRow.Cells["Totali"].Value.ToString();
                string aktiv = selectedRow.Cells["Aktiv"].Value.ToString();

                Form7 form7 = new Form7(this, id, emriFurnitorit, emriMaskares, sasia, cmimiBlerjes, cmimiShitjes, aktiv, totali, true);
                form7.ShowDialog();
            }
            else
            {
                MessageBox.Show("Zgjedh një rresht për të edituar.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("A jeni i sigurt që dëshironi të fshini këtë maskarë?", "Konfirmo Fshirjen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        string query = "DELETE FROM maskara WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    LoadMaskara();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"SELECT id,
                        emriFurnitorit AS 'Furnitori',
                        emriMaskares AS 'Maskara',
                        sasia AS 'Sasia',
                        cmimiBlerjes AS 'Blerja',
                        cmimiShitjes AS 'Shitja',
                        totali AS 'Totali',
                        aktiv AS 'Statusi'
                FROM maskara
                WHERE emriMaskares LIKE @search";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + textBox1.Text + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
                dataGridView1.AllowUserToAddRows = false; // ⛔ mos shto rresht të zbrazët
            }
        }

    }
}

