using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Detyra1
{
    public partial class Form19 : Form
    {
        private int porosiId;
        private string klienti;
        string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";

        public Form19(int id, string emriKlientit)
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
                label14.Text = "FI" + DateTime.Now.ToString("fMMddmmssff");
                label8.Text = "NK" + DateTime.Now.ToString("FfmmssddFF");

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT produkti AS Pershkrimi,
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
                    dataGridView1.DataSource = table;
                }
            
            }

    }
}
