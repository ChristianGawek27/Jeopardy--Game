using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Jeopardy
{
    public class Database
    {
        OleDbConnection myConnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source=JeopardyDatabase.accdb;");
        OleDbDataAdapter myDataAdapter;
        DataSet myDataSet;
        DataTable myTable;


        //This method returns a DataTable containing all columns and rows from any table.
        public DataTable getAllTableData(string tableName)
        {
            string strSQL = "SELECT * FROM "+ tableName +"";
            myDataAdapter = new OleDbDataAdapter(strSQL, myConnection);
            myDataSet = new DataSet(tableName);
            myDataAdapter.Fill(myDataSet, tableName);

            myTable = myDataSet.Tables[tableName];

            return myTable;
        }

        //This method updates the players score in the database, accepts a price and a playerID.
        public void updatePlayerScore(int price, int playerID)
        {
            using (myConnection)
            {
                OleDbCommand command = new OleDbCommand();
                OleDbTransaction transaction = null;

                // Set the Connection to the new OleDbConnection.
                command.Connection = myConnection;

                // Open the connection and execute the transaction.
                try
                {
                    myConnection.Open();

                    // Start a local transaction
                    transaction = myConnection.BeginTransaction();

                    // Assign transaction object for a pending local transaction.
                    command.Connection = myConnection;
                    command.Transaction = transaction;

                    // Execute the commands.
                    command.CommandText =
                         //"UPDATE PlayerInfo SET [Size]=" + int.Parse(txtModifySize.Text) + "," + "Manufacturer='" + txtModifyManufacturer.Text + "'," + "Description='" + txtModifyDescription.Text + "'," + "Price=" + int.Parse(txtModifyPrice.Text) + "," + "Shoe_Category='" + txtModifyCategory.Text + "'," + "Gender='" + txtModifyGender.Text + "'" + "WHERE ID=" + int.Parse(txtModifyShoe.Text) + "";
                    "UPDATE PlayerInfo SET Player_Score = " + price +" WHERE ID="+ playerID +"";
                    command.ExecuteNonQuery();

                    // Commit the transaction.
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        // Attempt to roll back the transaction.
                        transaction.Rollback();
                    }
                    catch
                    {
                        // Do nothing here; transaction is not active.
                    }
                }
                // The connection is automatically closed when the
                // code exits the using block.
            }
        }

        //This method updates the PlayerInfo database table, Player_Wager column. Accepts playerID and a wager ammount.
        public void UpdateWagerAmount(int playerId, int wagerAmount)
        {
            using (myConnection)
            {
                OleDbCommand command = new OleDbCommand();
                OleDbTransaction transaction = null;

                // Set the Connection to the new OleDbConnection.
                command.Connection = myConnection;

                // Open the connection and execute the transaction.
                try
                {
                    myConnection.Open();

                    // Start a local transaction
                    transaction = myConnection.BeginTransaction();

                    // Assign transaction object for a pending local transaction.
                    command.Connection = myConnection;
                    command.Transaction = transaction;

                    // Execute the commands.
                    command.CommandText =
                        "UPDATE PlayerInfo SET Player_Wager = " + wagerAmount + " WHERE ID=" + playerId + "";
                    command.ExecuteNonQuery();

                    // Commit the transaction.
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        // Attempt to roll back the transaction.
                        transaction.Rollback();
                    }
                    catch
                    {
                        // Do nothing here; transaction is not active.
                    }
                }
                // The connection is automatically closed when the
                // code exits the using block.
            }

        }

        //This method is used to reset the PlayerInfo database table. Accepts playerId.
        public void deleteAllTableData(/*string tableName,*/int playerId)
        {
            
            using (myConnection)
            {
                OleDbCommand command = new OleDbCommand();
                OleDbTransaction transaction = null;

                // Set the Connection to the new OleDbConnection.
                command.Connection = myConnection;

                // Open the connection and execute the transaction.
                try
                {
                    myConnection.Open();

                    // Start a local transaction
                    transaction = myConnection.BeginTransaction();

                    // Assign transaction object for a pending local transaction.
                    command.Connection = myConnection;
                    command.Transaction = transaction;

                    // Execute the commands.
                    command.CommandText =
                    "UPDATE PlayerInfo SET Player_Name = null, Player_Score = 0, Player_Wager = 0 WHERE ID= " + playerId + "";
                    //"UPDATE PlayerInfo SET Player_Name='" + playerName + "'," + "Player_Score=" + playerScore + "," + "Player_Wager=" + playerWage + "," + "WHERE ID=" + playerId + "";
                    command.ExecuteNonQuery();

                    // Commit the transaction.
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        // Attempt to roll back the transaction.
                        transaction.Rollback();
                    }
                    catch
                    {
                        // Do nothing here; transaction is not active.
                    }
                }
                // The connection is automatically closed when the
                // code exits the using block.
            }
        }
        
        //This method is used to insert a player name into PlayerInfo database table. Accepts a playerId and a player name.
        public void insertPlayerName(int playerId, string playerName)
        {
            using (myConnection)
            {
                OleDbCommand command = new OleDbCommand();
                OleDbTransaction transaction = null;

                // Set the Connection to the new OleDbConnection.
                command.Connection = myConnection;

                // Open the connection and execute the transaction.
                try
                {
                    myConnection.Open();

                    // Start a local transaction
                    transaction = myConnection.BeginTransaction();

                    // Assign transaction object for a pending local transaction.
                    command.Connection = myConnection;
                    command.Transaction = transaction;

                    // Execute the commands.
                    command.CommandText =
                        "UPDATE PlayerInfo SET Player_Name = '" + playerName + "' WHERE ID=" + playerId + "";
                    command.ExecuteNonQuery();

                    // Commit the transaction.
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        // Attempt to roll back the transaction.
                        transaction.Rollback();
                    }
                    catch
                    {
                        // Do nothing here; transaction is not active.
                    }
                }
                // The connection is automatically closed when the
                // code exits the using block.
            }

        }

    }
}
