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
using MyDataTypes;

namespace WindowsPhoneGame2
{
    class Borne : GraphicObject
    {
        public Texture2D textu;
        public Texture2D textulight;
        public Vector2 poscenter;
        public Vector2 pos;
        public Rectangle rectborn;
        public bool islight;
        Point A;
        Point B;

        public Borne(Texture2D A, Vector2 B, Texture2D C)
        {
            textu = A;
            pos = B;
            textulight = C;
            rectborn = new Rectangle((int)B.X, (int)B.Y, 31, 50);
            poscenter.X = pos.X + (textu.Width / 2);
            poscenter.Y = pos.Y + (textu.Height);
            islight = false;
        }

        public void Update(List<Obstacle> Lob, DragObj Ldo)
        {
            bool inter = false;

            A = new Point((int)pos.X + 15, (int)pos.Y + 25);
         //   for (int index = 0; index < Lob.Count(); index++)
           // {
            B = new Point((int)Ldo.Shape.Center.X, (int)Ldo.Shape.Center.Y);
            for (int j = 0; j < Lob.Count(); j++) // verif si elel est allume avec 1 station sinon relancer 
            {
               if (inter = interclass.LineIntersectsRect(A, B, Lob[j].Shape))
              // if (inter = interclass.LineIntersectsRect(RotatePoint(A, new Point(Lob[j].Shape.Center.X, Lob[j].Shape.Center.Y), Lob[j].rotation), RotatePoint(B, new Point(Lob[j].Shape.Center.X, Lob[j].Shape.Center.Y), Lob[j].rotation), Lob[j].Shape))
                {
                    inter = true;
                    islight = false;
                    break;
                }
                else
                {
                    inter = false;
                }
            }
            if (inter == false)
            {                               // coments are there for multi dragobj 
                if (islight == false)
                    islight = true;
                //break;
            }
            //}
        }

       // public Point RotatePoint(Point ro, float t)
        //{
           // t = MathHelper.ToRadians(t);

         //   return (new Point((int)(ro.X * Math.Cos(t) - ro.Y * Math.Sin(t)), (int)(ro.X * Math.Sin(t) + ro.Y * Math.Cos(t))));
        //}

        public Point RotatePoint(Point thePoint, Point theOrigin, float theRotation)
        {
            Point aTranslatedPoint = new Point();
            theRotation = MathHelper.ToRadians(theRotation);
            aTranslatedPoint.X = (int)(theOrigin.X + (thePoint.X - theOrigin.X) * Math.Cos(theRotation) - (thePoint.Y - theOrigin.Y) * Math.Sin(theRotation));
            aTranslatedPoint.Y = (int)(theOrigin.Y + (thePoint.Y - theOrigin.Y) * Math.Cos(theRotation) + (thePoint.X - theOrigin.X) * Math.Sin(theRotation));
            return aTranslatedPoint;
        }

        // changement connected ou pas
        public void Draw(SpriteBatch spriteBatch)
        {
            if (islight == false)
            {
                spriteBatch.Draw(textu, rectborn, Color.White);
            }
            else
            {
                spriteBatch.Draw(textulight, rectborn, Color.White);
            }
        }
    }
}
