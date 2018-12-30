using System.Collections.Generic;
using SuperMario.Controllers;
using SuperMario.Entities.Mario;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Entities.BackgroundElements;
using SuperMario.Collision;
using SuperMario.Sound;
using SuperMario.Commands;
using SuperMario.Entities;
using SuperMario.ScoreSystem;
using Microsoft.Xna.Framework.Input;
using SuperMario.HUDAndSoundSystemControl.SoundSystemControl;

namespace SuperMario.Desktop
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {

        readonly GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        bool paused;

        static bool gameOver;
        public static bool GameOver
        {
            get { return gameOver; }
            set 
            {
                if (!value && gameOver)
                    gameOverTimer = 0;
                gameOver = value;
            }
        }

        public static bool ClockPaused { get; set; }
        public static Color BackgroundColor { get; set; } = Color.CornflowerBlue;
        public static LevelData LevelData { get; set; }

        static long gameOverTimer;
        long gameOverMaxTimeInTicks = 30000000;
        GameOverScreen gameOverScreen;
        IList<CameraController> cameraControllers;
        IList<Viewport> viewports;

        IList<IController> controllerList;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            paused = false;
            ClockPaused = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Viewport originalViewport = graphics.GraphicsDevice.Viewport;
            viewports = new List<Viewport>
            {
                new Viewport(0, 0, originalViewport.Width / 2, originalViewport.Height),
                new Viewport(originalViewport.Width / 2, 0, originalViewport.Width / 2, originalViewport.Height)
            };

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            WinterTextureStorage.LoadAllTextures(Content, GraphicsDevice);
            WinterMarioTextureStorage.LoadAllTextures(Content);
            WinterBackgroundTextureStorage.LoadAllTextures(Content);
            WinterLuigiTextureStorage.LoadAllTextures(Content);
            SoundStorage.LoadAllSounds(Content);
            LevelLoading levelLoading = new LevelLoading();
            levelLoading.LoadLevel();
            LevelData = levelLoading.LevelObjectsData;
            cameraControllers = new List<CameraController>();
            for (int i = 0; i < viewports.Count; i++)
                cameraControllers.Add(new CameraController(viewports[i], LevelData.LevelHeight, LevelData.LevelWidth, i));
            font = Content.Load<SpriteFont>("Score");
            FontManager.SetScoreFont(font);
            HUDController.Instance.Initialize(font);
            gameOverScreen = new GameOverScreen();
            controllerList = new List<IController>
            {
                new KeyboardController(this, 0, new PlayerKeys(Keys.W, Keys.S, Keys.A, Keys.D, Keys.X)),
                new KeyboardController(this, 1, new PlayerKeys(Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.RightAlt)),
                new GamepadController(this),
                new AuxKeyboardController(this)
            };
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllerList)
                controller.Update();

            if (GameOver)
            {
                gameOverTimer += gameTime.ElapsedGameTime.Ticks;

                if (gameOverTimer > gameOverMaxTimeInTicks)
                    new ResetInitialStateCommand(LevelData).Execute();
            }

            if (!paused && !GameOver)
            {
                EntityStorage.Instance.UpdateAllEntities(gameTime);

                if (!ClockPaused)
                {
                    HUDController.Instance.SetGameTime(gameTime);
                    HUDController.Instance.KeepTime();
                }

                MusicController.Instance.UpdateMusic();
                MasterCollider.RunCollision();
                foreach (CameraController cameraController in cameraControllers)
                    cameraController.Update();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Viewport originalViewport = graphics.GraphicsDevice.Viewport;
            GraphicsDevice.Clear(BackgroundColor);
            for (int i = 0; i < viewports.Count; i++)
            {
                graphics.GraphicsDevice.Viewport = viewports[i];
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, cameraControllers[i].TransformationMatrix);

                if (!GameOver)
                    EntityStorage.Instance.DrawAllEntities(spriteBatch);

                spriteBatch.End();
            }
            graphics.GraphicsDevice.Viewport = originalViewport;
            spriteBatch.Begin();

            if (!GameOver)
            {
                spriteBatch.Draw(WinterTextureStorage.BorderWinter, new Vector2(originalViewport.Bounds.Center.X - 2, 0), Color.Black);
                HUDController.Instance.Draw(spriteBatch);
            }
            else
                gameOverScreen.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void TogglePause()
        {
            paused = !paused;
            SoundEffects.Instance.PlayPause();
            if (!Music.IsMusicStopped())
                Music.PauseMusic();
            else
                Music.ResumeMusic();
        }

        public static void ToggleGameClock()
        {
            ClockPaused = !ClockPaused;
        }

        public bool IsPaused()
        {
            return paused;
        }

        public static void ResetLevel()
        {
            MasterCollider.Reset();
            ScoreKeeper.Instance.ResetScore();
            EntityStorage.Instance.PopulateEntityListNotPlayers(LevelData);
            foreach (Entity player in EntityStorage.Instance.PlayerEntityList)
            {
                EntityStorage.Instance.EntityList.Add(player);
                MasterCollider.AddCollidingEntity(player);
            }
            GameOver = false;
        }
    }
}
