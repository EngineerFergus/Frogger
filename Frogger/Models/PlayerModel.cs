using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Frogger.Models
{
    internal class PlayerModel
    {
        public int Lives { get; set; }
        public float Time { get; set; }
        public int Score { get; set; }
        public int HiScore { get; set; }
        public int Goals { get; set; }
        public Vector2 Position { get; set; }
        public int Frame { get; set; }
        public SpriteEffects Flip { get; set; }

        public PlayerModel()
        {
            Lives = 4;
            Time = 60f;
            HiScore = 10_000;
            Score = 0;
            Frame = 34;
            Position = new Vector2((16 * 7), 224);
            Flip = SpriteEffects.None;
        }

        public void ResetAfterLevel()
        {
            Goals = 0;
            Time = 60f;
            Position = new Vector2((16 * 7), 224);
        }
    }
}
