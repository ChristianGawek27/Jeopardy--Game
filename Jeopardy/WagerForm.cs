using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jeopardy
{
    public partial class WagerForm : Form
    {
        Database myDb = new Database();
        CheckScore score = new CheckScore();

        

        int global1Val = 0;
        int global2Val = 0;

        public WagerForm()
        {
            InitializeComponent();
        }

        private void WagerForm_Load(object sender, EventArgs e)
        {
            DataTable tablePlayer = myDb.getAllTableData("PlayerInfo");
            score.getDataTable(tablePlayer);

            lblPlater1Score.Text = tablePlayer.Rows[0]["Player_Score"].ToString();
            lblPlayer2Score.Text = tablePlayer.Rows[1]["Player_Score"].ToString();


        }
        

        //Button WagerAmountClick(), will see if the player wager is empty and if it is will notify the players to enter a wager before they can play the final
        //round of Jeopardy.  If both wagers have been submitted then the final game board is shown while hiding the wager board.
        private void btnWagerAmount_Click(object sender, EventArgs e)
        {
            if (global1Val != 0 && global2Val != 0)
            {
              
                if (txtPlayer1Wager.Text == String.Empty && txtPlayer2Wager.Text == String.Empty)
                {
                    MessageBox.Show("Players please enter a wager to continue!");


                }
                else
                {
                    GameboardFinal finalRound = new GameboardFinal();
                    finalRound.Show();
                    this.Hide();
                }
            }

            
            
          

        }
        //Button player 1 Wager Submit checks to see if the textbox for the wager amount is empty and if it is alerts the player to enter an amount.
        //it then checks to see if the amount is correct by calling using the check wager amount from the score class.  If the amount is correct, it will
        //place the wager amount in the database by using the database class and calling the updateWagerAmount.

        private void btnPlayer1WagerSubmit_Click(object sender, EventArgs e)
        {
            
            if(txtPlayer1Wager.Text == String.Empty)
            {
                MessageBox.Show("Player 1: wager textbox cannot be Empty!");
            }
            else
            {
                bool player1Score = score.CheckWagerAmount(0, int.Parse(txtPlayer1Wager.Text));
                

                if (player1Score)
                {
                    global1Val = 1;
                    myDb.UpdateWagerAmount(1, int.Parse(txtPlayer1Wager.Text));
                    MessageBox.Show("Wager Submitted!");
                }
               
            }
            
        }
       // Button player 2 Wager Submit checks to see if the textbox for the wager amount is empty and if it is alerts the player to enter an amount.
        //it then checks to see if the amount is correct by calling using the check wager amount from the score class.  If the amount is correct, it will
        //place the wager amount in the database by using the database class and calling the updateWagerAmount.

        private void btnPlayer2WagerSubmit_Click(object sender, EventArgs e)
        {
            Database theDb = new Database();
            
            if (txtPlayer2Wager.Text == String.Empty)
            {
                MessageBox.Show("Player 2: wager textbox cannot be Empty!");
            }
            else
            {
                bool player2Score = score.CheckWagerAmount(1, int.Parse(txtPlayer2Wager.Text));

                if (player2Score)
                {
                    global2Val = 1;
                    theDb.UpdateWagerAmount(2, int.Parse(txtPlayer2Wager.Text));
                    MessageBox.Show("Wager Submitted!");
                }
               
            }

        }
       
    }
}
