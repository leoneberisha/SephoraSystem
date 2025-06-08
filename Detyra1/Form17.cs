using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Detyra1
{
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();

            string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";
            DateTime dataSot = DateTime.Today;
            labelDataSot.Text = "Data: " + dataSot.ToString("dd/MM/yyyy");

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT id, emri_klientit AS 'Emri', mbiemri_klientit AS 'Mbiemri',
                         produkti AS 'Produkti', sasia AS 'Sasia', cmimi AS 'Çmimi',
                         statusi AS 'Statusi', totali AS 'Totali'
                         FROM porosit
                         WHERE DATE(data) = @data";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@data", dataSot);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToString("dd/MM/yyyy  HH:mm:s");

        }

        private void Form17_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}
