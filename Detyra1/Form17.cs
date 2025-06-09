using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.DataVisualization.Charting;

namespace Detyra1
{
    public partial class Form17 : Form
    {
        string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";

        public Form17()
        {

            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {
          
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToString("dd/MM/yyyy");
            label9.Text = DateTime.Now.ToString("dd/MM/yyyy");
            label11.Text = DateTime.Now.ToString("dd/MM/yyyy");

            string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";
            DateTime dataSot = DateTime.Today;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Shfaq Totali i Shitjeve
                string queryTotali = @"SELECT SUM(totali) AS shuma FROM porosit WHERE DATE(data) = @data";
                MySqlCommand cmdTotali = new MySqlCommand(queryTotali, conn);
                cmdTotali.Parameters.AddWithValue("@data", dataSot);
                object resultTotali = cmdTotali.ExecuteScalar();
                label6.Text = resultTotali != DBNull.Value && resultTotali != null
                    ? Convert.ToDecimal(resultTotali).ToString("F2") + " €"
                    : "0.00 €";

                //Shfaq Porositë në DataGridView
                string queryLista = @"SELECT emri_klientit AS 'Emri',
                                     produkti AS 'Produkti',
                                     sasia AS 'Sasia',
                                     cmimi AS 'Çmimi',
                                     totali AS 'Totali'
                              FROM porosit
                              WHERE DATE(data) = @data";
                MySqlCommand cmdLista = new MySqlCommand(queryLista, conn);
                cmdLista.Parameters.AddWithValue("@data", dataSot);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmdLista);
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);
                dataGridView1.DataSource = tabela;

                // Shfaq Numrin e Produkteve të Shitura
                string querySasia = @"SELECT SUM(sasia) FROM porosit WHERE DATE(data) = @data";
                MySqlCommand cmdSasia = new MySqlCommand(querySasia, conn);
                cmdSasia.Parameters.AddWithValue("@data", dataSot);
                object resultSasia = cmdSasia.ExecuteScalar();
                label13.Text = resultSasia != DBNull.Value ? resultSasia.ToString() : "0";

                // Shfaq Grafikun e Produkteve më të Shitura
                string queryChart = @"SELECT produkti, SUM(sasia) AS total_sasia
                              FROM porosit
                              WHERE DATE(data) = @data
                              GROUP BY produkti";
                MySqlCommand cmdChart = new MySqlCommand(queryChart, conn);
                cmdChart.Parameters.AddWithValue("@data", dataSot);
                MySqlDataReader reader = cmdChart.ExecuteReader();

                chartShitje.Series.Clear();
                Series series = new Series("Produktet më të shitura");
                series.ChartType = SeriesChartType.Column;

                while (reader.Read())
                {
                    string produkti = reader.GetString("produkti");
                    int sasia = reader.GetInt32("total_sasia");
                    series.Points.AddXY(produkti, sasia);
                }

                chartShitje.Series.Add(series);
                reader.Close();

            }
        }




        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string emer = textBox1.Text.Trim();   // Marrim tekstin nga textboxi
            Form18 f = new Form18(emer);          // E dërgojmë në Form18
            f.Show();
        }
    }
}
