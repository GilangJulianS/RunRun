using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace RunRun.Game_Classes {
	public class Obstacle {

		private Vector2 size, speed, position;
		private Rectangle bound, deathBound;

		public Obstacle(float x, float y) {
			size = new Vector2(100, 100);
			speed = new Vector2(Background.simultanSpeed.X, Background.simultanSpeed.Y);
			position = new Vector2(x, y);
			bound = new Rectangle((int)x, (int)y, (int)size.X, (int)size.Y);
			deathBound = new Rectangle((int)(x+(size.X/10)), (int)(y+(size.Y/10)), (int)(size.X*8/10), (int)(size.Y*8/10));
		}

		public void update() {
			position += Background.simultanSpeed;
			bound.Offset((int)(position.X-bound.Left+(size.X/10)), (int)(position.Y-bound.Top+(size.X/10)));
		}

		public Vector2 getPos() {
			return position;
		}

		public Vector2 getSize() {
			return size;
		}

		public Rectangle getBound() {
			return bound;
		}

		public Rectangle getDeathBound() {
			return deathBound;
		}
	}
}
