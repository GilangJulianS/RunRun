using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace RunRun.Game_Classes {
	public class Background {

		public static readonly int NORMAL = 0;
		public static readonly int FAR = 1;
		public static Vector2 DEFAULT_SPEED = new Vector2(-5,0);
		public static Vector2 simultanSpeed = new Vector2(-5,0);
		private Vector2 position, size, speed;
		private int type;
		

		public Background(float x, float y, int type){
			position = new Vector2(x, y);
			size = new Vector2(1512, 480);
			speed = new Vector2(Background.simultanSpeed.X,Background.simultanSpeed.Y);
			this.type = type;
		}

		public void update() {
			if(type == Background.NORMAL) {
				Background.simultanSpeed = DEFAULT_SPEED * Game1.gameSpeed;
				position += Background.simultanSpeed;
			}
			else 
				position += speed*Game1.gameSpeed;
			if(position.X <= -size.X) {
				position.X = size.X + (position.X + size.X);
			}
		}

		public Vector2 getPos() {
			return position;
		}

		public void setSpeed(float x, float y) {
			speed.X = x;
			speed.Y = y;
		}
	}
}
