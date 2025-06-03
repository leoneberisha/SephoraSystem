using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Detyra1
{
    public partial class Form13 : Form // ShtoProdukte
    {
        private string connectionString = "server=localhost;database=sephorasistem;uid=root;pwd=;";
        private bool isEditMode = false;
        private int editingId;
        private Form14 parentForm; // ShihProdukte

        public Form13(Form14 form)
        {
            InitializeComponent();
            parentForm = form;
        }

        public Form13(Form14 form, int id, string emri, string kategoria, string furnitori, string cmimi, string sasia, string totali)
        {
            InitializeComponent();
            parentForm = form;
            isEditMode = true;
            editingId = id;

            textBox1.Text = emri;
            textBox2.Text = kategoria;
            textBox3.Text = furnitori;
            textBox4.Text = cmimi;
            textBox5.Text = sasia;
        }

        private void buttonRuaj_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(textBox4.Text, out decimal cmimi) || !int.TryParse(textBox5.Text, out int sasia))
            {
                MessageBox.Show("Shkruaj vlera valide për çmimin dhe sasinë.");
                return;
            }

            decimal totali = cmimi * sasia;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd;

                if (isEditMode)
                {
                    string query = @"UPDATE produkti SET emriProduktit=@emri, kategoria=@kat, furnitori=@furn,
                                     cmimi=@cmimi, sasia=@sasia, totali=@totali WHERE id=@id";
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", editingId);
                }
                else
                {
                    string query = @"INSERT INTO produkti(emriProduktit, kategoria, furnitori, cmimi, sasia, totali)
                                     VALUES(@emri, @kat, @furn, @cmimi, @sasia, @totali)";
                    cmd = new MySqlCommand(query, conn);
                }

                cmd.Parameters.AddWithValue("@emri", textBox1.Text);
                cmd.Parameters.AddWithValue("@kat", textBox2.Text);
                cmd.Parameters.AddWithValue("@furn", textBox3.Text);
                cmd.Parameters.AddWithValue("@cmimi", cmimi);
                cmd.Parameters.AddWithValue("@sasia", sasia);
                cmd.Parameters.AddWithValue("@totali", totali);

                cmd.ExecuteNonQuery();
                conn.Close();
            }

            parentForm.LoadProdukte(); // rifreskon DataGridView në Form14
            this.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
