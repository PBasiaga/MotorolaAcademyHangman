using System;
using System.Diagnostics;
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
        private Stopwatch stopwatch;


        public Controller()
        {
            view = new View();
            stopwatch = new Stopwatch();
        }
        
        public void Start()
        {
            view.ShowStartingScreen();
            PlayGame();

        }

        private void PlayGame()
        {
            InitializeGame();
            stopwatch.Start();
            while (!game.IsGameFinished)
            {
                view.ShowHangmanArt(player.LifePoints);
                view.ShowUsedLetters(game.LettersNotInWord);
                view.ShowBoard(game.Board);
                view.ShowRemainingLifePoints(player.LifePoints);
                game.Answer = view.AskForInput().ToUpper();
                player.GuessingTries++;
                CheckAnswer();
                CheckIfGameOver();
            }
            stopwatch.Stop();
            CheckGameOutcome();
            CheckIfPlayAgain(view.AskIfPlayAgain());
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
        
        private void CheckIfGameOver()
        {
            if (player.LifePoints <= 0 || !game.Board.Contains('_'))
            {
                game.IsGameFinished = true;
            }
        }
        
        private void CheckIfPlayAgain(bool playAgain)
        {
            if (playAgain)
                PlayGame();
        }
        
        private void CheckGameOutcome()
        {
            if (player.LifePoints > 0)
            {
                TimeSpan timeSpan = stopwatch.Elapsed;
                player.GuessingTime = timeSpan.Seconds;
                view.ShowYouWinScreen(game.Password, game.Hint, player.GuessingTries, player.LifePoints, player.GuessingTime);
            }
            else
            {
                view.ShowGameOverScreen(game.Password);
            }
        }
    }
}