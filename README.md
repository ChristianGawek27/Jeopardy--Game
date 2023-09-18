# Jeopardy Game
This a mock Jeopardy Game that was modeled after the original game.  The game was designed to be a two person game. This project was completed during my time at Temple University, where I completed the game with another student.
The Jeopardy game was done in C# and was where I got to put a lot of C# practice to use.

# Getting Started
This game was created using Forms in Windows.  There is no setup for the game, the only requirement is to run the game the user would have to be using a Windows computer, or a Windows Operating System.

# Program Flow
* Two people will select a user name, where they can choose their name.
* Player 1 will alwasy go first through the categories.  If the player gets an answer wrong then they will get the category points deducted from their score and player two will answer.  If player two gets the answer wrong, they will get points deducted.
* Once all questions are answered for the first round, the second round will begin with the score for each category being doubled from the first.
* The rules for the second round are the same as the first.
* After the second round there will be final jeopardy with a timer.  The user can wage how much they want to bet and if correct that total is added to the user and stored in the DB.  If wrong it is subtracted.
* Once the game is done, the players will have to reset the game in order to play again.  

# Authors
* Christian Gawek
* Shawn Gabel

#Technologies Used
* C#
* HTML
* CSS
* Microsoft Access DB

# Future Work
* Taking the game from Microsoft forms and either converting it to ASP.Net, or using a JS framework to build out the application
* Using a different Database to store the information.  Microsoft Access is not really a DB, but was used for the class to simplfy the project.
* Writing Unit tests to make sure that all code functions as it should.


