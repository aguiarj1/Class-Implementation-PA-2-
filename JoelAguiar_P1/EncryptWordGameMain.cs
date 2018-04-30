// AUTHOR: Joel Aguiar 
// FILENAME: EncryptWordGameMain.cs
// DATE: April 29, 2018
// REVISION HISTORY: Second Draft 
// REFERENCES (optional): not applicable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JoelAguiar_P1
{
    //EncryptWordGameMain Class 
    //Overview: EncryptWordGameMain class provides the input/output logic for a basic encryptword game.  
    //functionality: This class provides several prompts and messages to help the user play 
    //              the game. When the game is over it prints the statistics of the game, and asks
    //              the user whether he/she wants to play again. 
    //legal states: it doesn't have illegal states.  
    //dependencies: It depends on EncryptWordGameDriver for its functionality. 
    //anticipated use: to play a simple game.   
    //data processed: none 
    //legal input & illegal input: the word should be more than 3 characters. When prompted to
    //              guess the shift value the input should be an integer. 
    //Output: the output will be whether the user guessed the shift value correctly or not and also 
    //              the statistics of the game. 
    class EncryptWordGameMain
    {
        // Description: This method calls several other methods to play the game.  
        // preconditions: none
        // postconditions: none 
        static void Main(string[] args)
        {
            Console.WriteLine(welcome());
            playGame();  
            Console.WriteLine(goodbye()); 
            Console.ReadLine();

        }
        // Description: This method returns a welcome message. 
        // preconditions: none
        // postconditions: none
        private static string welcome()
        {
            string welcomeMessage = "Welcome to the EncryptWord game! This game lets you guess\n" +
                "the shift value of the encrypted word.\n";
            return welcomeMessage; 
        }
        // Description: This method is the main method that determines input and output 
        //              logic for the game. It uses the EncryptWordGameDriver class.  
        // preconditions: none
        // postconditions: none
        private static void playGame()
        {
            string playAgain; //determines whether to play another time. 
            string wordProvided; //word provided by user
            int guessOfCesarCipherShift; //guess of cesar cipher shift 
            do
            {
                Console.Write("Please provide a word to be encrypted: ");
                wordProvided = Console.ReadLine();
                EncryptWordGameDriver currentGame = new EncryptWordGameDriver(wordProvided);
                Console.Write("The encrypted version of the word is: ");
                Console.WriteLine(currentGame.getEncryptedWord());
                bool keepGuessing = true; //when guess is correct keepGuessing is false 
                string numGuessed; //number guessed 
                do
                {
                    Console.Write("Can you guess the cesar cipher shift value? " +
                        "(guess number or leave blank to quit guessing): ");
                    numGuessed = Console.ReadLine();
                    //check to make sure it is a valid integer input
                    while (!numGuessed.All(Char.IsDigit))
                    {
                        Console.Write("\nINVALID INPUT: Please guess a valid integer: ");
                        numGuessed = Console.ReadLine();
                    }
                    //if blank, user does not want to keep on guessing. Will end game.
                    if (numGuessed == "")
                    {
                        keepGuessing = false;
                    }
                    else
                    {
                        int.TryParse(numGuessed, out guessOfCesarCipherShift);
                        //resultOfQuery holds int value of flag whether guess was correct. 
                        int resultOfQuery = currentGame.guessCesarCipherShift(guessOfCesarCipherShift);
                        if (resultOfQuery == 0)
                        {
                            Console.WriteLine("Correct!");
                            keepGuessing = false;
                        }
                        else if (resultOfQuery > 0)
                        {
                            Console.WriteLine("Incorrect! Your guess is to high.");
                        } else
                        {
                            Console.WriteLine("Incorrect! Your guess is to low.");
                        }
                    }

                } while (keepGuessing);
                Console.Write(currentGame.getStatistics());
                Console.WriteLine("Do you want to play again?(y/n)");
                playAgain = Console.ReadLine();
            } while (playAgain == "y");
        }

        // Description: This method returns a goodbye message. 
        // preconditions: none
        // postconditions: none
        private static string goodbye()
        {
            string goodbyeMessage = "\nThank you for playing!\n";
            return goodbyeMessage;
        }
    }
}
