using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
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
    public partial class Form19 : Form
    {
        private int porosiId;
        private string klienti;
        string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";

        public Form19(int id)
        {
            InitializeComponent();
            porosiId = id;
            klienti = emriKlientit;
        }
     
        private void Form19_Load(object sender, EventArgs e)
        {
            label16.Text = DateTime.Now.ToString("dd/MM/yyyy");
            label37.Text = "FA" + DateTime.Now.ToString("yyyyMMddHHmmss");
            label12.Text = klienti;

            string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";
            int porosiId = 1; // ose variabla që e merr nga zgjedhja e përdoruesit

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT 
                        produkti AS Pershkrimi,
                        'copë' AS Njesia,
                        sasia AS Sasia,
                        (sasia * cmimi) AS Vlera
                     FROM porosit
                     WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", porosiId);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                // DataGridView ose binde në raportin tënd
                dataGridView1.DataSource = table;
            }

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
