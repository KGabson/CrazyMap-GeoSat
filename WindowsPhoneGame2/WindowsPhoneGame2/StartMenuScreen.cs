using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using Microsoft.Devices;

namespace WindowsPhoneGame2
{
    class StartScreen
    {
        private Texture2D texture;
        private Game1 game;
        private KeyboardState lastState;
        public Rectangle mainFrame;

        // definition des buttons de la page

        private Texture2D startbtext;
        private Rectangle startbrect;
       
        // sound
        private Rectangle soundrect;
        private Texture2D soundtext;
        private Texture2D soundofftext;
        public bool varsound;

        // Help
        private Rectangle lumrect;
        private Texture2D lumtext;

        // join tuto
        private Rectangle infosrect;
        private Texture2D texttuto;

        // spritefont
       // private SpriteFont _font;

        // geotext
        private Texture2D bangeo; 
        
        public StartScreen(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("StartScreen");
            mainFrame = new Rectangle(0, 0, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
            lastState = Keyboard.GetState();
   
            // definition des buttons 
            startbrect = new Rectangle(370, 258, 88, 88);
            startbtext = game.Content.Load<Texture2D>("bplay");
           
             infosrect = new Rectangle(680, 408, 48, 48); // bouton interrogation --> credit
            texttuto = game.Content.Load<Texture2D>("interro");

           

        //  _font = game.Content.Load<SpriteFont>("ForScore");
            bangeo = game.Content.Load<Texture2D>("banfin");

            // to use
            soundtext = game.Content.Load<Texture2D>("soundonb");
            soundrect = new Rectangle(58, 25, 48, 48);

            lumrect = new Rectangle(680, 25, 48, 48); // Tuto mettre sur la page gameplayscreen
            lumtext = game.Content.Load<Texture2D>("lampb");

            //shoprect = new Rectangle(147, 384, 48,48);
            //settingsrect = new Rectangle(600, 408, 48, 48);

            soundofftext = game.Content.Load<Texture2D>("musicoff");
            varsound = true;

        }

        public Screen Update()
        {
            // method qui return le current screen, en checkan 
            //intersection entre rectancle position souris avbec rectangle buttons
            
            TouchPanelCapabilities touchCap = TouchPanel.GetCapabilities();
            if (touchCap.IsConnected)
            {
                TouchCollection touches = TouchPanel.GetState();

                if (touches.Count >= 1)
                {
                    Vector2 PositionTouch = touches[0].Position;
                    if (touches[0].State == TouchLocationState.Released)
                        return (Mouseclik((int)PositionTouch.X, (int)PositionTouch.Y));
                }
            }
            return (Screen.StartScreen);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture != null)
                spriteBatch.Draw(texture, mainFrame, Color.White);
            spriteBatch.Draw(startbtext, startbrect, Color.White);
            spriteBatch.Draw(texttuto, infosrect, Color.White);
          //  spriteBatch.DrawString(_font, "By", new Vector2(260, 220), Color.Black);
            spriteBatch.Draw(bangeo, new Rectangle(405, 214, 120, 25), Color.White);
            spriteBatch.Draw(lumtext, lumrect, Color.White);
            if (varsound)
                spriteBatch.Draw(soundtext, soundrect, Color.White);
            else
                spriteBatch.Draw(soundofftext, soundrect, Color.White);
        }

        public Screen Mouseclik(int x, int y)
        {
            Rectangle mouserec = new Rectangle(x, y, 10, 10);
            if (mouserec.Intersects(startbrect))
            {
                // faire vibrer le tel.
                // mettre a chaque clik jusqu'a la fin de partie ? 
                VibrateController vc = VibrateController.Default;
                vc.Start(TimeSpan.FromMilliseconds(100));
                return (Screen.ChooseWorldScreen);
            }
            else if (mouserec.Intersects(lumrect))
            {
                VibrateController vc = VibrateController.Default;
                vc.Start(TimeSpan.FromMilliseconds(100));
                return (Screen.TutoScreen);
            }
            else if (mouserec.Intersects(soundrect))
            {
                if (varsound)
                {
                    varsound = false;
                }
                else
                    varsound = true;
            }
            else if (mouserec.Intersects(infosrect))
            {
                VibrateController vc = VibrateController.Default;
                vc.Start(TimeSpan.FromMilliseconds(100));
                return (Screen.CreditScreen);
            }
            return (Screen.StartScreen);
        }
    }
}
