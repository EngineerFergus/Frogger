namespace Frogger.Models
{
    internal class PlayerModel
    {
        public int Lives { get; set; }
        public float Time { get; set; }
        public int Score { get; set; }
        public int HiScore { get; set; }

        public PlayerModel()
        {
            Lives = 4;
            Time = 60f;
            HiScore = 12345;
            Score = 0;
        }
    }
}
