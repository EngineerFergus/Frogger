namespace Frogger.Controllers
{
    internal class Cooldown
    {
        private readonly float Duration;
        private float Current = 1f;

        public bool Complete { get; private set; }

        public Cooldown(float duration)
        {
            Duration = duration;
            Complete = false;
        }

        public void Update(float deltaTime)
        {
            if (Complete) { return; }
            Current -= deltaTime / Duration;

            if (Current <= 0f)
            {
                Complete = true;
            }
        }
    }
}
