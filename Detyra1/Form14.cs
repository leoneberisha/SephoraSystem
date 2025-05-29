using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Detyra1
{
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
            LoadTeGjithaProduktet();
        }

        // ✅ Kjo metodë thirret nga forma tjetër (p.sh. Form13) pas ruajtjes
        public void LoadProdukte()
        {
            LoadTeGjithaProduktet(); // e rifreskon listën
        }

        // ✅ Kjo ngarkon të gjitha produktet nga të gjitha tabelat
        private void LoadTeGjithaProduktet()
        {
            using (MySqlConnection conn = new MySqlConnection("server=localhost;database=sephorasistem;uid=root;pwd=;"))
            {
                string query = @"
            SELECT 'Blush' AS Lloji, emri_furnitorit, emriBlush AS Produkti, nuanca, sasia, stoku, cmimiBlerjes, cmimiShitjes, totali FROM blush
            UNION ALL
            SELECT 'Buzekuq', emriFurnitorit, emriBuzekuqit AS Produkti, nuanca, sasia, stoku, cmimiBlerjes, cmimiShitjes, totali FROM buzekuq
            UNION ALL
            SELECT 'Maskara', emriFurnitorit, emri_maskares AS Produkti, nuanca, sasia, stoku, cmimiBlerjes, cmimiShitjes, totali FROM maskara
            UNION ALL
            SELECT 'Fondatine', emri_furnitorit, emri_fondatines AS Produkti, nuanca, sasia, stoku, cmimiBlerjes, cmimiShitjes, totali FROM fondatine";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.ReadOnly = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }



