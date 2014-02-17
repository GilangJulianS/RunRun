using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RunRun.Game_Classes
{
    class MenuButton
    {
        public Vector2 pos = new Vector2();
        public Rectangle touchBox;
        public Texture2D texture;
        public bool available = false;

        // Handle Bounding Box and if the button has been pressed
        public bool update(Rectangle touchLoc)
        {
            bool returnValue = false;

            if (available)
            {
                touchBox = new Rectangle((int)pos.X, (int)pos.Y, texture.Width, texture.Height);

                if (touchBox.Intersects(touchLoc))
                {
                    returnValue = true;
                }
            }

            return returnValue;
        }
    }
}
