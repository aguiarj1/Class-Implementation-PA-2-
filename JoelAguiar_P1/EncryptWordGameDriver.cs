// AUTHOR: Joel Aguiar 
// FILENAME: EncryptWordGameDriver.cs
// DATE: April 29, 2018
// REVISION HISTORY: Second Draft 
// REFERENCES (optional): not applicable 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JoelAguiar_P1
{
    //EncryptWordGameDriver Class 
    //Overview: EncryptWordGameDriver uses an EncryptWord object to play a game where the user
    //          tries to figure out what the shift value is. The game keeps track of the 
    //          statistics of the game. 
    //functionality: The functionality of this class includes using EncryptWord class to 
    //          encrypt a word and guess what the shift value is. It also tracks and displays
    //          statistics related to the game. 
    //legal states: there are no illegal states. 
    //dependencies: this method depends on some of the public mehtods from EncryptWord. 
    //anticipated use: to provide the game functionality 
    //data processed: A string is processed when the constructor is called.  
    //legal input & illegal input: the word should be more than 3 characters. 
    //Output: statistics of the game get outputed using getStatistics method 
    class EncryptWordGameDriver
    {
        //variables that keep track of statistics of the game
        private int sumOfAllGuesses;
        private int numOfHighGuesses;
        private int numOfCorrectGuesses;
        private int numOfLowGuesses;
        private EncryptWord game; //used to encrypt a word
        private string encryptedWord; //stores the encrypted word

        // Description: It is the constructor and it accepts a word as an argument. 
        // preconditions: none
        // postconditions:  game and encryptedWord have values. 
        public EncryptWordGameDriver(string word)
        {
            //puts objects in proper initial state
            game = new EncryptWord();
            try {
                encryptedWord = game.passWord(word);
            } catch (Exception ex)
            {
                //terminate program with error message if exception thrown 
                Console.WriteLine("ERROR: " + ex.Message + ". Program ended.");
                Console.ReadLine();
                System.Environment.Exit(0);
            }
            
            sumOfAllGuesses = 0;
            numOfHighGuesses = 0;
            numOfLowGuesses = 0;
            numOfCorrectGuesses = 0; 
        }

        // Description: This method returns the encrypted word. 
        // preconditions: none
        // postconditions:  none 
        public string getEncryptedWord()
        {
            return encryptedWord;  
        }

        // Description: This method takes in an int parameter and returns true if it matches 
        //              the cesar cipher shift value, false otherwise.  
        // preconditions: none
        // postconditions:  none
        public int guessCesarCipherShift(int guessedNum)
        {
            sumOfAllGuesses += guessedNum; 
            int result = game.query(guessedNum);
            if(result == 0)
            {
                numOfCorrectGuesses++; 
            } else if(result == -1)
            {
                numOfLowGuesses++; 
            } else
            {
                numOfHighGuesses++; 
            }
            return result; 
        }

        // Description: This method returns the statistics of the game like
        // number of queries, high guesses, low guesses and average guess value. 
        // preconditions: none
        // postconditions:  none
        public string getStatistics()
        {
            string stats; 
            if((numOfLowGuesses + numOfHighGuesses + numOfCorrectGuesses) != 0) { 
                stats = "Number of queries " + (numOfCorrectGuesses + numOfHighGuesses + numOfLowGuesses) +
                    "\n" + "High guesses: " + numOfHighGuesses + "\n" + "Low guesses: " + numOfLowGuesses + "\n" +
                    "Average value: " + (sumOfAllGuesses/(numOfLowGuesses + numOfHighGuesses + numOfCorrectGuesses)) + 
                    "\n";
            } else
            {
                stats = "No data to display" + "\n"; 
            }
            return stats; 
        }
    }
}
