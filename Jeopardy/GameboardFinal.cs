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
    public partial class GameboardFinal : Form
    {
        Database myDb = new Database();
        Database theDb = new Database();
        Random randomNum = new Random();
        int  getRandomNum;

        int checkPlayer1Val = 0;
        int checkPlayer2Val = 0;

        public GameboardFinal()
        {
            InitializeComponent();
        }
        //Button Final Stats shows the game over page if the users score are not equal to zero.  It will create an end of stats object and re direct the user to
        // to the next page.

        private void btnFinalStats_Click(object sender, EventArgs e)
        {
            if(checkPlayer1Val != 0 && checkPlayer2Val != 0)
            {
                EndGameStats endOfGame = new EndGameStats("");
                endOfGame.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Not all players have submitted their answers!");
            }
        }
        //Final Jeopardy on load will grab all of the questions and player info and populate the text boxes on the page with player 1 score and the wager amount.
        //The question calls Random Number to display a random question each time the user enters the final Jeopardy game.
        

        private void GameboardFinal_Load(object sender, EventArgs e)
        {
            DataTable finalJeopardy = myDb.getAllTableData("FinalJeopardy");
            DataTable tablePlayer = myDb.getAllTableData("PlayerInfo");

            Random randomNum = new Random();
            int num = (int)randomNum.Next(4);
            getRandomNum = num;
            lblFinalQuestion.Text = finalJeopardy.Rows[getRandomNum]["Final_Question"].ToString();

            lblPlayer1Score.Text = tablePlayer.Rows[0]["Player_Score"].ToString();
            lblPlayer2Score.Text = tablePlayer.Rows[1]["Player_Score"].ToString();

            lblPlayer1Wager.Text = tablePlayer.Rows[0]["Player_Wager"].ToString();
            lblPlayer2Wager.Text = tablePlayer.Rows[1]["Player_Wager"].ToString();
        }
        //Button 1 Click creates a new Database object and Datatable object to retrieve the question to be displayed on the page.  The random question is mathched
        // to the answer that corresponds.  If the answer is correct the score is updated and if it is wrong the score is subtracted.  The database object 
        // calls updatePlayerScore to commit the changes into the database.
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable finalJeopardy = myDb.getAllTableData("FinalJeopardy");
            DataTable finalJepoardyScore = myDb.getAllTableData("PlayerInfo");
            int player1Score = (int)finalJepoardyScore.Rows[0]["Player_Score"];
            int player1Wager = (int)finalJepoardyScore.Rows[0]["Player_Wager"];
            //int finalScore = player1Score - player1Wager;
            

            string finalAnswer = finalJeopardy.Rows[getRandomNum]["Final_Answer"].ToString();
            if (txtFinalJepordy1.Text == finalAnswer)
            {
                int finalScore = player1Score + player1Wager;
                MessageBox.Show("Answer is correct");
                MessageBox.Show(finalScore.ToString());
                myDb.updatePlayerScore(finalScore, 1);
            } else
            {
                int finalScore = player1Score - player1Wager;
                MessageBox.Show("Answer is incorrect");
                MessageBox.Show(finalScore.ToString());
                myDb.updatePlayerScore(finalScore, 1);
            }

            

            
                checkPlayer1Val = 1;
            
        }
        //Button 2 Click creates a new Database object and Datatable object to retrieve the question to be displayed on the page.  The random question is mathched
        // to the answer that corresponds.  If the answer is correct the score is updated and if it is wrong the score is subtracted.  The database object 
        // calls updatePlayerScore to commit the changes into the database.
        private void button2_Click(object sender, EventArgs e)
        {
            
            DataTable finalJeopardy = theDb.getAllTableData("FinalJeopardy");
            DataTable finalJepoardyScore = theDb.getAllTableData("PlayerInfo");
            int player2Score = (int)finalJepoardyScore.Rows[1]["Player_Score"];
            int player2Wager = (int)finalJepoardyScore.Rows[1]["Player_Wager"];

            string finalAnswer = finalJeopardy.Rows[getRandomNum]["Final_Answer"].ToString();
            if (txtFinalJepordy2.Text == finalAnswer)
            {
                int finalScore2 = player2Score + player2Wager;
                MessageBox.Show("Answer is correct");
                MessageBox.Show(finalScore2.ToString());
                theDb.updatePlayerScore(finalScore2, 2);
            }
            else
            {
                int finalScore2 = player2Score - player2Wager;
                MessageBox.Show("Answer is incorrect");
                MessageBox.Show(finalScore2.ToString());
                theDb.updatePlayerScore(finalScore2, 2);
            }
            

            
                checkPlayer2Val = 1;
            
        }

        }
    }

