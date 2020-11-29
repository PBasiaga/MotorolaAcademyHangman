namespace HangmanMotorola.model.data
{
    public class Player
    {
        private string name;
        
        private int lifePoints;

        private int guessingTime;

        private int guessingTries;

        public Player()
        {
            LifePoints = 5;
            GuessingTime = 0;
            GuessingTries = 0;
        }

        public string Name
        {
            get; set;
        }

        public int LifePoints
        {
            get; set;
        }

        public int GuessingTime
        {
            get; set;
        }

        public int GuessingTries
        {
            get; set;
        }
        

        public string DateOfPlay
        {
            get; set;
        }
    }
}