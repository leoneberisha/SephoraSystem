using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Detyra1
{
    public partial class Form21 : Form
    {
        private string emriKlienti;
        private DateTime dataNga;
        private DateTime dataDeri;


        public Form21(string emer, DateTime dataNga, DateTime dataDeri)
        {
            InitializeComponent();
            emriKlienti = emer;
            this.dataNga = dataNga;
            this.dataDeri = dataDeri;
        }

        private void Form21_Load(object sender, EventArgs e)
        {
            string connString = "server=localhost;database=sephorasistem;uid=root;pwd=;";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                string query = @"SELECT emri_klientit AS 'Emri', data, produkti, sasia, cmimi, totali
                         FROM porosit
                         WHERE DATE(data) BETWEEN @dataNga AND @dataDeri
                         AND emri_klientit LIKE @emri";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dataNga", dataNga);
                cmd.Parameters.AddWithValue("@dataDeri", dataDeri);
                cmd.Parameters.AddWithValue("@emri", "%" + emriKlienti + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);
                dataGridView1.DataSource = tabela;
            }
        }

    }
}
