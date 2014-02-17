using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
<<<<<<< HEAD
using Microsoft.Xna.Framework.Media;
=======
>>>>>>> 1e5995f41b29c1f9c72aad7f7c1df53c04cfb3f8

namespace RunRun.Game_Classes {
	public class Character {

		public readonly static float HEIGHT = 39;
		public readonly static float WIDTH = 27;
		public readonly static float EXTRA_SPACE = 20;
		public readonly static int STATE_TOP = 0;
		public readonly static int STATE_BOTTOM = 1;
		public readonly static int STATE_SKY_DOWN = 2;
		public readonly static int STATE_SKY_UP = 3;
		public static readonly int DEFAULT_HEALTH = 3;
		public static readonly int COLLISION_X = 0;
		public static readonly int COLLISION_Y = 1;
		public static readonly int DEFAULT_POS_X = 200;
		public static int curPlatforms, lastCurPlat;
		public bool goBottom, goTop;
		private Vector2 position, speed, size;
		private float distance;
		private Rectangle bound, colliBound, drawBound;
<<<<<<< HEAD
        private bool songstart = false;
=======
>>>>>>> 1e5995f41b29c1f9c72aad7f7c1df53c04cfb3f8
		public int state;
		public int health;
		public int points;

		public Character(float y) {
			position = new Vector2(Character.DEFAULT_POS_X, y);
			speed = new Vector2(0, 0);
			size = new Vector2(Character.WIDTH, Character.HEIGHT);
			bound = new Rectangle((int)Character.DEFAULT_POS_X-15, (int)y, (int)Character.WIDTH+15, (int)Character.HEIGHT);
			drawBound = new Rectangle((int)Character.DEFAULT_POS_X, (int)y, (int)Character.WIDTH, (int)Character.HEIGHT);
			colliBound = new Rectangle((int)Character.DEFAULT_POS_X+10, (int)y+10, (int)Character.WIDTH-10, (int)Character.HEIGHT-20);
			curPlatforms = -1;
			goBottom = true;
			goTop = false;
			state = Character.STATE_BOTTOM;
			health = Character.DEFAULT_HEALTH;
			distance = 0;
			points = 0;
		}

