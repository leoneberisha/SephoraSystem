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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

      

         private void shtoFurnitore(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            DialogResult dialogResult = form4.ShowDialog();
        }



        private void ShihFondatine(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.ShowDialog();
        }

        private void ShtoMaskara(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.ShowDialog();
        }

        private void ShihMaskara(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.ShowDialog();
        }

        private void ShtoBuzekuq(object sender, EventArgs e, Form9 form9)
        {
            Form9 formInsert = new Form9(); 
            formInsert.ShowDialog();

        }

        private void ShihBuzekuq(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.ShowDialog();
        }

        private void ShtoBlush(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.ShowDialog();
        }

        private void ShihBlush(object sender, EventArgs e)
        {
            Form12 form12 = new Form12();
            form12.ShowDialog();
        }

        private void ShtoProdukt(object sender, EventArgs e)
        {
            Form13 form13 = new Form13();
            form13.ShowDialog();
        }

        private void ShikoProduktet(object sender, EventArgs e)
        {
            Form14 form14 = new Form14();
            form14.ShowDialog();
        }

        private void ShtoPorosi(object sender, EventArgs e)
        {
            Form15 form15 = new Form15();
            form15.ShowDialog();
        }

      

        private void ShihProduktet(object sender, EventArgs e)
        {
            Form14 form14= new Form14();
            form14.ShowDialog();
        }

        private void ShihPorosite(object sender, EventArgs e)
        {
            Form16 form16 = new Form16();
            form16.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
