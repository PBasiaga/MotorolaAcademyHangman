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

            hint = passwordAndHint[0].Trim().ToUpper();
            
            password = passwordAndHint[1].Trim().ToUpper();

            bool hasWhitespace = false;
            
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i].Equals(' '))
                {
                    hasWhitespace = true;
                }
            }

            if (hasWhitespace)
            {
                password = password.Replace(" ", "");
            }
            
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
                for (int i = (highScores.Count - 1); i >= 10; i--)
                {
                    highScores.RemoveAt(i);
                }
            }
            TextWriter textWriter = new StreamWriter(highscoresFile);
            foreach (var score in highScores)
            {
                textWriter.WriteLine(score.Name+"|"+score.DateOfPlay+"|"+score.GuessingTime+"|"+score.GuessingTries+"|"+score.LifePoints+"|"+score.GuessedPassword);
            }
            textWriter.Close();

        }
        
        public List<PlayerScore> GetHighScores()
        {
            List<PlayerScore> playersScores = new List<PlayerScore>();
            PlayerScore playerScore;

            string[] allLines = File.ReadAllLines(highscoresFile);
            
            foreach (string line in allLines)
            {
                string[] playerData = line.Split('|');
                playerScore = new PlayerScore();
                playerScore.Name = playerData[0];
                playerScore.DateOfPlay = playerData[1];
                playerScore.GuessingTime = playerData[2];
                playerScore.GuessingTries = playerData[3];
                playerScore.LifePoints = playerData[4];
                playerScore.GuessedPassword = playerData[5];
                playersScores.Add(playerScore);
            }
            return playersScores;
        }
    }
}