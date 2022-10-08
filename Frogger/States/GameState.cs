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

        private List<BaseView> Views = new List<BaseView>();
        private List<IController> Controllers = new List<IController>();
        private SpriteBatch Sprites;
        private RenderTarget2D Screen;
        private PlayerModel Player;
        private DebugView Debugger;
        private RiverRowModel[] RiverModels;

        private VehicleRowModel DuneBuggyRowModel;

        public GameState(StateMachine stateMachine) : base(stateMachine)
        {
            
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

        public override void Enter(params object[] args)
        {
            Screen = new RenderTarget2D(Machine.CurrentGame.GraphicsDevice, 224, 256);
            Sprites = new SpriteBatch(Machine.CurrentGame.GraphicsDevice);

            bool resetForNewGame = true;
            if (args.Length > 0 && args[0] is bool)
            {
                resetForNewGame = (bool)args[0];
            }

            if (resetForNewGame)
            {
                Player = new PlayerModel();
            }
            else
            {
                Player.ResetAfterLevel();
            }

            GoalContainerModel goals = new();

            Debugger = new DebugView(Machine.CurrentGame.Content, Sprites);


            Views.Add(new BackgroundView(Machine.CurrentGame.Content, Sprites));
            Views.Add(new ScoreView(Machine.CurrentGame.Content, Sprites, Player));
            Views.Add(new FrogPositionView(Machine.CurrentGame.Content, Sprites, Player));
            Views.Add(new GoalView(Machine.CurrentGame.Content, Sprites, goals));
            Views.Add(Debugger);

            //Debugger.AddOrUpdateRect("river", new Rectangle(0, 48, 244, 80), new Color(Color.Red, 0.25f));

            PlayerController playerController = new(Player);

            Controllers.Add(new GoalController(Player, goals, playerController));
            Controllers.Add(new HomeAnimationController(goals));
            Controllers.Add(playerController);

            var bulldozerRowModel = new VehicleRowModel(BulldozerFactory.CreateFirstStage(), pixelsPerSecond: 32f);
            var racingCarRowModel = new VehicleRowModel(RacingCarFactory.CreateFirstStage(), 0, 128f, 2f, VehicleGhost.NoGhost);
            var sedanCarRowModel = new VehicleRowModel(GenericCarFactory.CreateFirstStage(), 0, 32f, 0f, VehicleGhost.Ghost, MovementDirection.RightToLeft);
            DuneBuggyRowModel = new VehicleRowModel(GenericCarFactory.CreateFirstStage(y: 208, frame: 9), 0, 32f, 0f, VehicleGhost.Ghost, MovementDirection.RightToLeft);
            var truckRowModel = new VehicleRowModel(TruckFactory.CreateFirstStage(), 0, 36, 0, VehicleGhost.Ghost, MovementDirection.RightToLeft);

            var riverRow1 = new RiverRowModel(LogFactory.CreateRow1FirstStage(), new Rectangle(0, 48, 256, 16), 0, 36f, MovementDirection.LeftToRight);
            var riverRow2 = new RiverRowModel(LogFactory.CreateRow2FirstStage(), new Rectangle(0, 64, 216, 16), 0, 36f, MovementDirection.RightToLeft);
            var riverRow3 = new RiverRowModel(LogFactory.CreateRow3FirstStage(), new Rectangle(0, 80, 216, 16), 64, 36f, MovementDirection.LeftToRight);
            var riverRow4 = new RiverRowModel(LogFactory.CreateRow4FirstStage(), new Rectangle(0, 96, 216, 16), 0, 36f, MovementDirection.RightToLeft);
            var riverRow5 = new RiverRowModel(LogFactory.CreateRow5FirstStage(), new Rectangle(0, 112, 216, 16), 0, 36f, MovementDirection.LeftToRight);
            RiverModels = new[] { riverRow1, riverRow2, riverRow3, riverRow4, riverRow5 };

            var riverView = new VehicleView(Machine.CurrentGame.Content, Sprites, RiverModels);
            Views.Add(riverView);
            var riverController = new RiverObjectController(Player, playerController, RiverModels);
            Controllers.Add(riverController);

            var vehicleContoller = new VehicleController(Player, playerController, new VehicleRowModel[]
            {
                bulldozerRowModel,
                racingCarRowModel,
                sedanCarRowModel,
                DuneBuggyRowModel,
                truckRowModel
            });
            Controllers.Add(vehicleContoller);

            var vehicleView = new VehicleView(Machine.CurrentGame.Content, Sprites, new VehicleRowModel[]
            {
                bulldozerRowModel,
                racingCarRowModel,
                sedanCarRowModel,
                DuneBuggyRowModel,
                truckRowModel
            });

            Views.Add(vehicleView);
            Views.Add(new PlayerView(Machine.CurrentGame.Content, Sprites, Player));
        }

        public override void Exit()
        {
            Views.Clear();
            Controllers.Clear();

        }

        public override void Update(float deltaTime)
        {
            foreach(var controller in Controllers)
            {
                controller.Update(deltaTime);
            }

            if (Player.Goals == 5)
            {
                Player.Score += 1000;
                Machine.Change("game", false);
            }
            else if (Player.Lives == 0)
            {
                Machine.Change("gameover");
            }
        }
    }
}
