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
    public partial class Form20 : Form
    {

        string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";

        private void shfaqRaportin()
        {
            
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"Select emri_klientit AS 'Emri', data,produkti, sasia,cmimi,totali
                                From porosit
                                where Date(data) BETWEEN @dataNga AND @DataDeri";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DataNga", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@DataDeri",dateTimePicker2.Value.Date);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;


            }
        }
        public Form20()
        {
            InitializeComponent();
        }

        private void Form20_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            shfaqRaportin();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string emri = textBox1.Text.Trim();
            DateTime dataNga = dateTimePicker1.Value.Date;
            DateTime dataDeri = dateTimePicker2.Value.Date;

            if (!string.IsNullOrEmpty(emri))
            {
                Form21 raportKlient = new Form21(emri, dataNga, dataDeri);
                raportKlient.Show();
            }
            else
            {
                MessageBox.Show("Shkruani emrin e klientit.");
            }
        }

    }
}
