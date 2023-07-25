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
    public partial class GameboardForm : Form
    {

        Database myDb = new Database();

        //Set the button count to zero.
        int globalBtnCount = 0;

        public GameboardForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Creates DataTable object for Round1 and PlayerInfo database tables.
            DataTable tableRound1 = myDb.getAllTableData("Round1");
            DataTable tablePlayer = myDb.getAllTableData("PlayerInfo");



            //For each GroupBox, for each Button in the GroupBox, set the Button text to price.
            //For each Button set a Click event.
            foreach (GroupBox groupBox in Controls.OfType<GroupBox>())
            {
                int count = 0;
                foreach (Button btn in groupBox.Controls.OfType<Button>())
                {
                    //sets the buttons text to the category price
                    btn.Text += tableRound1.Rows[count]["Category_Price"].ToString();

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
                string theQuestion = tableRound1.Rows[questionIndex][categoryName + "Q"].ToString();

                //Set the answer to a string. Send the string to the Q and A form.
                string theAnswer = tableRound1.Rows[questionIndex][categoryName + "A"].ToString();

                int thePrice = (int)tableRound1.Rows[questionIndex]["Category_Price"];

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
                       
                        GameboardForm2 round2 = new GameboardForm2();
                        round2.ShowDialog();
                        this.Hide();
                    }
                    
                    //The following code block sets the displayed score to current updated score.
                    lblPlayer1Score.Text = "";
                    Database theDb = new Database();
                    DataTable theTable = theDb.getAllTableData("PlayerInfo");
                    lblPlayer1Score.Text = theTable.Rows[0]["Player_Score"].ToString();
                    lblPlayer2Score.Text = theTable.Rows[1]["Player_Score"].ToString();

                }

            }


        }
    }
}


