using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RunRun.Game_Classes
{
    public class Projectile_straight : Projectile
    {
        public Projectile_straight(Vector2 position) {
            this.position = position;
            size = new Vector2(20, 20);
            speed = new Vector2(-15, 0);
            bound = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
        }
        public Projectile_straight(float x,float y)
        {
            position = new Vector2(x, y);
            size = new Vector2(20, 20);
            speed = new Vector2(-15, 0);
            bound = new Rectangle((int)x, (int)y, (int)size.X, (int)size.Y);
        }
        public override void update (){
            base.update();
        }
    }
}
