using System;
using System.Windows.Forms;

namespace Game2
{
    public partial class TicTacToe : Form
    {
  
        bool turn = true; // true = X turn ; false = O turn;
        int myCounts = 0;

        //My Constructor.
        public TicTacToe()
        {
            InitializeComponent();
        }

        //New Game Method.
        private void myNewGame(object sender, EventArgs e)
        {

            turn = true;
            myCounts = 0;

            foreach (Control con in Controls)
            {
                try
                {
                    Button bun = (Button)con;
                    bun.Enabled = true;
                    bun.Text = "";
                }
                catch { }
            }

        }

        //About Game Method.
        private void myAbout(object sender, EventArgs e)
        {
            MessageBox.Show("by Tanamo Inc.", "About");
        }

        //Exit Game Method.
        private void myExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Reset Method
        private void myReset(object sender, EventArgs e)
        {
            x_win.Text = "0";
            o_win.Text = "0";
            draw_xo.Text = "0";

        }

        //Button Clicked Method.
        private void but_click(object sender, EventArgs e)
        {
            Button but = (Button)sender;

            if (turn)
                but.Text = "X";
            else
                but.Text = "O";

            turn = !turn;
            myCounts++;

            but.Enabled = false;
            check_winner();
        }

        //Compute for Winner.
        private void check_winner() {
            bool win = false;

            //Horizontal Check
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text)&&(!A1.Enabled))
                win = true;
           else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                win = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                win = true;


            //Vertical Check
           else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                win = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                win = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                win = true;

            //Diagonal Check
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                win = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                win = true;
     
            if (win)
            {
          
                String winner = "";

                if (turn)
                {
                    winner = "O";
                    o_win.Text = (Int32.Parse(o_win.Text)+1).ToString();
                }
                else
                {
                    winner = "X";

                    x_win.Text = (Int32.Parse(x_win.Text)+1).ToString();
                }

                MessageBox.Show(winner + " wins !", "WOW");
                disable_Button();

            }

            else
            {

                if (myCounts == 9)
                {
                    MessageBox.Show("What a Draw", "WOW");

                    draw_xo.Text = (Int32.Parse(draw_xo.Text) + 1).ToString();
                }
            }


        }

        //Disable my Buttons.
        private void disable_Button()
        {

                foreach (Control con in Controls)
                {

                try
                {

                    Button bun = (Button)con;
                    bun.Enabled = false;

                }

                catch
                {

                }

            }



        }

        //Button Enter Method.
        private void but_enter(object sender, EventArgs e)
        {
            Button but = (Button)sender;

            if (but.Enabled)
            {
                if (turn)
                    but.Text = "X";
                else
                    but.Text = "O";

            }

        }

        //Button Leave Method.
        private void but_leave(object sender, EventArgs e)
        {

            Button but = (Button)sender;

            if (but.Enabled)
            {
                    but.Text = "";
            }



        }

      


    }

}
