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
    class TutoScreen
    {
        private Texture2D texture;
      //  private Texture2D texture1;
      //  private Texture2D texture2;
        private Game1 game;
        private KeyboardState lastState;
        public Rectangle mainFrame;

        // definition des buttons de la page

        private Texture2D startbtext;
        private Rectangle startbrect;
        private Texture2D folbtext;
        private Rectangle folrect;
        private Texture2D pagina2;

        private bool pagina;
 

        public TutoScreen(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("pagina2");
            mainFrame = new Rectangle(0, 0, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
            lastState = Keyboard.GetState();
   
            // definition des buttons :
            startbrect = new Rectangle(44, 16, 60, 56);
            startbtext = game.Content.Load<Texture2D>("backb");
            folbtext = game.Content.Load<Texture2D>("otherside");
            folrect = new Rectangle(696, 16, 60, 56);
            pagina2 = game.Content.Load<Texture2D>("Tuto");
            pagina = false;
        }

        public Screen Update()
        {
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
            return (Screen.TutoScreen);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (pagina == false)
            {
                spriteBatch.Draw(texture, mainFrame, Color.White);
                spriteBatch.Draw(folbtext, folrect, Color.White);
            }
            else
            {
                spriteBatch.Draw(pagina2, mainFrame, Color.White);
            }
            spriteBatch.Draw(startbtext, startbrect, Color.White);

        }

        public Screen Mouseclik(int x, int y)
        {
            Rectangle mouserec = new Rectangle(x, y, 10, 10);
            if (mouserec.Intersects(startbrect))
            {
                VibrateController vc = VibrateController.Default;
                vc.Start(TimeSpan.FromMilliseconds(100));
                if (pagina)
                    pagina = false;
                else
                    return (Screen.StartScreen);
            }
            else if (mouserec.Intersects(folrect))
            {
                if (pagina)
                    pagina = false;
                else
                    pagina = true;
            }
            return (Screen.TutoScreen);
        }
    }
}
