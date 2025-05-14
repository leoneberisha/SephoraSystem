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

    public partial class Form4 : Form
    {
        string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";
        private void LoadBibloteka()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id,emri as 'Emri Furnitorit',email as 'Email', telefoni as 'Telefon', adresa as 'Adresa' FROM furnitore";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                
            }
        }
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void kategoriteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public static implicit operator Form4(Form5 v)
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                //"SELECT id,emri as 'Emri Furnitorit',email as 'Email', telefoni as 'Telefon', adresa as 'Adresa' FROM furnitore";
                string query = "INSERT INTO furnitore(emri,email , telefoni, adresa) VALUES(@emri, @email, @telefoni, @adresa) ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@emri", textBox1.Text);
                cmd.Parameters.AddWithValue("@email ", textBox2.Text);
                cmd.Parameters.AddWithValue("@telefoni", textBox3.Text);
                cmd.Parameters.AddWithValue("@adresa", textBox4.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                LoadBibloteka();


            }
        }
    }
}