		public void update(Platforms platforms, Obstacles obstacles, Obstacles spikes) {
			
			if(goBottom) {
				if(speed.Y < 40)
					speed.Y += 2*Game1.gameSpeed;
				goTop = false;
				if(speed.Y > 5)
					state = Character.STATE_SKY_DOWN;
			}
			if(goTop) {
				if(speed.Y > -40)
					speed.Y -= 2*Game1.gameSpeed;
				goBottom = false;
				if(speed.Y < -5)
					state = Character.STATE_SKY_UP;
			}
			if(curPlatforms != -1) {
				Platform platform = platforms.getPlatform(curPlatforms);
				if(platform.getType() == Platform.TYPE_GROUND) {
					if(goTop)
						speed.Y = 0;
					goBottom = true;
					goTop = false;
					if(bound.Intersects(platform.getBound())){
						if(getCollisionType(platform.getBound()) == Character.COLLISION_Y) {
							speed.Y = 0;
							goBottom = false;
							position.Y = platform.getBound().Top - Character.HEIGHT+1;
							state = Character.STATE_BOTTOM;
							if(position.X < Character.DEFAULT_POS_X) {
								speed.X = 3;
							}
						}
						else if(getCollisionType(platform.getBound()) == Character.COLLISION_X){
							position.X = platform.getBound().Left - Character.WIDTH + 1;
						}
					}
				}
				else {
					if(goBottom)
						speed.Y = 0;
					goTop = true;
					goBottom = false;
					if(bound.Intersects(platform.getBound())) {
						speed.Y = 0;
						goTop = false;
						position.Y = platform.getBound().Bottom -1;
						state = Character.STATE_TOP;
						if(position.X < Character.DEFAULT_POS_X) {
							speed.X = 3;
						}
					}
				}
			}
			else {
				goBottom = true;
				if(goTop) {
					goTop = false;
					speed.Y = 0;
				}

			}
			if(position.X > Character.DEFAULT_POS_X) {
				position.X = Character.DEFAULT_POS_X;
				speed.X = 0;
			}
			int n = obstacles.getSize();
			int i = 0;
			Rectangle rect;
			while(i < n) {
				rect = obstacles.getObstacle(i).getBound();
				if(bound.Intersects(rect)){
					if(getCollisionType(rect) == Character.COLLISION_Y) {
						if(drawBound.Center.Y < rect.Center.Y  && (state == Character.STATE_SKY_DOWN || state == Character.STATE_BOTTOM)) {
							speed.Y = 0;
							goBottom = false;
							position.Y = rect.Top - Character.HEIGHT + 1;
						}
						else if(drawBound.Center.Y > rect.Center.Y && (state == Character.STATE_SKY_UP || state == Character.STATE_TOP)) {
							speed.Y = 0;
							position.Y = rect.Bottom - 1;
						}
						if(position.X < Character.DEFAULT_POS_X) {
							speed.X = 3;
						}
						if(position.X > Character.DEFAULT_POS_X) {
							position.X = Character.DEFAULT_POS_X;
							speed.X = 0;
						}
					}
					else if(getCollisionType(rect) == Character.COLLISION_X && drawBound.Center.X < rect.Center.X){
						position.X = rect.Left - Character.WIDTH + 1;
					}
				}
				i++;
			}
			
			for(i = 0; i < n;i++ ) {
				rect = obstacles.getObstacle(i).getDeathBound();
				if(bound.Intersects(rect)) {
<<<<<<< HEAD
                    if (!songstart)
                    {
                        MediaPlayer.Play(Assets.ScreamBGM);
                        songstart = true;
                    }
                    songstart = false;
                    MediaPlayer.Stop();
					health--;
					position.X = Character.DEFAULT_POS_X;
					position.Y = Platform.DEFAULT_SKY_Y + Platform.SIZE_TYPE_1.Y;
                    songstart = false;
                    MediaPlayer.Stop();
=======
					health--;
					position.X = Character.DEFAULT_POS_X;
					position.Y = Platform.DEFAULT_SKY_Y + Platform.SIZE_TYPE_1.Y;
>>>>>>> 1e5995f41b29c1f9c72aad7f7c1df53c04cfb3f8
				}
				i++;
			}
			if(position.Y > Game1.screenSize.Y + 70 || position.X < -100) {
				position.Y = Game1.screenSize.Y - 200;
				if(health > 0)
					position.X = Character.DEFAULT_POS_X;
				platforms.addPlatform(position.X + 30, Platform.DEFAULT_GROUND_Y, Platform.SIZE_TYPE_1);
				speed.Y = 0;
				health--;
			}
			distance += (-1 * Background.simultanSpeed.X);
			position += (speed * Game1.gameSpeed);
			bound.Offset((int)(position.X - bound.Left), (int)(position.Y - bound.Top));
			drawBound.Offset((int)(position.X - drawBound.Left), (int)(position.Y - drawBound.Top));
			colliBound.Offset((int)(10 + position.X - colliBound.Left), (int)(10 + position.Y - colliBound.Top));
		}

		public void setPos(float x, float y, bool corner) {
			if(corner) {
				position.X = x;
				position.Y = y;
			}
			else {
				position.X = x - (size.X / 2);
				position.Y = y - (size.Y / 2);
			}
		}

		public int getCollisionType(Rectangle rect) {
			
			// objek di kanan
			if(bound.Center.X < rect.Center.X) {
				// objek di bawah
				if(bound.Center.Y < rect.Center.Y) {
					if((bound.Bottom)-(rect.Top) < (bound.Right)-(rect.Left)){
						return Character.COLLISION_Y;
					}
					else{
						return Character.COLLISION_X;
					}
				}
				//objek di atas
				else {
					if((rect.Bottom)-(bound.Top) < (bound.Right)-(rect.Left)){
						return Character.COLLISION_Y;
					}
					else{
						return Character.COLLISION_X;
					}
				}

			}

			//objek di kiri
			else {
				// objek di bawah
				if(bound.Center.Y < rect.Center.Y) {
					if((bound.Bottom)-(rect.Top) < (rect.Right)-(bound.Left)){
						return Character.COLLISION_Y;
					}
					else{
						return Character.COLLISION_X;
					}
				}
				//objek di atas
				else {
					if((rect.Bottom)-(bound.Top) < (rect.Right)-(bound.Left)){
						return Character.COLLISION_Y;
					}
					else{
						return Character.COLLISION_X;
					}
				}
			}

		}

		public Vector2 getPos() {
			return position;
		}

		public Rectangle getBound() {
			return drawBound;
		}

		public Rectangle getColliBound() {
			return colliBound;
		}

		public float getDistance() {
			return distance;
		}

	}
}
