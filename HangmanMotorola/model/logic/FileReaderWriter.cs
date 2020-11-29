using System;
using System.IO;

namespace HangmanMotorola.model.logic
{
    public class FileReaderWriter
    {
        
        private const string passwordsAndHintsFile =
            "D:/Programowanie/backEnd/C# - programowanie/MotorolaAcademyTask/HangmanMotorola/HangmanMotorola/resources/countries_and_capitals.txt";
        
        private const string hangmanArtFile = 
            "D:/Programowanie/backEnd/C# - programowanie/MotorolaAcademyTask/HangmanMotorola/HangmanMotorola/resources/hangman_art.txt";
        
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
    }
}