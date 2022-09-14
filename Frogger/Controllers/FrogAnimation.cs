using Microsoft.Xna.Framework;

namespace Frogger.Controllers
{
    internal class FrogAnimation
    {
        private float Slice;
        private float Current;
        private float Duration;
        private float PositionTime = 0f;
        private int CurrentIndex = 0;
        private readonly int[] Frames;
        private Vector2 Start;
        private Vector2 End;

        public bool Done { get; private set; }
        public int Frame { get => Frames[CurrentIndex]; }
        public Vector2 Position { get; private set; }

        public FrogAnimation(int[] frames, Vector2 start, Vector2 delta, float duration)
        {
            Frames = frames;
            Slice = 1f / frames.Length;
            Duration = duration;
            Start = start;
            End = start + delta;
        }

        public void Update(float deltaTime)
        {
            if (Done) { return; }

            Current += deltaTime / Duration;

            if (Current >= Slice)
            {
                Current = Current - Slice;
                CurrentIndex++;

                if (CurrentIndex == Frames.Length)
                {
                    CurrentIndex = Frames.Length - 1;
                    Position = End;
                    Done = true;
                    return;
                }
            }

            PositionTime += deltaTime / Duration;
            Position = Vector2.Lerp(Start, End, PositionTime);
        }
    }
}
