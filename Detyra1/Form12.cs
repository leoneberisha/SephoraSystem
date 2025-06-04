using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Detyra1
{
    public partial class Form12 : Form
    {
        private string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";

        public Form12()
        {
            InitializeComponent();
            LoadBlush();
        }

        public void LoadBlush()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"SELECT id, emri_furnitorit AS 'Furnitori', emriBlush AS 'Produkti',
                                nuanca AS 'Nuanca', cmimiBlerjes AS 'Blerja', cmimiShitjes AS 'Shitja',
                                sasia AS 'Sasia', stoku AS 'Stoku'
                                FROM blush";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                dataGridView1.AllowUserToAddRows = false;
            }
        }

        private void button1_Click(object sender, EventArgs e) => this.Close();

        private void button2_Click(object sender, EventArgs e) // Kërko
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"SELECT id, emri_furnitorit AS 'Furnitori', emriBlush AS 'Produkti',
                                nuanca AS 'Nuanca', cmimiBlerjes AS 'Blerja', cmimiShitjes AS 'Shitja',
                                sasia AS 'Sasia', stoku AS 'Stoku'
                                FROM blush
                                WHERE emriBlush LIKE @search";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + textBox1.Text + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                dataGridView1.AllowUserToAddRows = false;
            }
        }

        private void button3_Click(object sender, EventArgs e) // Shto
        {
            Form11 form11 = new Form11(this);
            form11.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e) // Edito
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["id"].Value);
                string emriFurnitorit = row.Cells["Furnitori"].Value.ToString();
                string emriBlush = row.Cells["Produkti"].Value.ToString();
                string nuanca = row.Cells["Nuanca"].Value.ToString();
                string cmimiBlerjes = row.Cells["Blerja"].Value.ToString();
                string cmimiShitjes = row.Cells["Shitja"].Value.ToString();
                string sasia = row.Cells["Sasia"].Value.ToString();
                string stoku = row.Cells["Stoku"].Value.ToString();

                Form11 form11 = new Form11(this, id, emriFurnitorit, emriBlush, nuanca,
                                           cmimiBlerjes, cmimiShitjes, sasia, stoku,true);
                form11.ShowDialog();
            }
            else
            {
                MessageBox.Show("Zgjedh një rresht për të edituar.");
            }
        }

        private void button5_Click(object sender, EventArgs e) // Fshij
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("A jeni i sigurt që dëshironi të fshini këtë blush?", "Konfirmo Fshirjen", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        string query = "DELETE FROM blush WHERE id=@id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    LoadBlush();
                }
            }
            else
            {
                MessageBox.Show("Zgjedh një rresht për të fshirë.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
