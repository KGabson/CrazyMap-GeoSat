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

namespace WindowsPhoneGame2
{
    class GamePlayScreen
    {
        private Game1 game;
        public Texture2D background;
        public Rectangle mainFrame;
        public Map Current;

        // rajouter pause/screen
        // rajouter checkfor the win
       

        public GamePlayScreen(Game1 game)
        {
            this.game = game;
            // set background
            mainFrame = new Rectangle(0, 0, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
           // Envoyer la texture + le nom du fichier XMl
            background = game.Content.Load<Texture2D>(GlobalVar.texture);
            
            // lancement d'une partie envoie du nom du fichier ou enfonction du button. a voir.
            Current = new Map();
            // pour chemin en fonction du niveau
            Current.Initialize(GlobalVar.xmlfile, game.Content, game.GraphicsDevice);
        }

        public void Update(GameTime gameTime)
        {

            // Map met a jour station qui bouge etc ..
            Current.Update(gameTime);

            //Verif si les bornes sont co ou pas
            //////////////////////////////////////////////////////////////
            for (int i = 0; i < Current.ListBrn.Count(); i++)
            {
                for (int a = 0; a < Current.ListDragObj.Count(); a++) // dragObj
                {
                    Current.ListBrn[i].Update(Current.ListObs, Current.ListDragObj[a]);
                    if (Current.ListBrn[i].islight == true)
                        break;
                }
            }

            //lance la methode dans map pour verif si c'est finish
            if (Current.IsItFinish())
            {
              //  game.Startgame();
                // chnager d'écran alors que Update na pas de return.
                // SET Des global var pour le score + le temps.
                game.startendScreen();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D blank = new Texture2D(game.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            blank.SetData(new[] { Color.Red });

            // Color of the line 
            spriteBatch.Draw(background, mainFrame, Color.White);
       
            // Fonction qui trace les lignes entre les stations.

         //   for (int i = 0; i < Current.ListDragObj.Count() - 1; i++)
         //   {
          //      Vector2 test2 = new Vector2(Current.ListDragObj[i + 1].Position.X + (Current.ListDragObj[i + 1].t_Sprite.Width / 2), Current.ListDragObj[i + 1].Position.Y + (Current.ListDragObj[i + 1].t_Sprite.Height / 2));

                // mettre le centre au mid.
            //    DrawLine(spriteBatch, blank, 3, Color.White, Current.ListDragObj[i].Position, Current.ListDragObj[i + 1].Position);
              //  DrawLine(spriteBatch, blank, 3, Color.White, test, test2);
          //  }

            Current.Draw(spriteBatch);
            //End
        }
    }
    public static class LineRenderer
    {
        public static void DrawLine(this SpriteBatch spriteBatch, Texture2D texture, Vector2 start, Vector2 end)
        {
            spriteBatch.Draw(texture, start, null, Color.White,
                             (float)Math.Atan2(end.Y - start.Y, end.X - start.X),
                             new Vector2(0f, (float)texture.Height / 2),
                             new Vector2(Vector2.Distance(start, end), 1f),
                             SpriteEffects.None, 0f);
        }
    }
}
