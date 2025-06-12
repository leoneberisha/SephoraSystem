using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Detyra1
{
    public partial class Form3 : Form
    {
        string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";

        public Form3()
        {
            InitializeComponent();
            // Ngarko të dhënat kur hapet forma
        }

        public void LoadFurnitore()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, emri as 'Emri Furnitorit', email as 'Email', telefoni as 'Telefon', adresa as 'Adresa' FROM furnitore";
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

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, emri as 'Emri Furnitorit', email as 'Email', telefoni as 'Telefon', adresa as 'Adresa' FROM furnitore WHERE emri LIKE @search";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + textBox1.Text + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                dataGridView1.AllowUserToAddRows = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(this);  // Formë për shtim të furnitorëve
            form4.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string emri = selectedRow.Cells["Emri Furnitorit"].Value.ToString();
                string email = selectedRow.Cells["Email"].Value.ToString();
                string telefoni = selectedRow.Cells["Telefon"].Value.ToString();
                string adresa = selectedRow.Cells["Adresa"].Value.ToString();

                Form4 form4 = new Form4(this, id, emri, email, telefoni, adresa, true);
                form4.ShowDialog();
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
                DialogResult result = MessageBox.Show("A jeni i sigurt që dëshironi të fshini këtë furnitor?", "Konfirmo Fshirjen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        string query = "DELETE FROM furnitore WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                   
                }
            }
            else
            {
                MessageBox.Show("Zgjedh një rresht që dëshiron të fshish.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // opsionale nëse do të trajtosh klikime në qeliza
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string emri = selectedRow.Cells["Emri Furnitorit"].Value.ToString();
                string email = selectedRow.Cells["Email"].Value.ToString();
                string telefoni = selectedRow.Cells["Telefon"].Value.ToString();
                string adresa = selectedRow.Cells["Adresa"].Value.ToString();

                // Hap Form4 në modalitet editimi dhe dërgon të dhënat
                Form4 form4 = new Form4(this, id, emri, email, telefoni, adresa, true);
                form4.ShowDialog();
            }
            else
            {
                MessageBox.Show("Zgjedh një rresht për të edituar.");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadFurnitore();
              
         }
    }
}


