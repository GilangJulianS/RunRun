using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace RunRun.Game_Classes {
	class Coin {

		public static readonly Vector2 DEFAULT_SIZE = new Vector2(25);
		private Vector2 position, speed, size;
		private Rectangle bound;

		public Coin(float x, float y) {
			position = new Vector2(x, y);
			speed = new Vector2(Background.simultanSpeed.X, 0);
			size = new Vector2(Coin.DEFAULT_SIZE.X, Coin.DEFAULT_SIZE.Y);
			bound = new Rectangle((int)x, (int)y, (int)size.X, (int)size.Y);
		}

		public Coin(Vector2 position) {
			this.position = new Vector2(position.X, position.Y);
			speed = new Vector2(Background.simultanSpeed.X, 0);
			size = new Vector2(Coin.DEFAULT_SIZE.X, Coin.DEFAULT_SIZE.Y);
			bound = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
		}

		public void update() {
			position += Background.simultanSpeed;
			bound.Offset((int)position.X - bound.Left, (int)position.Y - bound.Top);
		}

		public Vector2 getPos() {
			return position;
		}

		public Rectangle getBound() {
			return bound;
		}
	}
}
