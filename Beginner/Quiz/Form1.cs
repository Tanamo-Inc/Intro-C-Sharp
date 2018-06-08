using System;
using System.Windows.Forms;

namespace Quizi
{
    public partial class Quiz : Form
    {
        // Variable of type string.
        String title = "Tanamo Inc";

        public Quiz()
        {
            InitializeComponent();
        }

        // Check for Answer.
        private void checker(object sender, EventArgs e)
        {

            if (textBox1.Text == ".NET" || textBox1.Text == ".net")
            {

                MessageBox.Show("Congrat !!!", title);
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Empty Field !!!", title);

            }

            else
            {
                MessageBox.Show("Please try Again!!!", title);
            }

        }

    }
}
