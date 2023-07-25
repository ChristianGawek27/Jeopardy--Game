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
    public partial class EndGameStats : Form
    {
        string globalWinnerMessage;
        Database myDb = new Database();
        Database theDb = new Database();

        public EndGameStats(string winnerMessage)
        {
            InitializeComponent();

            globalWinnerMessage = winnerMessage;
        }

        private void EndGameStats_Load(object sender, EventArgs e)
        {
            
            DataTable tablePlayer = myDb.getAllTableData("PlayerInfo");

            //Load the player scores into labels on form load.
            lblPlayer1Score.Text = tablePlayer.Rows[0]["Player_Score"].ToString();
            lblPlayer2Score.Text = tablePlayer.Rows[1]["Player_Score"].ToString();

            //Set the winner message label as the winner message. Example, game is a draw, player 1 wins, player 2 wins.
            lblWinnerMessage.Text = globalWinnerMessage;
            
        }

        //When clicking the button, sends you back to the Welcome to Jeopardy Form.
        //Clears player data for a new round.
        private void button1_Click(object sender, EventArgs e)
        {
            Database myDb = new Database();
            myDb.deleteAllTableData(1);
            theDb.deleteAllTableData(2);

            JepordyWelcome newJepordyGame = new JepordyWelcome();
            newJepordyGame.ShowDialog();
            this.Hide();


        }
    }
}
