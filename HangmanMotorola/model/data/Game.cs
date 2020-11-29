using System;
using System.Collections.Generic;

namespace HangmanMotorola.model.data
{
    public class Game
    {

        private bool isGameFinished;
        private string password;
        private string hint;
        private List<Char> guessedLetters;
        private List<Char> lettersNotInWord;
        private char[] board;
        private string answer;

        public Game()
        {
            IsGameFinished = false;
            GuessedLetters = new List<char>();
            LettersNotInWord = new List<char>();
        }

        public bool IsGameFinished
        {
            get; set;
        }

        public string Password
        {
            get; set;
        }

        public string Hint
        {
            get; set;
        }

        public List<char> GuessedLetters
        {
            get; set;
        }

        public List<char> LettersNotInWord
        {
            get; set;
        }

        public char[] Board
        {
            get; set;
        }

        public string Answer
        {
            get; set;
        }
        
        
    }
}