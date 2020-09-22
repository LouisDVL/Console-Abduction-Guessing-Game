using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Spaceman
{
    class Game
    {
        //Fields
        private string codeWord;
        private string currentWord;
        private int numberOfGuess;
        private int wrongGuess;
        private string[] possibleWords = new string[] { "chicken", "fox", "lion", "telescope", "alien", "stop", "abduction", "martian" };
        private Ufo ufo = new Ufo();
        public ArrayList previousAnswer = new ArrayList();

        //Property
        public string CurrentWord
        {
            get 
            { 
                return currentWord; 
            }
            set 
            { 
                this.currentWord = value;
            }
        }

        //Constructor
        public Game()
        {
            var rand = new Random();
            string pickedWord = possibleWords[rand.Next(possibleWords.Length)];
            this.codeWord = pickedWord;
            this.numberOfGuess = 5;
            this.wrongGuess = 0;
            this.currentWord = CurrentWordMaker("_", pickedWord.Length);
        }

        //Method
        public void Greet()
        {
          Console.WriteLine("Welcome to the Spaceman Game, Good Luck!");
        }

        private string CurrentWordMaker(string ch, int toRepeat)
        {
            string returnValue = "";
            for(int i = 0; i < toRepeat; i++)
            {
                returnValue = returnValue + ch;
            }

            return returnValue;
        }

        private string CurrentWordMaker(string word)
        {
            string returnValue = "";
            for (int i = 0; i < word.Length; i++)
            {
                returnValue = returnValue + $"{word[i]} ";
            }

            return returnValue;
        }

        public bool DidWin()
        {
            return this.codeWord.Equals(this.currentWord);
        }

         public bool DidLose()
        {
             return (numberOfGuess == wrongGuess);
        }

        public void Display()
        {
            Console.WriteLine(this.codeWord);
            Console.WriteLine(ufo.Stringify());
            Console.WriteLine(CurrentWordMaker(this.CurrentWord));
            Console.WriteLine($"Guesses remaining: {numberOfGuess - wrongGuess}");
            Console.WriteLine($"Wrong guesses: {displayPrevious()}");
        }

        public void Ask()
        {
            Console.WriteLine("Please guess a character: ");
            string guessedChar = Console.ReadLine();
            while(guessedChar.Length != 1)
            {
                Console.WriteLine("Please just enter one character: ");
                guessedChar = Console.ReadLine();
            }

            if(this.codeWord.Contains(guessedChar))
            {
                updateCurrentWord(Convert.ToChar(guessedChar));
            } 
            else
            {
                this.previousAnswer.Add(guessedChar);
                ufo.AddPart();
                this.wrongGuess++;
            }
        }

        public string displayPrevious()
        {
            string returnValue = "";
            foreach(string ch in this.previousAnswer)
            {
                returnValue += $"{ch} ";
            }
            return returnValue;
        }

        private void updateCurrentWord(char ch)
        {
            StringBuilder stringB = new StringBuilder(this.CurrentWord);
            for (int i = 0; i < this.codeWord.Length; i++)
            {
                if (ch == this.codeWord[i])
                {
                    stringB[i] = ch;
                }
            }
            this.CurrentWord = stringB.ToString();

        }

    }
}