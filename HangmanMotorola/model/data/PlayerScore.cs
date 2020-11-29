namespace HangmanMotorola.model.data
{
    public class PlayerScore
    {
        private string name;
        
        private string lifePoints;

        private string guessingTime;

        private string guessingTries;

        private string guessedPassword;

        private string dateOfPlay;
        
        public string Name
        {
            get;
            set;
        }

        public string LifePoints
        {
            get;
            set;
        }

        public string GuessingTime
        {
            get;
            set;
        }

        public string GuessingTries
        {
            get;
            set;
        }

        public string GuessedPassword
        {
            get;
            set;
        }

        public string DateOfPlay
        {
            get;
            set;
        }
    }
}