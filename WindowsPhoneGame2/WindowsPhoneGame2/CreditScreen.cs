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
     
    class CreditScreen
    {
        private Texture2D background;
        private Rectangle Mainframe;
        private Game1 game;

        // definition des buttons
        private Rectangle Gobackbut;
        private Texture2D textgobackb;
        private Texture2D background2;
        
        // spritefont
        private SpriteFont _font;
        private Rectangle creditrect;
        private Texture2D textcredit;
        private bool bolos;
        Screen Current;

        // s'occuper de faire la page de fin
        public CreditScreen(Game1 game)
        {
            this.game = game;
            background = game.Content.Load<Texture2D>("CreditScreen");
            Mainframe = new Rectangle(0, 0, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
        
            textgobackb = game.Content.Load<Texture2D>("backb");
            Gobackbut = new Rectangle(44, 16, 60, 56);

            creditrect = new Rectangle(680, 25, 50, 50); // bouton I Qui a trvailler sur le projet a mettre a la suite de credit ? 
            textcredit = game.Content.Load<Texture2D>("infob");
            
            _font = game.Content.Load<SpriteFont>("ForScore");
            bolos = false;
            background2 = game.Content.Load<Texture2D>("CreditScreen2");
            Current = Screen.CreditScreen;

        }

        public Screen Update()
        {
            TouchPanel.EnabledGestures =
                      GestureType.Tap;
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();

                switch (gesture.GestureType)
                {
                    case GestureType.Tap:
                        return Mouseclik((int)gesture.Position.X, (int)gesture.Position.Y);
                }
            }
            return Current;              
                        
        }

        public Screen Mouseclik(int px, int py)
        {
            if (Gobackbut.Contains(px, py))
            {
                Current = Screen.StartScreen;
            }
            else if (creditrect.Contains(px, py))
            {
                if (!bolos)
                    bolos = true;
                else
                    bolos = false;
            }
            return Current;
        }
       
        public void Draw(SpriteBatch spriteBatch)
        {
            if (bolos == false)
            {
                spriteBatch.Draw(background, Mainframe, Color.White);
                spriteBatch.Draw(textcredit, creditrect, Color.White);
            }
            else
            {
                spriteBatch.Draw(background2, Mainframe, Color.White);
            }
            spriteBatch.Draw(textgobackb, Gobackbut, Color.White);
            // gerer en fonction du score.
        }
    }
}

