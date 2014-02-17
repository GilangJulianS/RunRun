using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace RunRun.Game_Classes {
	public class Projectile {

		public static readonly Vector2 DEFAULT_SPEED = new Vector2(-8, 0);
		public static readonly Vector2 DEFAULT_SIZE = new Vector2(20, 20);
		protected Vector2 position, size, speed;
		protected Rectangle bound;
		

		public Projectile() { 
			
		}

		public Projectile(float x, float y) {
			position = new Vector2(x, y);
			size = new Vector2(20, 20);
			speed = new Vector2(-8,0);
			bound = new Rectangle((int)x, (int)y, (int)size.X, (int)size.Y);
		}

		public Projectile(Vector2 position) {
			this.position = position;
			size = new Vector2(20, 20);
			speed = new Vector2(-8,0);
			bound = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
		}

		public virtual void update() {
			if(Game1.gameSpeed > 1)
				position += Background.simultanSpeed;
			else
				position += speed;
			bound.Offset((int)(position.X-bound.Left), (int)(position.Y-bound.Top));
		}

		public Vector2 getPos() {
			return position;
		}

		public Rectangle getBound() {
			return bound;
		}
	}
}
