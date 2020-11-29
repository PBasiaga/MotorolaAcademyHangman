using System;
using System.Collections.Generic;
using System.IO;
using HangmanMotorola.model.data;

namespace HangmanMotorola.model.logic
{
    public class FileReaderWriter
    {
        
        private const string passwordsAndHintsFile =
            "D:/Programowanie/backEnd/C# - programowanie/MotorolaAcademyTask/HangmanMotorola/HangmanMotorola/resources/countries_and_capitals.txt";
        
        private const string hangmanArtFile = 
            "D:/Programowanie/backEnd/C# - programowanie/MotorolaAcademyTask/HangmanMotorola/HangmanMotorola/resources/hangman_art.txt";
        private const string highscoresFile = 
            "D:/Programowanie/backEnd/C# - programowanie/MotorolaAcademyTask/HangmanMotorola/HangmanMotorola/resources/highscores.txt";
        
        private Random random = new Random();
        
        public void GetRandomPasswordAndHint(out string password, out string hint)
        {
            string[] lines = File.ReadAllLines(passwordsAndHintsFile);
          
            int randomNumber = random.Next(0, lines.Length - 1);

            string randomLine = lines[randomNumber];

            string[] passwordAndHint = randomLine.Split('|');

            password = passwordAndHint[1].Trim().ToUpper();
            hint = passwordAndHint[0].Trim().ToUpper();
        }
        
        public string[] GetHangmanArt()
        {
            string allHangmanParts = File.ReadAllText(hangmanArtFile);

            string[] hangmanInParts = allHangmanParts.Split(',');

            return hangmanInParts;
        }
        
        public void SaveHighScores(List<PlayerScore> highScores)
        {
            if (highScores.Count > 10)
            {
                highScores.RemoveAt(10);
            }
            TextWriter textWriter = new StreamWriter(highscoresFile);
            foreach (var score in highScores)
            {
                textWriter.WriteLine(score.Name+"|"+score.DateOfPlay+"|"+score.GuessingTime+"|"+score.GuessingTries+"|"+score.LifePoints+"|"+score.GuessedPassword);
            }
            textWriter.Close();

        }
    }
}