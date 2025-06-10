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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            /*
           string connectionString = "Server=localHost;Database=sephorasistem;Uid=root;Pwd='';";
           MySqlConnection conn = new MySqlConnection(connectionString);

           try
           {
               conn.Open();
               MessageBox.Show("Lidhje u bere me sukses");
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }


           }*/


            string connStr = "server=localhost;user=root;database=sephorasistem;password='';";
            string username = textBox1.Text;
            string password = textBox2.Text;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "Select * FROM login WHERE user=@username AND pass=@password";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Form2 form2 = new Form2();
                        form2.ShowDialog();
                        //  MessageBox.Show("Login me sukses");
                    }
                    else
                    {
                        MessageBox.Show("Kyqja deshtoi! ");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gabim" + ex.Message);
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }


}
       
