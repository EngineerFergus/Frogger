using Frogger.Components;
using Frogger.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Frogger
{
    public class FroggerGame : Game
    {
        private GraphicsDeviceManager _graphics;
        //private SpriteBatch _spriteBatch;

        public FroggerGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 224 * 2;
            _graphics.PreferredBackBufferHeight = 256 * 2;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            StateComponent stateComponent = new(this);
            GameState gameState = new GameState(stateComponent.Machine);
            stateComponent.Machine.Add("game", gameState);

            // TODO: Add all remaining states

            stateComponent.Machine.Change("game");
            Components.Add(stateComponent);

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}