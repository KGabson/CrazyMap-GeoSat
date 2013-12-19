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

    class ChooseWorldScreen
    {

        private Texture2D texture;
        private Game1 game;
        public Rectangle mainFrame;

        public Rectangle world1rect;
        public Rectangle world2rect;
        public Rectangle world3rect;
        public Rectangle backbuttonw;

        public ChooseWorldScreen(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("selectworld");
            mainFrame = new Rectangle(0, 0, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
            world1rect = new Rectangle(185, 48, 143, 159);
            world2rect = new Rectangle(444, 81, 141, 155);
            world3rect = new Rectangle(200, 258, 134, 166);
            backbuttonw = new Rectangle(44, 16, 60, 56);
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
            return (Screen.ChooseWorldScreen);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture != null)
                spriteBatch.Draw(texture, mainFrame, Color.White);
        }


        public Screen Mouseclik(int x, int y)
        {
            Rectangle mouserec = new Rectangle(x, y, 10, 10);
            if (mouserec.Intersects(world1rect))
            {
                VibrateController vc = VibrateController.Default;
                vc.Start(TimeSpan.FromMilliseconds(100));
                return (Screen.ChooseLevelScreen);
            }
            else if (mouserec.Intersects(world2rect))
            {
                VibrateController vc = VibrateController.Default;
                vc.Start(TimeSpan.FromMilliseconds(100));
                return (Screen.ChooseLevelScreen2);
            }
            else if (mouserec.Intersects(world3rect))
            {
                VibrateController vc = VibrateController.Default;
                vc.Start(TimeSpan.FromMilliseconds(100));
                return (Screen.ChooseLevelScreen3);
            }
            else if (mouserec.Intersects(backbuttonw))
            {
                VibrateController vc = VibrateController.Default;
                vc.Start(TimeSpan.FromMilliseconds(100));
                return (Screen.StartScreen);
            }
            return (Screen.ChooseWorldScreen);
        }
    }
}
