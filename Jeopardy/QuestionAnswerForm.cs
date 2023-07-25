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
    public partial class QuestionAnswerForm : Form
    {
        //This is a global variable set to theQuestion that can be used any where in the QuestionAnswerForm.
        string globalQuestion;
        string globalAnswer;
        int globalPrice;
        int globalTotal;



        Database myDb = new Database();
        


        public QuestionAnswerForm(string theQuestion, string theAnswer, int thePrice)
        {
            InitializeComponent();

            //Sets the global variable to theQuestion being recieve from the GameboardForm.
            globalQuestion = theQuestion;
            globalAnswer = theAnswer;
            globalPrice = thePrice;
        }

        private void QuestionAnswerForm_Load(object sender, EventArgs e)
        {
            //Sets the text to the question being asked.
            lblQuestion.Text = globalQuestion;
            grpPlayerAnswer.Visible = false;



        }
        //button player 1 click initializes the properties of the button.

        private void btnPlayer1Buzzer_Click(object sender, EventArgs e)
        {
            grpPlayerAnswer.Visible = true;
            grpPlayerAnswer.Name = "grpPayer1Answer";
            grpPlayerAnswer.Text = "Player 1 Answer Form";
            btnPlayer2Buzzer.Visible = false;
            btnPlayerSubmit.Name = "btnPlayer1Submit";



            
        }
        //Button player 2 click initalizes the propertiies of the button.
        private void btnPlayer2Buzzer_Click(object sender, EventArgs e)
        {
            grpPlayerAnswer.Visible = true;
            grpPlayerAnswer.Name = "grpPayer2Answer";
            grpPlayerAnswer.Text = "Player 2 Answer Form";
            btnPlayer1Buzzer.Visible = false;

            btnPlayerSubmit.Name = "btnPlayer2Submit";

        }

        //Method checkAnswer(), accepts a string answer as a parameter which is used to check if an answer is correct.  If it is not correct, we set the value
        // for the button clicked on to be negative to eventually subtract from the total amount.

        public void CheckAnswer(string answer)
        {
            string selection = txtPlayerAnswer.Text;
            if (selection == answer)
            {
                
                MessageBox.Show("Answer is correct" + selection);



            }
            else
            {
                MessageBox.Show("Answer is incorrect");
                globalPrice = globalPrice * -1;

            }


        }
        //Button player submit will create a new database object and get the Player Info table.  If the button is submitted the programe checks the answer
        // and if the answer is correct will add the score to playerCalcScore to be then stored in the database of the PlayerInfo table.  If it is wrong then
        //it will subtract the amount from player score and put it in the Player Info table in the database.  This will do it for both players.


        private void btnPlayerSubmit_Click(object sender, EventArgs e)
        {
            Database theDb = new Database();
            DataTable tablePlayer = theDb.getAllTableData("PlayerInfo");
            if (btnPlayerSubmit.Name == "btnPlayer1Submit")
            {
                CheckAnswer(globalAnswer);
                int playerID = 1;
                int playerScore = (int)tablePlayer.Rows[0]["Player_Score"];

                int playerCalcScore = playerScore + globalPrice;


                myDb.updatePlayerScore(playerCalcScore, playerID);
                this.Close();
            }
            else if (btnPlayerSubmit.Name == "btnPlayer2Submit")
            {
                CheckAnswer(globalAnswer);
                int playerID = 2;
                int playerScore = (int)tablePlayer.Rows[1]["Player_Score"];

                int playerCalcScore = playerScore + globalPrice;
                myDb.updatePlayerScore(playerCalcScore, playerID); ;
                this.Close();
            }
        }
    }
}

     

