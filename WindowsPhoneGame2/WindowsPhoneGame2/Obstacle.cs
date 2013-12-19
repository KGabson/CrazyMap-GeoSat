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
    class Obstacle : GraphicObject
    {
        public Texture2D TOb;
        public Vector2 VOb;
        public Rectangle Shape;
        public int rotation;
        public int id;
        public int Width;
        public int Height;
        // rename sans danger a tester ? Shape en fonctiob de 'lid d'objet.
        public Obstacle(Texture2D A, Vector2 B, int rot, int di, int width, int height)
        {
            TOb = A;
            VOb = B;
            rotation = rot;
            Width = width;
            Height = height;
           // rotation = 0;
            id = di;
            Shape = new Rectangle((int)B.X, (int)B.Y, Width, Height);        
        }

        public Rectangle DefineShape()
        {
            return (Shape);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TOb, Shape, Color.White);
            
            //Soucis avec la rotation ? Radians Rotate line ?

           // spriteBatch.Draw(TOb, Shape, null, Color.White, MathHelper.ToRadians(rotation), new Vector2(Shape.Width / 2, Shape.Height / 2), SpriteEffects.None, 1.0f);
           // spriteBatch.Draw(TOb, VOb, null, Color.White, MathHelper.ToRadians(rotation), new Vector2(TOb.Width / 2, TOb.Height / 2), 1.0f, SpriteEffects.None, 0);
        }
    }
}
