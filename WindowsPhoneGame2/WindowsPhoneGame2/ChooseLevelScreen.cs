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
    class ChooseLevelScreen
    {
        private Game1 game;
        public Rectangle mainFrame;
        private Texture2D texture;

        public Rectangle level1rect;
        public Rectangle level2rect;
        public Rectangle level3rect;

        public Rectangle backbutton;

        // test
       public Texture2D startbutton;

        public ChooseLevelScreen(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("selectlevel");
            mainFrame = new Rectangle(0, 0, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
            level1rect = new Rectangle(120, 63, 73, 87);
            level2rect = new Rectangle(230, 83, 80, 87);
            level3rect = new Rectangle(340, 54, 80, 87);
            backbutton = new Rectangle(44, 16, 60, 56);
            startbutton = (game.Content.Load<Texture2D>("t1"));        
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
            return (Screen.ChooseLevelScreen);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture != null)
                spriteBatch.Draw(texture, mainFrame, Color.White);
            // texture de test a  mettre ou placer le rectangle
        //  spriteBatch.Draw(startbutton, level3rect, Color.White);
        }

        public Screen Mouseclik(int x, int y)
        {
            Rectangle mouserec = new Rectangle(x, y, 10, 10);
            if (mouserec.Intersects(level1rect))
            {
                VibrateController vc = VibrateController.Default;
                vc.Start(TimeSpan.FromMilliseconds(100));
                GlobalVar.texture = "textsable";
                GlobalVar.xmlfile = "pets";
                GlobalVar.sound = "grassland";
                return (Screen.GamePlayScreen);
            }
            else if (mouserec.Intersects(level2rect))
            {
                VibrateController vc = VibrateController.Default;
                vc.Start(TimeSpan.FromMilliseconds(100));
                GlobalVar.texture = "textg";
                GlobalVar.xmlfile = "Level";
                GlobalVar.sound = "grassland";
                return (Screen.GamePlayScreen);
            }
            else if (mouserec.Intersects(level3rect))
            {
                VibrateController vc = VibrateController.Default;
                vc.Start(TimeSpan.FromMilliseconds(100));
                GlobalVar.texture = "textsable";
                GlobalVar.xmlfile = "Level";
                GlobalVar.sound = "grassland";
                return (Screen.GamePlayScreen);
            }
            else if (mouserec.Intersects(backbutton))
            {
                VibrateController vc = VibrateController.Default;
                vc.Start(TimeSpan.FromMilliseconds(100));
                return (Screen.ChooseWorldScreen);
            }
            return (Screen.ChooseLevelScreen);
        }
    }
}
