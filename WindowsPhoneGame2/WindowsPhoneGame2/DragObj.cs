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
     class DragObj
    {
        public Texture2D t_Sprite;
        public Vector2 Position;
        public bool selected;
        public Rectangle Shape;
        public Rectangle ShapeViser;
        public bool isvise;
        public Texture2D selectedt;
        public bool IsGps;
        public int Width
        {
            get { return t_Sprite.Width; }
        }
        public int Height
        {
            get { return t_Sprite.Height; }
        }

        // rectangle autour qui se recalcul dans update
        public void Initialize(Texture2D text, Vector2 pos, Texture2D sel, bool isit)
        {
            t_Sprite = text;
            Position.X = (pos.X + 20);
            Position.Y = (pos.Y + 20);
            Shape = new Rectangle((int)Position.X, (int)Position.Y, 45, 45);
            ShapeViser = new Rectangle((int)Position.X + 30, (int)Position.Y, 15, 30);
            selectedt = sel;
            isvise = false;
            IsGps = isit;
        }

        public Rectangle DefineShape()
        {
            Shape = new Rectangle((int)Position.X, (int)Position.Y, 40, 40);
            return (Shape);
        }

        // PAUSE ICI ---> Avancer et checker en focntion de la direction
        public void Update(Vector2 PositionTouch, List<Obstacle> ListObs)
        {
            if (selected)
            {
                if (PositionTouch.X >= Position.X && PositionTouch.Y >= Position.Y)
                {
                    fullsup(PositionTouch, ListObs);
                }
                else if (PositionTouch.X >= Position.X && PositionTouch.Y <= Position.Y)
                {
                    supxlessy(PositionTouch, ListObs);
                }
                else if (PositionTouch.X <= Position.X && PositionTouch.Y >= Position.Y)
                {
                    lessxsupx(PositionTouch, ListObs);
                }
                else
                {
                    fullless(PositionTouch, ListObs);
                }
                Position.X -= 20;
                Position.Y -= 20;
            }
            Shape = new Rectangle((int)Position.X, (int)Position.Y, 40, 40);
        }

        public void fullsup(Vector2 PositionTouch, List<Obstacle> ListObs)
        {
            for (float i = Position.X, e = Position.Y; i <= PositionTouch.X || e <= PositionTouch.Y; i += 1, e += 1)
            {
                if (i <= PositionTouch.X)
                {
                    Position.X += 1;
                }
                if (e <= PositionTouch.Y)
                {
                    Position.Y += 1;
                }
            }
        }

        public void supxlessy(Vector2 PositionTouch, List<Obstacle> ListObs)
        {
            for (float i = Position.X, e = Position.Y; i <= PositionTouch.X || e <= PositionTouch.Y; i += 1, e += 1)
            {
                if (i >= PositionTouch.X)
                {
                    Position.X -= 1;
                }
                if (e <= PositionTouch.Y)
                {
                    Position.Y += 1;
                }
            }
        }
        public void lessxsupx(Vector2 PositionTouch, List<Obstacle> ListObs)
        {
            for (float i = Position.X, e = Position.Y; i <= PositionTouch.X || e <= PositionTouch.Y; i += 1, e += 1)
            {
                if (i <= PositionTouch.X)
                {
                    Position.X += 1;
                }
                if (e >= PositionTouch.Y)
                {
                    Position.Y -= 1;
                }
            }
        }

        public void fullless(Vector2 PositionTouch, List<Obstacle> ListObs)
        {
            for (float i = Position.X, e = Position.Y; i <= PositionTouch.X || e <= PositionTouch.Y; i += 1, e += 1)
            {
                if (i >= PositionTouch.X)
                {
                    Position.X -= 1;
                }
                if (e >= PositionTouch.Y)
                {
                    Position.Y -= 1;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!isvise)
            {
                spriteBatch.Draw(t_Sprite, Shape, Color.White);
            }
            else
            {
                spriteBatch.Draw(selectedt, Shape, Color.White);
            }
        }
    }
}
