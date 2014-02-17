using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace RunRun.Game_Classes {
	public class Platform {

		public readonly static Vector2 SIZE_TYPE_1 = new Vector2(220, 25);//(120, 30);
		public readonly static Vector2 SIZE_TYPE_2 = new Vector2(180, 25);
		public readonly static Vector2 SIZE_TYPE_3 = new Vector2(240, 25);
		public readonly static Vector2 SIZE_TYPE_4 = new Vector2(300, 25);
		public readonly static Vector2 SIZE_TYPE_5 = new Vector2(360, 25);
		public readonly static Vector2 SIZE_TYPE_6 = new Vector2(420, 25);
		public readonly static int TYPE_SKY = 0;
		public readonly static int TYPE_GROUND = 1;
		public readonly static float DEFAULT_GROUND_Y = 440;
		public readonly static float DEFAULT_SKY_Y = 40;

		private int type;
		private Vector2 position, speed, size;
		private Rectangle bound;

		public Platform(float x, float y, Vector2 sizeType){
			position = new Vector2(x, y);
			speed = new Vector2(Background.DEFAULT_SPEED.X, 0);
			size = sizeType;
			bound = new Rectangle((int)x, (int)y, (int)size.X, (int)size.Y);
			if(y > (Game1.screenSize.Y / 2)) {
				type = Platform.TYPE_GROUND;
			}
			else {
				type = Platform.TYPE_SKY;
			}
		}

		public Platform(Vector2 position, Vector2 sizeType){
			position = new Vector2(position.X, position.Y);
			speed = new Vector2(Background.DEFAULT_SPEED.X, 0);
			size = sizeType;
			bound = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
			if(position.Y > (Game1.screenSize.Y / 2)) {
				type = Platform.TYPE_GROUND;
			}
			else {
				type = Platform.TYPE_SKY;
			}
		}

		public void update() {
			position += Background.simultanSpeed;
			bound.Offset((int)(position.X-bound.Left), (int)(position.Y-bound.Top));
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

		public int getType() {
			return type;
		}

		public void setPos(float x, float y, bool corner){
			if(corner) {
				position.X = x;
				position.Y = y;
			}
			else {
				position.X = x - (size.X / 2);
				position.Y = y - (size.Y / 2);
			}
		}
	}
}
