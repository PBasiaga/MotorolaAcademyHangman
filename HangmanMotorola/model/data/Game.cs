using System;
using System.Collections.Generic;
using HangmanMotorola.model.logic;

namespace HangmanMotorola.model.data
{
    public class Game
    {

        private FileReaderWriter fileReader = new FileReaderWriter();
        
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
            SetPasswordAndHint();
            SetBoard();
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
        
        private void SetPasswordAndHint()
        {
            string tempPassword;
            string tempHint;
            fileReader.GetRandomPasswordAndHint(out tempPassword, out tempHint);
            Password = tempPassword;
            Hint = tempHint;
        }
        
        private void SetBoard()
        {
            Board = new char[Password.Length];
            for (int i = 0; i < Password.Length; i++)
            {
                Board[i] = '_';
            }
        }
        
        public void PutLettersInBoard(char letter)
        {
            for (int i = 0; i < Password.Length; i++)
            {
                if (letter.Equals(Password[i]))
                {
                    Board[i] = letter;
                }
            }
        }
        
    }
}