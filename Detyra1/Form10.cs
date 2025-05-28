using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Detyra1
{
    public partial class Form10 : Form
    {
        string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";

        public Form10()
        {
            InitializeComponent();
            LoadBuzekuq();
        }

        public void LoadBuzekuq()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, emriFurnitorit AS 'Emri Furnitorit', emriBuzekuqit AS 'Emri Buzekuqit', " +
                               "nuanca AS 'Nuanca', sasia AS 'Sasia', cmimiBlerjes AS 'Cmimi Blerjes', " +
                               "cmimiShitjes AS 'Cmimi Shitjes', totali AS 'Totali' FROM buzekuq";
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
            Form9 form9 = new Form9(this);
            form9.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string emriFurnitorit = selectedRow.Cells["Emri Furnitorit"].Value.ToString();
                string emriBuzekuqit = selectedRow.Cells["Emri Buzekuqit"].Value.ToString();
                string nuanca = selectedRow.Cells["Nuanca"].Value.ToString();
                string sasia = selectedRow.Cells["Sasia"].Value.ToString();
                string cmimiBlerjes = selectedRow.Cells["Cmimi Blerjes"].Value.ToString();
                string cmimiShitjes = selectedRow.Cells["Cmimi Shitjes"].Value.ToString();
                string totali = selectedRow.Cells["Totali"].ToString();

                Form9 form9 = new Form9(this, id, emriFurnitorit, emriBuzekuqit, nuanca, sasia, cmimiBlerjes, cmimiShitjes, totali, true);
                form9.ShowDialog();
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
                DialogResult result = MessageBox.Show("A jeni i sigurt që dëshironi të fshini këtë produkt?", "Konfirmo Fshirjen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        string query = "DELETE FROM buzekuq WHERE id=@id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    LoadBuzekuq();
                }
            }
            else
            {
                MessageBox.Show("Zgjedh një rresht për ta fshirë.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"SELECT id,
                                emriFurnitorit AS 'Emri Furnitorit',
                                emriBuzekuqit AS 'Emri Buzekuqit',
                                nuanca AS 'Nuanca',
                                sasia AS 'Sasia',
                                cmimiBlerjes AS 'Cmimi Blerjes',
                                cmimiShitjes AS 'Cmimi Shitjes',
                                totali AS 'Totali'
                         FROM buzekuq
                         WHERE emriBuzekuqit LIKE @search";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + textBox1.Text + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                dataGridView1.AllowUserToAddRows = false;
            }
        }

    }
}
