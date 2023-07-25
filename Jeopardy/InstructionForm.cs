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
    public partial class InstructionForm : Form
    {
        public InstructionForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //JepordyWelcome newJeopardyWelcome = new JepordyWelcome();
            //newJeopardyWelcome.ShowDialog();
            //this.Hide();

            JepordyWelcome welcomeForm = (JepordyWelcome)Application.OpenForms["JepordyWelcome"];
            welcomeForm.ShowDialog();
            this.Hide();
        }

        private void InstructionForm_Load(object sender, EventArgs e)
        {
            string jeopardyInstructions = "You will be playing a Jeopardy game created by Christian Gawek and Shawn Gabel.\n" +
                "There are six categories with five questions in each category.  Each person will pick a question with by \n" +
                "clicking on the box with a certain dollar amount.  A wagerform will appear allowing the user to enter their \n" +
                "answer.  If the answer is correct, the amount the user clicked will go up.  An incorrect answer will deduct \n" +
                "points.  All questions must be answere before moving onto round two.  Round 2 is played the same way as round 1, \n" +
                "except the point totals are doubled.  Once all questions are answered, each contestant can enter a wager amount if \n " +
                "ther-ir score is positive.  If a playes score is negative the other user wins and the game will go to the final stat sheet. \n" +
                "If both scores are positive and wager amounts do not exceed total score, each player will be able to play final Jeopardy \n" +
                "which displays a randomly generated question.  Correct answer will add wager to toal amount, while incoreect answer will deduct. \n" +
                "After Final Jeopardy, the final score will be shown for each user and the user can then click back to the home screen to play again. \n" +
                "Good Luck!";

            label2.Text = jeopardyInstructions;
        }
    }
}
