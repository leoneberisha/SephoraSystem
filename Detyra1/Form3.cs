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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Detyra1
{
    public partial class Form3 : Form
    {

        string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";
        private void LoadFurnitore()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id,emri as 'Emri Furnitorit',email as 'Email', telefoni as 'Telefon', adresa as 'Adresa' FROM furnitore";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                //"SELECT id,emri as 'Emri Furnitorit',email as 'Email', telefoni as 'Telefon', adresa as 'Adresa' FROM furnitore";
                string query = "INSERT INTO furnitore(emri,email , telefoni, adresa) VALUES(@emri, @email, @telefoni, @adresa) ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
               // cmd.Parameters.AddWithValue("@emri", textBox1.Text);
           //     cmd.Parameters.AddWithValue("@email ", textBox2.Text);
             //   cmd.Parameters.AddWithValue("@telefoni", textBox3.Text);
               // cmd.Parameters.AddWithValue("@adresa", textBox4.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                LoadFurnitore();


            }
        }
    }
}
