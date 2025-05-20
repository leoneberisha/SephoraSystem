using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Detyra1
{
    public partial class Form3 : Form
    {


        public void LoadFurnitore()
        {
            string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, emri AS 'Emri Furnitorit', email AS 'Email', telefoni AS 'Telefon', adresa AS 'Adresa' FROM furnitore";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        public Form3()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     


        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(this);  
            form4.ShowDialog();


            }

        private void button4_Click(object sender, EventArgs e)
        {//edito buton
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string emri = selectedRow.Cells["Emri Furnitorit"].Value.ToString();
                string email = selectedRow.Cells["Email"].Value.ToString();
                string telefoni = selectedRow.Cells["Telefon"].Value.ToString();
                string adresa = selectedRow.Cells["Adresa"].Value.ToString();

                // Hap Form4 për editim dhe dërgo të dhënat
                Form4 form4 = new Form4(this, id, emri, email, telefoni, adresa, true); // true = editing mode
                form4.ShowDialog();
            }
            else
            {
                MessageBox.Show("Zgjedh një rresht për të edituar.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {//fshij buton
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("A jeni i sigurt që dëshironi të fshini këtë furnitor?", "Konfirmo Fshirjen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                    string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        string query = "DELETE FROM furnitore WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    // Rifresko DataGridView
                    LoadFurnitore();
                }
            }
            else
            {
                MessageBox.Show("Zgjedh një rresht që dëshiron të fshish.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {//butoni kerkoj
            string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, emri AS 'Emri Furnitorit', email AS 'Email', telefoni AS 'Telefon', adresa AS 'Adresa' FROM furnitore WHERE emri LIKE @search";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                // Marrim tekstin nga TextBox, jo nga butoni
                cmd.Parameters.AddWithValue("@search", "%" + textBox1.Text + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

    }
}
    

