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
    public partial class JepordyWelcome : Form
    {
        Database myDb = new Database();

        //Set player name check to zero.
        int player1NameCheck = 0;
        int player2NameCheck = 0;

        public JepordyWelcome()
        {
            InitializeComponent();
        }

        private void JepordyWelcome_Load(object sender, EventArgs e)
        {

        }

        //This button click sends you to the instructions form.
        private void btnViewInstructions_Click(object sender, EventArgs e)
        {
            InstructionForm newInstructionForm = new InstructionForm();
            this.Hide();
            newInstructionForm.ShowDialog();
         
        }

        //This button click starts the game.
        //If the playerNameCheck intergers are not zero then go to the Gameboard1 Form
        //If they are zero then show a message to the players to enter their names.
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            

            if(player1NameCheck != 0 && player2NameCheck != 0)
            {
                GameboardForm startGame = new GameboardForm();
                startGame.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Not all Players have entered their name!");
            }

        }

        //If the player 1 text box is not empty do a database commit and set the playerNameCheck interger to 1.
        private void btnPlayer1Submit_Click(object sender, EventArgs e)
        {
            

            if(txtPlayer1Name.Text != String.Empty)
            {
                myDb.insertPlayerName(1, txtPlayer1Name.Text);
                player1NameCheck = 1;
                txtPlayer1Name.Text = "";
            }else
            {
                MessageBox.Show("Player 1: please enter a name!");
            }

            
        }

        //If the player 2 text box is not empty do a database commit and set the playerNameCheck interger to 2.
        private void btnPlayer2Submit_Click(object sender, EventArgs e)
        {
            Database theDb = new Database();
            
            if (txtPlayer2Name.Text != String.Empty)
            {
                theDb.insertPlayerName(2, txtPlayer2Name.Text);
                player2NameCheck = 1;
                txtPlayer2Name.Text = "";
            }
            else
            {
                MessageBox.Show("Player 2: please enter a name!");
            }
        }
    }
}
