using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Detyra1
{
    public partial class Form6 : Form
    {
        string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";

        public Form6()
        {
            InitializeComponent();
            LoadFondatine();
        }

        public void LoadFondatine()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, emri_furnitorit AS 'Furnitori', emri_fondatines AS 'Produkti', nuanca AS 'Nuanca', stoku AS 'Stoku', sasia AS 'Sasia', cmimiBlerjes AS 'Blerja', cmimiShitjes AS 'Shitja', totali AS 'Totali', aktiv AS 'Statusi' FROM fondatine";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(this);
            form5.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"SELECT id, emri_furnitorit AS 'Furnitori', emri_fondatines AS 'Produkti', nuanca AS 'Nuanca', stoku AS 'Stoku', sasia AS 'Sasia', cmimiBlerjes AS 'Blerja', cmimiShitjes AS 'Shitja', totali AS 'Totali', aktiv AS 'Statusi' FROM fondatine WHERE emri_fondatines LIKE @search";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + textBox1.Text + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string emri_furnitorit = selectedRow.Cells["Furnitori"].Value.ToString();
                string emri_fondatines = selectedRow.Cells["Produkti"].Value.ToString();
                string nuanca = selectedRow.Cells["Nuanca"].Value.ToString();
                string stoku = selectedRow.Cells["Stoku"].Value.ToString();
                string sasia = selectedRow.Cells["Sasia"].Value.ToString();
                string cmimiBlerjes = selectedRow.Cells["Blerja"].Value.ToString();
                string cmimiShitjes = selectedRow.Cells["Shitja"].Value.ToString();
                string totali = selectedRow.Cells["Totali"].Value.ToString();
                string aktiv = selectedRow.Cells["Statusi"].Value.ToString();

                Form5 form5 = new Form5(this, id, emri_furnitorit, emri_fondatines, nuanca, stoku, sasia, cmimiBlerjes, cmimiShitjes, totali, aktiv, true);
                form5.ShowDialog();
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
                DialogResult result = MessageBox.Show("A jeni i sigurt që dëshironi të fshini këtë fondatine?", "Konfirmo Fshirjen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        string query = "DELETE FROM fondatine WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    LoadFondatine();
                }
            }
            else
            {
                MessageBox.Show("Zgjedh një rresht që dëshiron ta fshish.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
