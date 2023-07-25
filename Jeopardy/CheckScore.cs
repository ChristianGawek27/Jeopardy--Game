using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeopardy
{
    public class CheckScore
    {
       

        //Constructor for scheck score takes a DatatTable variable in to allow it to be used to check scores of players
        DataTable theTable;
        
        public void getDataTable(DataTable playerTable)
        {
            theTable = playerTable;
        }
        //Method isValidScore() will take in a player ID.  This ID gets the column in the database associated with the ID and sees if the score is less than
        //zero.  If it is, the return false, else return true.

        public Boolean isValidScore(int playerId)
        {
            int playerScore = (int)theTable.Rows[playerId]["Player_Score"];
            if(playerScore <= 0)
            {
                return false;
            } else
            {
                return true;
            }
            
        } 
        //Method CheckWagerAmount() takes in a player Id and wager amount entered by the user on the Wager Form.  It then grabs the column associated for the
        //wager amount and player.  If the wager is greater than zero and less than the player score it is returned true, else it is returned false.
        //This check prevents the user from entering an invalid wager amount.

        public Boolean CheckWagerAmount(int playerId, int wager)
        {
            int playerScore = (int)theTable.Rows[playerId]["Player_Score"];
          
            if (wager > 0 && wager <= playerScore)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
