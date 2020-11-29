using System.Linq;
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
                view.ShowBoard(game.Board);
                view.ShowRemainingLifePoints(player.LifePoints);
                game.Answer = view.AskForInput().ToUpper();
                player.GuessingTries++;
                CheckAnswer();
                //check if gameover
            }
            //check outcome
            //ask if play again
        }
        
        private void InitializeGame()
        {
            player = new Player();
            game = new Game();
        }
        
        private void CheckAnswer()
        {
            if (game.Answer.Length == 0)
            {
                view.ShowEmptyAnswerInfo();
            }
            else if (game.Answer.Length == 1)
            {
                CheckOneLetterAnswer();
            }
            else
            {
                CheckFullWordAnswer();
            }
        }
        
        private void CheckFullWordAnswer()
        {
            if (game.Answer.Equals(game.Password))
            {
                game.IsGameFinished = true;
            }
            else
            {
                player.LifePoints -= 2;
                view.ShowWrongPasswordInfo();
            }
        }
        
        private void CheckOneLetterAnswer()
        {
            var character = game.Answer.ToUpper()[0];
            
            if (char.IsLetter(character))
            {
                if (game.GuessedLetters.Contains(character) || game.LettersNotInWord.Contains(character))
                {
                    view.ShowAlreadyGuessedInfo();
                }
                else if (game.Password.Contains(character))
                {
                    game.PutLettersInBoard(character);
                    game.GuessedLetters.Add(character);
                    view.ShowCorrectLetterInfo();
                }
                else
                {
                    game.LettersNotInWord.Add(character);
                    player.LifePoints -= 1;
                    view.ShowWrongLetterInfo();
                }
            }
            else
            {
                view.ShowMustBeALetterInfo();
            }
        }
    }
}