using System;

namespace HangmanMotorola.view
{
    public class View
    {
        
        public void ShowStartingScreen()
        {
            Console.WriteLine("\nWelcome to the Hangman game! \n" +
                              "Guess hidden word to win the game! \n" +
                              "Password is chosen randomly, but it's always a capital of a country. \n" +
                              "Before guessing, choose whether you want to guess a letter or a whole word. \n" +
                              "Be careful, you have 5 lifepoints, guessing wrong will cost you some of them! \n" +
                              "Guess quickly and you might join the leaderboard! Good Luck! \n \n" +
                              "Press any key to continue.");
            System.Console.ReadKey();
            Console.Clear();
            
        }
        
        public void ShowBoard(char[] board)
        {
            Console.WriteLine("\n");
            foreach (var letter in board)
            {
                Console.Write(letter + " ");
            }
            Console.WriteLine("\n");
        }
        
        public string AskForInput()
        {
            Console.WriteLine("Enter a letter or word: \n");
            return Console.ReadLine();
        }
    }
}