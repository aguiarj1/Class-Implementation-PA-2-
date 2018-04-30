// AUTHOR: Joel Aguiar 
// FILENAME: EncryptWord.cs
// DATE: April 29, 2018
// REVISION HISTORY: Second Draft 
// REFERENCES (optional): not applicable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JoelAguiar_P1
{
    //EncryptWord Class 
    //Overview: EncryptWord can take a word and do a cesar cipher shift by a constant value. 
    //          In other words, it shifts all the letters right by the shift value. 
    //functionality: The main functionality is making the encrypted word by shifting the 
    //          characters value and also it can check whether you guessed the shift value
    //          correclty. 
    //legal states: EncryptWord object must be "on" when calling query or reset. 
    //dependencies: no dependancies 
    //anticipated use: to provide a basic "encryption" based on cesar cipher shift.  
    //data processed: A string is processed when the passWord is called.  
    //legal input & illegal input: the word should be more than 4 characters. 
    //Output: the encypted word is passed when passWord is used.  
    class EncryptWord
    {
        private const int cesarCipherShift = 4;   
        private bool on;
        private string word;

        // Description: It is the constructor and it doesn't accept any arguments. 
        // preconditions: none
        // postconditions: on is false or in other words it is "off". This means that
        //          word is blank. 
        public EncryptWord()
        {
            //puts object in proper initial state
            reset();  
        }

        // Description: This method takes in as a parameter one word to be saved and returns the 
        // encrypted word. It also makes sure it is over 4 character long.  
        // preconditions: on must be false
        // postconditions: on will be true
        public string passWord(string passedWord)
        {
            //if passdWord is less than 4 char long throw an error
            if ( passedWord.Length < 4)
            {
                throw new System.ArgumentException("Word cannot be less than 4 characters long ", passedWord);
            }
            word = passedWord; 
            on = true;
            var chars = passedWord.ToCharArray(); //convert word to char 
            string encryptedWord = "";  //initialize encryptedWord to empty string
            //add the shifted characters to the encryptedWord
            for (int ctr = 0; ctr < chars.Length; ctr++)
            {
                encryptedWord += Convert.ToChar(((int)chars[ctr]) + cesarCipherShift); 
            }
            return encryptedWord; 
        }

        // Description: This method takes in as a parameter an int that represents 
        // a guess of the shift value. It returns 0 if correct, -1 if guess is too small
        // or 1 if guess is too big.
        // preconditions: on must be true
        // postconditions: same  
        public int query(int guess)
        {
            int result; 
            if(cesarCipherShift == guess)
            {
                result = 0; 
            } else if (cesarCipherShift > guess)
            {
                result = -1; 
            } else
            {
                result = 1;
            }
            return result;  
        }

        // Description: This method checks whether the state is currently on or off.
        //              It should help the application programmer maintain valid state. 
        // preconditions: none
        // postconditions: none
        public bool checkOn()
        {
            return on;
        }

        // Description: This method resets the state to off and word to blank word.
        // preconditions: on must be true
        // postconditions: on will be false 
        public void reset()
        {
            on = false;
            word = "";
        }

    }
}
