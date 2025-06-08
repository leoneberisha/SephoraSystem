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
    public partial class Form18 : Form
    {
        private string emriKlienti;

        public Form18(string emer)
        {
            InitializeComponent();
            emriKlienti = emer;
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            string connString = "server=localhost;database=sephorasistem;uid=root;pwd=;";
            DateTime dataSot = DateTime.Today;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                string query = @"SELECT emri_klientit AS 'Klientët',produkti, sasia, cmimi,data
                                 FROM porosit
                                 WHERE DATE(data) = @data AND emri_klientit LIKE @emri";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@data", dataSot);
                cmd.Parameters.AddWithValue("@emri", "%" + emriKlienti + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);

                dataGridView1.DataSource = tabela;
            }
        }
    }
}
