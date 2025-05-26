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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
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
            textBox8.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "insert into maskara(emriFurnitorit,emriKategorise,emriMaskares,sasia,cmimiBlerjes,cmimiShitjes,aktiv) VALUES (@emriFurnitorit,@emriKategorise,@emriMaskares,@sasia,@cmimiBlerjes,@cmimiShitjes,@aktiv)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@emriFurnitorit",textBox1.Text);
                cmd.Parameters.AddWithValue("@emriKategorise",textBox2.Text);
                cmd.Parameters.AddWithValue("@emriMaskares", textBox3.Text);
                cmd.Parameters.AddWithValue("@sasia", textBox4.Text);
                cmd.Parameters.AddWithValue("@cmimiBlerjes", textBox5.Text);
                cmd.Parameters.AddWithValue("@cmimiShitjes",textBox6.Text);
                cmd.Parameters.AddWithValue("@aktiv",textBox7.Text);
                cmd.Parameters.AddWithValue("@totali",textBox8.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            }
    }
}
