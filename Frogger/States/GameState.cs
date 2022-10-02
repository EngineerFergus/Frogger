using Frogger.Controllers;
using Frogger.Factories;
using Frogger.FSM;
using Frogger.Models;
using Frogger.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Collections.Specialized;

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
        private readonly DebugView Debugger;

        private VehicleRowModel DuneBuggyRowModel;

        public GameState(StateMachine stateMachine) : base(stateMachine)
        {
            Screen = new RenderTarget2D(stateMachine.CurrentGame.GraphicsDevice, 224, 256);
            Sprites = new SpriteBatch(stateMachine.CurrentGame.GraphicsDevice);

            Player = new PlayerModel();
            GoalContainerModel goals = new();

            Debugger = new DebugView(stateMachine.CurrentGame.Content, Sprites);


            Views.Add(new BackgroundView(stateMachine.CurrentGame.Content, Sprites));
            Views.Add(new ScoreView(stateMachine.CurrentGame.Content, Sprites, Player));
            Views.Add(new PlayerView(stateMachine.CurrentGame.Content, Sprites, Player));
            Views.Add(new FrogPositionView(stateMachine.CurrentGame.Content, Sprites, Player));
            Views.Add(new GoalView(stateMachine.CurrentGame.Content, Sprites, goals));
            Views.Add(Debugger);

            //Debugger.AddOrUpdateRect("river", new Rectangle(0, 48, 244, 80), new Color(Color.Red, 0.25f));

            PlayerController playerController = new(Player);

            Controllers.Add(playerController);
            Controllers.Add(new GoalController(Player, goals, playerController));
            Controllers.Add(new HomeAnimationController(goals));

            var bulldozerRowModel = new VehicleRowModel(BulldozerFactory.CreateFirstStage(), pixelsPerSecond: 32f);
            var racingCarRowModel = new VehicleRowModel(RacingCarFactory.CreateFirstStage(), 0, 128f, 2f, VehicleGhost.NoGhost);
            var sedanCarRowModel = new VehicleRowModel(GenericCarFactory.CreateFirstStage(), 0, 32f, 0f, VehicleGhost.Ghost, VehicleDirection.RightToLeft);
            DuneBuggyRowModel = new VehicleRowModel(GenericCarFactory.CreateFirstStage(y: 208, frame: 9), 0, 32f, 0f, VehicleGhost.Ghost, VehicleDirection.RightToLeft);
            var truckRowModel = new VehicleRowModel(TruckFactory.CreateFirstStage(), 0, 36, 0, VehicleGhost.Ghost, VehicleDirection.RightToLeft);

            var vehicleContoller = new VehicleController(Player, playerController, new VehicleRowModel[]
            {
                bulldozerRowModel,
                racingCarRowModel,
                sedanCarRowModel,
                DuneBuggyRowModel,
                truckRowModel
            });

            var vehicleView = new VehicleView(stateMachine.CurrentGame.Content, Sprites, new VehicleRowModel[]
            {
                bulldozerRowModel,
                racingCarRowModel,
                sedanCarRowModel,
                DuneBuggyRowModel,
                truckRowModel
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

            //int count = 0;

            //foreach (var model in DuneBuggyRowModel.Vehicles)
            //{
            //    var xl = model.Position + DuneBuggyRowModel.OffsetLeft;
            //    var xr = model.Position + DuneBuggyRowModel.OffsetRight;
            //
            //    Rectangle rR = new Rectangle((int)xr.X, (int)xr.Y, 16, 16);
            //    Rectangle rL = new Rectangle((int)xl.X, (int)xl.Y, 16, 16);
            //
            //    Debugger.AddOrUpdateRect($"car{count}", rR, Color.Purple);
            //    Debugger.AddOrUpdateRect($"ghost{count}", rL, Color.Blue);
            //
            //    count++;
            //}
        }
    }
}
