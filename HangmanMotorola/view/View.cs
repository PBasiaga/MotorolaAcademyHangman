using System;

namespace HangmanMotorola.view
{
    public class View
    {
        public void ShowBoard(char[] board)
        {
            Console.WriteLine("\n");
            foreach (var letter in board)
            {
                Console.Write(letter + " ");
            }
            Console.WriteLine("\n");
        }
    }
}