using Android.Content.Res;
using GameEngine.Vendor;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Nexus_Warfare.Source.Controller;
using Nexus_Warfare.Source.Scene;
using static Android.Widget.GridLayout;
using Android.Content;
using Android.App;
using System;

namespace Nexus_Warfare
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Rectangle screen;
        public Nexus_Warfare.Source.Scene.GameState gameState;
        public SpriteFont Font;
        public SoundManager soundManager;
        public CoinManager coinManager;
        public GoldManager goldManager;
        private const string PrefsName = "MyPrefs";
        private const string KeyMaxWaves = "maxCompletedWaves";
        private ISharedPreferences sharedPref;
        private int maxCompletedWaves;
        private int completedWaves;
        public static Game1 Instance { get; private set; }

        GameScreen gameScreen;
        MainMenuScreen mainMenuScreen;
        PauseScreen pauseScreen;
        EndGameScreen endGameScreen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true;
            Instance = this;
            sharedPref = Application.Context.GetSharedPreferences(PrefsName, FileCreationMode.Private);

            try
            {
                maxCompletedWaves = sharedPref.GetInt(KeyMaxWaves, 0);
            }
            catch (Exception ex)
            {
                maxCompletedWaves = 0;
            }
        }

        protected override void Initialize()
        {
            // Set resolution to a virtual adapter
            Resolution.Init(ref _graphics);
            int width = _graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            int height = _graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            float aspectRatio = (float)width / (float)height;
            int virtualWidth = 1080;
            int virtualHeight = (int)(virtualWidth / aspectRatio);
            Resolution.SetVirtualResolution(virtualWidth, virtualHeight);
            Resolution.SetResolution(width, height, false);
            screen = new Rectangle(0, 0, virtualWidth, virtualHeight);
            //Spremeni nazaj na MainScreenMenu
            gameState = Nexus_Warfare.Source.Scene.GameState.MainMenu; 
            Font = Content.Load<SpriteFont>("font");
            mainMenuScreen = new MainMenuScreen(Content, Font);
            pauseScreen = new PauseScreen(Content, Font);
            soundManager = new SoundManager();
            goldManager = new GoldManager();
            coinManager = new CoinManager(Content, goldManager);

            endGameScreen = new EndGameScreen(Content, Font);


            base.Initialize();
        }

        private void SaveMaxCompletedWaves(int maxWaves)
        {
            var editor = sharedPref.Edit();
            editor.PutInt(KeyMaxWaves, maxWaves);
            editor.Apply(); // Apply writes the data asynchronously
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            gameScreen = new GameScreen(screen, goldManager);
            gameScreen.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (gameState == Nexus_Warfare.Source.Scene.GameState.Exit)
            {
                Exit();

            }
            else if (gameState == Nexus_Warfare.Source.Scene.GameState.MainMenu)
            {
                coinManager.Reset();
                goldManager.Reset();
                gameScreen.Reset();
                mainMenuScreen.Update(gameTime, maxCompletedWaves);
            }
            else if (gameState == Nexus_Warfare.Source.Scene.GameState.Play)
            {
                gameScreen.Update(gameTime);
            }
            else if (gameState == Nexus_Warfare.Source.Scene.GameState.Pause)
            {
                pauseScreen.Update(gameTime);
            }
            else if (gameState == Nexus_Warfare.Source.Scene.GameState.GameOver)
            {
                //fix for GameOver update waveNum total + check hud
                completedWaves = gameScreen.getWaveNum();
                //Console.WriteLine("Game1.cs: Update: completedWaves: " + completedWaves);
                endGameScreen.Update(gameTime, completedWaves);
                if (completedWaves > maxCompletedWaves)
                {
                    maxCompletedWaves = completedWaves;
                    SaveMaxCompletedWaves(maxCompletedWaves);
                }
                
            }
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Resolution.BeginDraw();
            // Get the scale matrix from Resolution and pass it to SpriteBatch.Begin
            Matrix scaleMatrix = Resolution.getTransformationMatrix();
            _spriteBatch.Begin(transformMatrix: scaleMatrix);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //pauseScreen.Draw(_spriteBatch);

            if (gameState == Nexus_Warfare.Source.Scene.GameState.MainMenu)
            {
                mainMenuScreen.Draw(_spriteBatch, maxCompletedWaves);
            }
            else if (gameState == Nexus_Warfare.Source.Scene.GameState.Play)
            {
                gameScreen.Draw(_spriteBatch);
            }
            else if (gameState == Nexus_Warfare.Source.Scene.GameState.Pause)
            {
                pauseScreen.Draw(_spriteBatch, gameScreen.getWaveNum());
            }
            else if (gameState == Nexus_Warfare.Source.Scene.GameState.GameOver)
            {
                //Console.WriteLine("Game1.cs: Draw: gameScreen.getWaveNum(): " + gameScreen.getWaveNum());
                endGameScreen.Draw(_spriteBatch, completedWaves);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}