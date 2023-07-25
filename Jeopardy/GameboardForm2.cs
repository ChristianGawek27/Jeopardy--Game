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
    public partial class GameboardForm2 : Form
    {

        Database myDb = new Database();
        CheckScore score = new CheckScore();

        //Set the button count to zero.
        int globalBtnCount = 0;

        public GameboardForm2()
        {
            InitializeComponent();
        }

        private void GameboardForm2_Load(object sender, EventArgs e)
        {
            //Creates DataTable object for Round2 and PlayerInfo database tables.
            DataTable tableRound2 = myDb.getAllTableData("Round2");
            DataTable tablePlayer = myDb.getAllTableData("PlayerInfo");


            //On form load, check to see if player score is valid (is score below zero?).
            score.getDataTable(tablePlayer);
            bool player1IsValid = score.isValidScore(0);
            bool player2IsValid = score.isValidScore(1);
            



            //For each GroupBox, for each Button in the GroupBox, set the Button text to price.
            //For each Button set a Click event.
            foreach (GroupBox groupBox in Controls.OfType<GroupBox>())
            {
                int count = 0;
                foreach (Button btn in groupBox.Controls.OfType<Button>())
                {
                    //sets the buttons text to the category price
                    btn.Text += tableRound2.Rows[count]["Category_Price"].ToString();

                    //sets the buttons name to the numerical count (0 to 4). This is so we do not have to name all of our buttons manually.
                    //In our b_Click function we set our button index (bIndex) to our buttons name which is our count.
                    btn.Name = count.ToString();

                    count++;

                    //Set the Click event to each individual button.
                    btn.Click += b_Click;

                    //For every button inside of a GroupBox increase the count of the button count.
                    globalBtnCount++;
                }
            }


            //Onload show the player score.
            lblPlayer1Score.Text = tablePlayer.Rows[0]["Player_Score"].ToString();
            lblPlayer2Score.Text = tablePlayer.Rows[1]["Player_Score"].ToString();



            //This method gets called when a Button is clicked. Hides the GameBoardForm and sends the question over to the QuestionAnswerForm.
            void sendQuestion(int questionIndex, string categoryName)
            {
                //Stores the question. We pass our index into rows. We pass the category name into columns and add a 'Q'.
                //This relies on the naming scheme for our GroupBox's name. The group box names need to start with "grpCategory_".
                //Needs to follow this naming convention grpCategory_Category_#. Substitute # with category 1 to 6.
                string theQuestion = tableRound2.Rows[questionIndex][categoryName + "Q"].ToString();

                //TODO: send the answer to the other form to be processed?
                string theAnswer = tableRound2.Rows[questionIndex][categoryName + "A"].ToString();

                int thePrice = (int)tableRound2.Rows[questionIndex]["Category_Price"];

                //Creates a new QuestionAnswerForm each time sendQuestion is called. Passes theQuestion to the Q/A Form.
                Form QandAForm = new QuestionAnswerForm(theQuestion, theAnswer, thePrice);

                //Hides GameboardForm.
                //this.Hide();

                //Shows Q/A Form.
                QandAForm.ShowDialog();
            }

            //Click event, calls the sendQuestion method passing in the questions index and category name. Sets the button to invisible.
            void b_Click(object sender, EventArgs e)
            {
                //Object sender is set to our button
                Button button = sender as Button;
                if (button != null)
                {
                    //groupBox is set to the button's parent GroupBox
                    GroupBox groupBox = button.Parent as GroupBox;

                    //bIndex is the button index.
                    int bIndex = Convert.ToInt32(button.Name);

                    //gets the GroupBox name
                    string gpBeforeTrim = groupBox.Name;

                    //This trims the GroupBox name, specifically it removes "grpCategory_". Then we are left with Category_1 or Category_2 for example.
                    string gpAfterTrim = gpBeforeTrim.Remove(0, 12);

                    //To be removed. This just displays the functionallity of the click event.
                    //MessageBox.Show(string.Format("I'm clicking {0}, question index #{1}",
                                    //gpAfterTrim, bIndex));

                    //Each time we click we want to pass our button index (bIndex) and our category name to our sendQuestion function.
                    sendQuestion(bIndex, gpAfterTrim);

                    //We set the clicked button visibility to false.
                    button.Visible = false;

                    //Every time a button is clicked descrease the button count by 1.
                    globalBtnCount = globalBtnCount - 1;

                    //If the the button count reaches zero then go to next GameBoard Form.
                    if (globalBtnCount == 0)
                    {
                        //Calls the ContinueCheck method.
                        ContinueCheck(player1IsValid, player2IsValid);
                        this.Hide();
                    }

                    //The following code block sets the displayed score to current updated score.
                    Database theDb = new Database();
                    DataTable theTable = theDb.getAllTableData("PlayerInfo");
                    lblPlayer1Score.Text = theTable.Rows[0]["Player_Score"].ToString();
                    lblPlayer2Score.Text = theTable.Rows[1]["Player_Score"].ToString();

                }

            }


         

        }


        //This method checks wether if the game should proceed.
        //If player 1 and player 2 scores are invalid (below zero) then the game is a draw. Show end of game form.
        //If player 1 score is invalid and player 2 score is valid, then player 2 wins. Show end of game form.
        //If player 2 score is invalid and player 1 score is valid, then player 1 wins. Show end of game form.
        //If player 1 and player 1 score is valid then move on to final jeopardy round. Show Wager form.
        public void ContinueCheck(bool player1, bool player2)
        {
            if (player1 == false && player2 == false)
            {
                EndGameStats endOfGame = new EndGameStats("The Game is a Draw!");
                endOfGame.ShowDialog();
                //MessageBox.Show("Game is a Draw");
                this.Hide();
            }
            else if (player1 == false && player2 == true)
            {
                //MessageBox.Show("Player 2 wins");
                EndGameStats endOfGame = new EndGameStats("Player 2 Wins!");
                endOfGame.ShowDialog();
                this.Hide();
            }
            else if (player1 == true && player2 == false)
            {
                EndGameStats endOfGame = new EndGameStats("Player 1 Wins!");
                endOfGame.ShowDialog();
                //MessageBox.Show("Player 1 Wins");
                this.Hide();
            }
            else
            {
                WagerForm newWagerForm = new WagerForm();
                newWagerForm.ShowDialog();
                //MessageBox.Show("Contine to Entering Wager Amounts");
                this.Hide();
            }
        }

       
    }
   }




