using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizi
{
    public partial class Quiz : Form
    {
        //variable of type string.
        String title = "Tanamo Inc";

        public Quiz()
        {
            InitializeComponent();
        }

        private void enter_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == ".NET" || textBox1.Text == ".net")
            {

                MessageBox.Show("Congrat !!!", title);
            }

            else
            {
                MessageBox.Show("Please try Again!!!", title);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
