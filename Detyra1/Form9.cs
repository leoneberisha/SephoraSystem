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
    public partial class Form9 : Form
    {
        string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";
        private void LoadBuzekuq()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, emriFurnitorit as 'Emri Furnitorit', emriBuzekuqit as 'Emri Buzekuqit', nuanca as 'Nuanca', sasia as 'Sasia', cmimiBlerjes as 'Cmimi Blerjes', cmimiShitjes as 'Cmimi Shitjes', totali as 'Totali' FROM buzekuq";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                Form10 form10 = new Form10();
                form10.ShowDialog();
            }
        }
        public Form9()
        {
            InitializeComponent();
            LoadBuzekuq();
        }
        public Form9(Form10 form10)
        {
            InitializeComponent();
            Form10Reference = form10;
        }
        private Form10 Form10Reference;

        public Form9(Form10 form10, int id, string emriFurnitorit, string emriBuzekuqit, string nuanca,
             string sasia, string cmimiBlerjes, string cmimiShitjes, string totali, bool isEdit)
        {
            InitializeComponent();
            Form10Reference = form10;
            isEditMode = isEdit;
            editingId = id;

            textBox1.Text = emriFurnitorit;
            textBox2.Text = emriBuzekuqit;
            textBox3.Text = nuanca;
            textBox4.Text = sasia;
            textBox5.Text = cmimiBlerjes;
            textBox6.Text = cmimiShitjes;
            textBox7.Text = totali;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO buzekuq( @emriFurnitorit, @emriBuzekuqit, @nuanca, @sasia, @cmimiBlerjes, @cmimiShitjes,@totali ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@emriFurnitorit", textBox1.Text);
                cmd.Parameters.AddWithValue("@emriBuzekuqit", textBox2.Text);
                cmd.Parameters.AddWithValue("@nuanca", textBox3.Text);
                cmd.Parameters.AddWithValue("@sasia", textBox4.Text);
                cmd.Parameters.AddWithValue("@cmimiBlerjes", textBox5.Text);
                cmd.Parameters.AddWithValue("@cmimiShitjes", textBox6.Text);
                cmd.Parameters.AddWithValue("@totali", textBox7.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool isEditMode = true;
        private int editingId;

        private void button3_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd;

                if (isEditMode)
                {
                    string upadateQuery = "Update buzekuq SET  emriFurnitorit=@emriFurnitorit, emriBuzekuqit=@emriBuzekuqit,nuanca=@nuanca,sasia=@sasia, cmimiBlerjes=@cmimiBlerjes, cmimiShitjes=@cmimiShitjes,totali=@totali Where id = @id";
                    cmd = new MySqlCommand(upadateQuery, conn);
                    cmd.Parameters.AddWithValue("@id", editingId);
                }
                else
                {
                    string insertQuery = "INSERT INTO buzekuq( emriFurnitorit, emriBuzekuqit, nuanca, sasia, cmimiBlerjes, cmimiShitjes,totali) VALUES (@emriFurnitorit, @emriBuzekuqit, @nuanca, @sasia, @cmimiBlerjes, @cmimiShitjes,@totali) ";
                    cmd = new MySqlCommand(@insertQuery, conn);
                }

                cmd.Parameters.AddWithValue("@emriFurnitorit", textBox1.Text);
                cmd.Parameters.AddWithValue("@emriBuzekuqit", textBox2.Text);
                cmd.Parameters.AddWithValue("@nuanca", textBox3.Text);
                cmd.Parameters.AddWithValue("@sasia", textBox4.Text);
                cmd.Parameters.AddWithValue("@cmimiBlerjes", textBox5.Text);
                cmd.Parameters.AddWithValue("@cmimiShitjes", textBox6.Text);
                cmd.Parameters.AddWithValue("@totali", textBox7.Text);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            Form10Reference.LoadBuzekuq();
            this.Close();
        }
        
    }
}
