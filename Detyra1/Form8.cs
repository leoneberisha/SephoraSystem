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
    public partial class Form8 : Form
    {
        string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";

        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        public void loadMaskara()
        {

            string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "SELECT id, emriFurnitorit as 'Emri Furnitorit',emriKategorise as 'Emri Kategorise',emriMaskares as 'Emri Maskares',sasia as'Sasia',cmimiBlerjes as 'Cmimi Blerjes',cmimiShitjes as 'Cmimi Shitjes',aktiv as  'Aktiv',totali as 'Totali' FROM maskara";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string emriFurnitorit = selectedRow.Cells["Emri furnitorit"].Value.ToString();
                string emriKategorise = selectedRow.Cells["Emri kategorise"].Value.ToString();
                string ermriMaskares = selectedRow.Cells["Emri maskares"].Value.ToString();
                string sasia = selectedRow.Cells["sasia"].Value.ToString();
                string cmimiBlerjes = selectedRow.Cells["cmimiBlerjes"].Value.ToString();
                string cmimiShitjes = selectedRow.Cells["cmimiShitjes"].Value.ToString();
                string aktiv = selectedRow.Cells["aktiv"].ToString();
                string totali = selectedRow.Cells["totali"].ToString();

                Form7 form7 = new Form7(this,id,emriFurnitorit,emriKategorise, ermriMaskares,sasia,cmimiBlerjes,cmimiShitjes,aktiv,totali,true);
                form7.ShowDialog();

            }
            else
            {
                MessageBox.Show("Zgjedh një rresht për të edituar.");
            }
        }
    }
}
