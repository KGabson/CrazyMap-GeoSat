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
    class Vise
    {
       public Color colorvise;
       public Vector2 stat1;
       public Vector2 stat2;
       public DragObj st1;
       public DragObj st2;
       public bool nice;
       Color col;

        public Vise(Vector2 A, Vector2 B, DragObj C, DragObj D)
        {
            stat1 = A;
            stat2 = B;
            st1 = C;
            st2 = D;
            colorvise = Color.Black;
            nice = false;
        }

        // Comment mettre à jour Update de la class vise
        // quand les coordonnées des station sont mis a jour.
        // est ce que je peux mettre un jour avec un pointeur sur le drag obj
        public void Update()
        {
            stat1.X = st1.Shape.Center.X;
            stat1.Y = st1.Shape.Center.Y;
            stat2.X = st2.Shape.Center.X;
            stat2.Y = st2.Shape.Center.Y;
        } 

        public void Draw(SpriteBatch sb, Texture2D Blank, List<Obstacle> ls)
        {
            if (colorvise != Color.Green)
            {
                for (int i = 0; i < ls.Count(); i++)
                {
                    if (interclass.LineIntersectsRect(new Point((int)stat1.X, (int)stat1.Y), new Point((int)stat2.X, (int)stat2.Y), ls[i].Shape))
                    {
                        col = Color.Red;
                        nice = false;
                        break;
                    }
                    else
                    {
                        col = Color.Black;
                        nice = true;
                    }
                }
            }
            
            // color.green.
            DrawLine(sb, Blank, 3, col, stat1, stat2);  
        }

        void DrawLine(SpriteBatch batch, Texture2D blank, float width, Color color, Vector2 point1, Vector2 point2)
        {
            float angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            float length = Vector2.Distance(point1, point2);

            batch.Draw(blank, point1, null, color, angle, Vector2.Zero, new Vector2(length, width), SpriteEffects.None, 0);
        }
    }
}

