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
    class PictureBox // button
    {
        Texture2D Image;
        Rectangle SrcRect;
        Rectangle DestRect;
        Color Color;

        public PictureBox(Texture2D image, Rectangle destination)
        {
            Image = image;
            DestRect = destination;
            SrcRect = new Rectangle(0, 0, image.Width, image.Height);
            Color = Color.White;
        }
        public PictureBox(Texture2D image, Rectangle destination, Rectangle source)
        {
            Image = image;
            DestRect = destination;
            SrcRect = source;
            Color = Color.White;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, DestRect, SrcRect, Color);
        }

        public void SetPosition(Vector2 newPosition)
        {
            DestRect = new Rectangle(
                (int)newPosition.X,
                (int)newPosition.Y,
                SrcRect.Width,
                SrcRect.Height);
        }
    }
}
