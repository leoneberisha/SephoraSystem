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


        private void ShihFondatine(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.ShowDialog();
        }


        private void ShihMaskara(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.ShowDialog();
        }


        private void ShihBuzekuq(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.ShowDialog();
        }

       

        private void ShihBlush(object sender, EventArgs e)
        {
            Form12 form12 = new Form12();
            form12.ShowDialog();
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

     
        private void raportiDitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
          Form17 form17 = new Form17();
          form17.ShowDialog();
        }
    }
}
