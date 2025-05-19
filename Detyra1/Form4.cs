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
        private void LoadFurnitore()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id,emri as 'Emri Furnitorit',email as 'Email', telefoni as 'Telefon', adresa as 'Adresa' FROM furnitore";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                Form3 form3 = new Form3();
                form3.ShowDialog();
            }
        }
        public Form4()
        {
            InitializeComponent();
        }
        private Form3 form3Reference;

        public Form4(Form3 form3)
        {
            InitializeComponent();
            form3Reference = form3;
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

        private void button2_Click(object sender, EventArgs e)//== RUAJ
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO furnitore(emri, email, telefoni, adresa) VALUES(@emri, @email, @telefoni, @adresa)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@emri", textBox1.Text);
                cmd.Parameters.AddWithValue("@email", textBox2.Text); // Make sure no space
                cmd.Parameters.AddWithValue("@telefoni", textBox3.Text);
                cmd.Parameters.AddWithValue("@adresa", textBox4.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            // ✅ Call the method to refresh Form3’s DataGridView
            form3Reference.LoadFurnitore();

            // ✅ Close this form if desired
            this.Close();
        }
        private bool isEditMode = false;
        private int editingId;

        public Form4(Form3 form3, int id, string emri, string email, string telefoni, string adresa, bool isEdit)
        {
            InitializeComponent();
            form3Reference = form3;
            isEditMode = isEdit;
            editingId = id;

            // Mbush textbox-at
            textBox1.Text = emri;
            textBox2.Text = email;
            textBox3.Text = telefoni;
            textBox4.Text = adresa;
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd;

                if (isEditMode)
                {
                    string updateQuery = "UPDATE furnitore SET emri=@emri, email=@email, telefoni=@telefoni, adresa=@adresa WHERE id=@id";
                    cmd = new MySqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@id", editingId);
                }
                else
                {
                    string insertQuery = "INSERT INTO furnitore(emri, email, telefoni, adresa) VALUES(@emri, @email, @telefoni, @adresa)";
                    cmd = new MySqlCommand(insertQuery, conn);
                }

                cmd.Parameters.AddWithValue("@emri", textBox1.Text);
                cmd.Parameters.AddWithValue("@email", textBox2.Text);
                cmd.Parameters.AddWithValue("@telefoni", textBox3.Text);
                cmd.Parameters.AddWithValue("@adresa", textBox4.Text);

                cmd.ExecuteNonQuery();
                conn.Close();
            }

            form3Reference.LoadFurnitore();
            this.Close();
        }

    }
}

