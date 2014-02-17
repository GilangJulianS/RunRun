using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RunRun.Game_Classes {
	public class Pointer {

		public static readonly int SIZE = 25;
		private int timeLeft;
		private bool active;
		private Vector2 position;
		private Rectangle bound;

		public Pointer(float x, float y) {
			timeLeft = 250;
			position = new Vector2(x, y);
			active = true;
			bound = new Rectangle((int)x, (int)y, Pointer.SIZE, Pointer.SIZE);
		}

		public Pointer(Vector2 position) {
			this.position = position;
			timeLeft = 250;
			active = true;
			bound = new Rectangle((int)position.X, (int)position.Y, Pointer.SIZE, Pointer.SIZE);
		}

		public void update(int deltaTime) {
			timeLeft -= deltaTime;
			if(timeLeft <= 0) {
				active = false;
			}
		}

		public bool isActive() {
			return active;
		}

		public Vector2 getPos() {
			return position;
		}

		public Rectangle getBound() {
			return bound;
		}
	}
}
