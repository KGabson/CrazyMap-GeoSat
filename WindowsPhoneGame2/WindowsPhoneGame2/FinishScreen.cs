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
    class FinishScreen
    {
        private Texture2D background;
        private Rectangle Mainframe;
        private Game1 game;

        // definition des buttons
        private Rectangle Gobackbut;
        private Texture2D textgobackb;
        private Texture2D textbutpl;
        private Rectangle KeepPlayin; 

        // spritefont
        private SpriteFont _font;

        // bracket
        public Texture2D bracket;
        public Rectangle bracketRect;
        public Rectangle bracketRect2;

        // starshiptrooper
        public Texture2D Starship1;
        public Texture2D Starship2;
        public Texture2D Starship3;
        public Rectangle Troopers;

        // s'occuper de faire la page de fin
        public FinishScreen(Game1 game)
        {
            this.game = game;
            background = game.Content.Load<Texture2D>("endgame");
            Mainframe = new Rectangle(0, 0, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
            textbutpl = game.Content.Load<Texture2D>("bplay");
            KeepPlayin = new Rectangle(355, 290, 80, 80);
            textgobackb = game.Content.Load<Texture2D>("backb");
            Gobackbut = new Rectangle(44, 16, 60, 56);
            _font = game.Content.Load<SpriteFont>("ForScore");
            bracketRect = new Rectangle(190, 110, 150, 40);
            bracket = game.Content.Load<Texture2D>("panier");
            bracketRect2 = new Rectangle(190, 170, 150, 40);
            Starship1 = game.Content.Load<Texture2D>("13star");
            Starship2 = game.Content.Load<Texture2D>("23star");
            Starship3 = game.Content.Load<Texture2D>("33star");
            Troopers = new Rectangle(450, 130, 150, 70);
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
                        //break;
                    // on peut pas rajouter de case
                    // la shape se met pas au bonne endroit
                }
            }
            return Screen.GameOverScreen;               
                        
        }

        public Screen Mouseclik(int px, int py)
        {
            if (KeepPlayin.Contains(px, py))
            {
                VibrateController vc = VibrateController.Default;
                vc.Start(TimeSpan.FromMilliseconds(100));
                return (Screen.ChooseLevelScreen);
            }
            else if (Gobackbut.Contains(px, py))
            {
                VibrateController vc = VibrateController.Default;
                vc.Start(TimeSpan.FromMilliseconds(100));
                return (Screen.ChooseLevelScreen);
            }
            return (Screen.GameOverScreen);
        }
       
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Mainframe, Color.White);
            spriteBatch.Draw(textbutpl, KeepPlayin, Color.White);
            spriteBatch.Draw(textgobackb, Gobackbut, Color.White);
            spriteBatch.Draw(bracket, bracketRect, Color.White);
            spriteBatch.Draw(bracket, bracketRect2, Color.White);
            spriteBatch.DrawString(_font, "Score : ICI", new Vector2(200, 120), Color.Red);
            spriteBatch.DrawString(_font, "Time : ICI", new Vector2(200, 180), Color.Red);
            // gerer en fonction du score.
            spriteBatch.Draw(Starship1, Troopers, Color.White);
        }

        // enregistrement XML pour le nombre d'étoile       
        public void Get_Score()
        {
            // enregistrement.
        }
    }
}
