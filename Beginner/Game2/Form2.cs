using System.Windows.Forms;

namespace Game2
{
    public partial class Players : Form
    {
        public Players()
        {
            InitializeComponent();
        }

        // Play Game Method.
        private void playGame(object sender, System.EventArgs e)
        {
            TicTacToe.myPlayers(p1.Text, p2.Text);
            this.Close();
        }

        // Key Press Method.
        private void myKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
                but_Play.PerformClick();
        }
    }
}
