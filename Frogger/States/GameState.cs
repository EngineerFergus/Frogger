using Frogger.Controllers;
using Frogger.Factories;
using Frogger.FSM;
using Frogger.Models;
using Frogger.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Frogger.States
{
    internal class GameState : BaseState
    {
        private static readonly int Scale = 2;

        private readonly List<BaseView> Views = new List<BaseView>();
        private readonly List<IController> Controllers = new List<IController>();
        private readonly SpriteBatch Sprites;
        private readonly RenderTarget2D Screen;
        private readonly PlayerModel Player;

        public GameState(StateMachine stateMachine) : base(stateMachine)
        {
            Screen = new RenderTarget2D(stateMachine.CurrentGame.GraphicsDevice, 224, 256);
            Sprites = new SpriteBatch(stateMachine.CurrentGame.GraphicsDevice);

            Player = new PlayerModel();
            GoalContainerModel goals = new();

            Views.Add(new BackgroundView(stateMachine.CurrentGame.Content, Sprites));
            Views.Add(new ScoreView(stateMachine.CurrentGame.Content, Sprites, Player));
            Views.Add(new PlayerView(stateMachine.CurrentGame.Content, Sprites, Player));
            Views.Add(new FrogPositionView(stateMachine.CurrentGame.Content, Sprites, Player));
            Views.Add(new GoalView(stateMachine.CurrentGame.Content, Sprites, goals));

            PlayerController playerController = new(Player);

            Controllers.Add(playerController);
            Controllers.Add(new GoalController(Player, goals, playerController));
            Controllers.Add(new HomeAnimationController(goals));

            var bulldozerRowModel = new VehicleRowModel(BulldozerFactory.CreateFirstStage(), pixelsPerSecond: 32f);
            var racingCarRowModel = new VehicleRowModel(RacingCarFactory.CreateFirstStage(), 0, 128f,  ghost: VehicleGhost.NoGhost, coolDownPeriod: 2f);
            var sedanCarRowModel = new VehicleRowModel(SedanCarFactory.CreateFirstStage(), 0, 32f, direction: VehicleDirection.RightToLeft);
            var sedanCarRowModel2 = new VehicleRowModel(SedanCarFactory.CreateFirstStage(-8, 208), 0, 32f, direction: VehicleDirection.RightToLeft);
            var sedanCarRowModel3 = new VehicleRowModel(SedanCarFactory.CreateFirstStage(-12, 144), 0, 32f, direction: VehicleDirection.RightToLeft);

            var vehicleContoller = new VehicleController(Player, playerController, new VehicleRowModel[]
            {
                bulldozerRowModel,
                racingCarRowModel,
                sedanCarRowModel,
                sedanCarRowModel2,
                sedanCarRowModel3
            });

            var vehicleView = new VehicleView(stateMachine.CurrentGame.Content, Sprites, new VehicleRowModel[]
            {
                bulldozerRowModel,
                racingCarRowModel,
                sedanCarRowModel,
                sedanCarRowModel2,
                sedanCarRowModel3
            });

            Views.Add(vehicleView);
            Controllers.Add(vehicleContoller);
        }

        public override void Draw()
        {
            Machine.CurrentGame.GraphicsDevice.SetRenderTarget(Screen);
            Machine.CurrentGame.GraphicsDevice.Clear(Color.Black);

            Sprites.Begin();

            foreach (var view in Views)
            {
                view.Draw();
            }

            Sprites.End();

            Machine.CurrentGame.GraphicsDevice.SetRenderTarget(null);

            Sprites.Begin();
            Sprites.Draw(Screen, new Rectangle(0, 0, 224 * Scale, 256 * Scale), Color.White);
            Sprites.End();
        }

        public override void Enter()
        {

        }

        public override void Exit()
        {

        }

        public override void Update(float deltaTime)
        {
            foreach(var controller in Controllers)
            {
                controller.Update(deltaTime);
            }
        }
    }
}
