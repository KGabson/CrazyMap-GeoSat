using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using MyDataTypes;

namespace WindowsPhoneGame2
{
    public enum Screen
    {
        StartScreen,
        GamePlayScreen,
        GameOverScreen,
        ChooseLevelScreen,
        ChooseLevelScreen2,
        ChooseLevelScreen3,
        ChooseWorldScreen,
        TutoScreen,
        LoadingScreen,
        CreditScreen
    }

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // declaration de chaque page.
        StartScreen startScreen;
        GamePlayScreen gamePlayScreen;
        ChooseWorldScreen chooseWorldScreen;
        ChooseLevelScreen chooseLevelScreen;
        ChooseLevelScreen2 chooseLevelScreen2;
        ChooseLevelScreen3 chooseLevelScreen3;
        TutoScreen tutoScreen;
        LoadingScreen loadingScreen;
        CreditScreen creditScreen;

        // screen de fin de game
        FinishScreen endScreen;

        public bool IsLoading;
        public Screen currentScreen;

        //
        SoundEffect _ballBounceWall;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // fullscreen for windows phone.
            graphics.IsFullScreen = true;
            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            // Extend battery life under lock.
            InactiveSleepTime = TimeSpan.FromSeconds(1);
        }

        /// <summary>
        /// Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
       
        protected override void Initialize()
        {            
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

            // TODO: use this.Content to load your game content here
            startScreen = new StartScreen(this);
            currentScreen = Screen.StartScreen;
            // load 

            _ballBounceWall = Content.Load<SoundEffect>("grassland");
            SoundEffectInstance instance = _ballBounceWall.CreateInstance();
            instance.IsLooped = true;
            _ballBounceWall.Play(0.1f, 0.0f, 0.0f); // reglage du volume.
            
            base.LoadContent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            switch (currentScreen)
            {
                case Screen.StartScreen:
                    if (startScreen != null)
                    {
                        currentScreen = startScreen.Update();
                        if (currentScreen == Screen.ChooseWorldScreen)
                        {
                            StartSelWorld();
                        }
                        else if (currentScreen == Screen.TutoScreen)
                            StartTutoScreen();
                        else if (currentScreen == Screen.CreditScreen)
                            Startcredits();
                    }
                    break;
                case Screen.GamePlayScreen:
                    if (gamePlayScreen != null)
                        gamePlayScreen.Update(gameTime);
                    break;
                case Screen.ChooseWorldScreen:
                    if (chooseWorldScreen != null)
                    {
                        currentScreen = chooseWorldScreen.Update();
                        if (currentScreen == Screen.ChooseLevelScreen)
                            StartSelLevel();
                        else if (currentScreen == Screen.ChooseLevelScreen2)
                            StartSelLevel2();
                        else if (currentScreen == Screen.ChooseLevelScreen3)
                            StartSelLevel3();
                        else if (currentScreen == Screen.StartScreen)
                            StartStartScreen();
                    }
                    break;
                case Screen.ChooseLevelScreen:
                    if (chooseLevelScreen != null)
                    {
                        currentScreen = chooseLevelScreen.Update();
                        if (currentScreen == Screen.ChooseWorldScreen)
                            StartSelWorld();
                        else if (currentScreen == Screen.GamePlayScreen)
                            Startgame();
                    }
                    break;
                case Screen.GameOverScreen:
                    if (endScreen == null)
                    {
                        startendScreen();
                    }
                    else
                    {
                        currentScreen = endScreen.Update();
                        if (currentScreen == Screen.ChooseLevelScreen)
                            StartSelLevel();
                    }
                    break;
                case Screen.ChooseLevelScreen2:
                    if (chooseLevelScreen2 != null)
                    {
                        currentScreen = chooseLevelScreen2.Update();
                        if (currentScreen == Screen.ChooseWorldScreen)
                            StartSelWorld();
                        else if (currentScreen == Screen.GamePlayScreen)
                            Startgame();
                    }
                    break;
                case Screen.ChooseLevelScreen3:
                    if (chooseLevelScreen3 != null)
                    {
                        currentScreen = chooseLevelScreen3.Update();
                        if (currentScreen == Screen.ChooseWorldScreen)
                            StartSelWorld();
                        else if (currentScreen == Screen.GamePlayScreen)
                            Startgame();
                    }
                    break;
                case Screen.TutoScreen:
                    if (tutoScreen != null)
                    {
                        currentScreen = tutoScreen.Update();
                        if (currentScreen == Screen.StartScreen)
                            StartStartScreen();
                    }
                    break;
                case Screen.LoadingScreen:
                    if (loadingScreen != null)
                    {
                        currentScreen = loadingScreen.Update();
                        if (currentScreen == Screen.GamePlayScreen)
                            Startgamew();
                    }
                    break;
                case Screen.CreditScreen:
                    if (creditScreen != null)
                    {
                        currentScreen = creditScreen.Update();
                        if (currentScreen == Screen.StartScreen)
                            StartStartScreen();
                    }
                    break;
                // effet fade-in/out dans le menu de fin
            }
            /////////////////////////////////////////////////////////////

          // tracer droite between drag Obj.
                // check between dragobj.
                // --> algorithme de chemin pas station avec toutes les autres
              //  CheckForTheWin();


            base.Update(gameTime);
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>

        public void startendScreen()
        {
            currentScreen = Screen.GameOverScreen;
            gamePlayScreen = null;
            endScreen = new FinishScreen(this);
        }

        public Screen ManageTheEnd()
        {

            return Screen.ChooseLevelScreen;
           // return Screen.StartScreen;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
       
            switch (currentScreen)
            {
                case Screen.StartScreen:
                    if (startScreen != null)
                        startScreen.Draw(spriteBatch);
                    break;
                case Screen.GamePlayScreen:
                    if (gamePlayScreen != null)
                        gamePlayScreen.Draw(spriteBatch);
                    break;
                case Screen.ChooseWorldScreen:
                    if (chooseWorldScreen != null)
                        chooseWorldScreen.Draw(spriteBatch);
                    break;
                case Screen.ChooseLevelScreen:
                    if (chooseLevelScreen != null)
                        chooseLevelScreen.Draw(spriteBatch);
                    break;
                case Screen.GameOverScreen:
                    if (endScreen != null)
                        endScreen.Draw(spriteBatch);
                    break;
                case Screen.ChooseLevelScreen2:
                    if (chooseLevelScreen2 != null)
                        chooseLevelScreen2.Draw(spriteBatch);
                    break;
                case Screen.ChooseLevelScreen3:
                    if (chooseLevelScreen3 != null)
                        chooseLevelScreen3.Draw(spriteBatch);
                    break;
                case Screen.TutoScreen:
                    if (tutoScreen != null)
                        tutoScreen.Draw(spriteBatch);
                    break;
                case Screen.LoadingScreen:
                    if (loadingScreen != null)
                        loadingScreen.Draw(spriteBatch);
                    break;
                case Screen.CreditScreen:
                    if (creditScreen != null)
                        creditScreen.Draw(spriteBatch);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }       

        public void Startgame()
        {
         //   startScreen = null; // toute les autres a null ?
           // IsLoading = true; // is loading ? dat new new
            //loadingScreen = new LoadingScreen(this);
            //urrentScreen = Screen.LoadingScreen;
            startScreen = null; // toute les autres a null ?
            loadingScreen = null;
            gamePlayScreen = new GamePlayScreen(this);
          //  gamePlayScreen = new GamePlayScreen(this);
            //currentScreen = Screen.GamePlayScreen;
        }

        public void Startgamew()
        {
            startScreen = null; // toute les autres a null ?
            loadingScreen = null;
            gamePlayScreen = new GamePlayScreen(this);
            //currentScreen = Screen.GamePlayScreen;
        }

        public void Startcredits()
        {
            startScreen = null;
            creditScreen = new CreditScreen(this);
        }

        public void StartSelWorld()
        {
            startScreen = null;
           // endScreen = null;
            chooseLevelScreen = null;

            chooseWorldScreen = new ChooseWorldScreen(this);
            currentScreen = Screen.ChooseWorldScreen;
        }

        public void StartSelLevel()
        {
            chooseWorldScreen = null;
            startScreen = null;

            chooseLevelScreen = new ChooseLevelScreen(this);
        }

        public void StartSelLevel2()
        {
            chooseWorldScreen = null;
            startScreen = null;
            chooseLevelScreen = null;
            chooseLevelScreen3 = null;

            chooseLevelScreen2 = new ChooseLevelScreen2(this);
        }

        public void StartSelLevel3()
        {
            chooseWorldScreen = null;
            startScreen = null;
            chooseLevelScreen = null;
            chooseLevelScreen2 = null;

            chooseLevelScreen3 = new ChooseLevelScreen3(this);
        }

        public void StartStartScreen()
        {
            chooseLevelScreen = null;
            chooseWorldScreen = null;

            startScreen = new StartScreen(this);        
        }

        public void StartTutoScreen()
        {

            startScreen = null;
            tutoScreen = new TutoScreen(this);
            currentScreen = Screen.TutoScreen;

        }
    }
}
