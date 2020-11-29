using System.Collections.Generic;
using HangmanMotorola.model.data;
using HangmanMotorola.view;

namespace HangmanMotorola.controller
{
    public class Controller
    {
        private View view;
        private Player player;
        private Game game;


        public Controller()
        {
            view = new View();
        }
        
        public void Start()
        {
            view.ShowStartingScreen();
            PlayGame();

        }

        private void PlayGame()
        {
            InitializeGame();
            while (!game.IsGameFinished)
            {
                
            }
        }
        
        private void InitializeGame()
        {
            player = new Player();
            game = new Game();
        }
    }
}