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
                string query = "SELECT id, emriFurnitorit as 'Emri Furnitorit', emriBuzekuqit as 'Emri Buzekuqit', nuanca as 'Nuanca', sasia as 'Sasia', cmimiBlerjes as 'Cmimi Blerjes', cmimiShitjes as 'Cmimi Shitjes', totali as 'Totali' FROM buzekuq";
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
            Form9 form9 = new Form9(this);
            form9.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string emriFurnitorit = selectedRow.Cells["emriFurnitorit"].Value.ToString();
                string emriBuzekuqit = selectedRow.Cells["Emri Buzekuqit"].Value.ToString();
                string nuanca = selectedRow.Cells["nuanca"].Value.ToString();
                string sasia = selectedRow.Cells["sasia"].Value.ToString();
                string cmimiBlerjes = selectedRow.Cells["cmimiBlerjes"].Value.ToString();
                string cmimiShitjes = selectedRow.Cells["cmimiShitjes"].Value.ToString();
                string totali = selectedRow.Cells["totali"].ToString();

                Form9 form9 = new Form9(this, id, emriFurnitorit, emriBuzekuqit, nuanca, sasia, cmimiBlerjes, cmimiShitjes, totali, true);
                form9.ShowDialog();
            }
            else
            {
                MessageBox.Show("Zgjedh nje rrjesht per te edituar. ");
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

                    string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {

                        string query = "DELETE FROM buzekuq WHERE is=@id";
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
                MessageBox.Show("Zgjedh nje rresht qe deshiron ta fshish. ");
            }
        }
                    

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("A jeni i sigurt që dëshironi të fshini këtë fondatine?", "Konfirmo Fshirjen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                    string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        string query = "DELETE FROM buzekuq Where id = @id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    LoadBuzekuq();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, emriFurnitorit as 'Emri Furnitorit', emriBuzekuqit as 'Emri Buzekuqit', nuanca as 'Nuanca', sasia as 'Sasia', cmimiBlerjes as 'Cmimi Blerjes', cmimiShitjes as 'Cmimi Shitjes', totali as 'Totali' FROM buzekuq";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + textBox1.Text + "%");
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }
    }
}
