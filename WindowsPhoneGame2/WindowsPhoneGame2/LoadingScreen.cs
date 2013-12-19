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
    class LoadingScreen
    {
        private Game1 game;
        public Texture2D background;
        public Rectangle mainFrame;
        int height = 0;

        public Texture2D t1;
        public Texture2D t2;
        public Texture2D t3;    
        public Texture2D t4;

        public LoadingScreen(Game1 game)
        {
            this.game = game;
            background = game.Content.Load<Texture2D>("blackblack");
            t1 = game.Content.Load<Texture2D>("g5581");
            t2 = game.Content.Load<Texture2D>("g5585");
            t3 = game.Content.Load<Texture2D>("g5589");
            t4 = game.Content.Load<Texture2D>("g5593");
            mainFrame = new Rectangle(0, 0, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
        }

        public Screen Update()
        {
            // affichage de l'image geosat de haut en bas   
                return (Screen.GamePlayScreen);
        }

        public void Draw(SpriteBatch sb)
        {
            Texture2D blankTexture = new Texture2D(game.GraphicsDevice, 5, 5, false, SurfaceFormat.Color);
            Color[] color = new Color[25];
            for (int i = 0; i < color.Length; i++)
            {
                color[i] = Color.White;
            }
            blankTexture.SetData(color);
            sb.Draw(blankTexture, mainFrame, Color.White);
            // pas mal replacer dans le bon sens.
            if (height > 220)
                sb.Draw(t1, new Rectangle(350, 200, 90, 90), Color.White); // partie noir
            if (height > 180)
              sb.Draw(t2, new Rectangle(350, 200, 90, 90), Color.White); // partie blanche
            if (height > 70)
             sb.Draw(t3, new Rectangle(195, 200, 180, 100), Color.White); // globe 1 
            if (height > 300)
            sb.Draw(t4, new Rectangle(420, 200, 180, 100), Color.White); // globe 2
        }
    }
}
