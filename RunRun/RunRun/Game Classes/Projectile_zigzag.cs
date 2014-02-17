using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
namespace RunRun.Game_Classes
{
	public class Projectile_zigzag : Projectile
	{
		private int DEFAULT_SPEED_Y=8;
		private Random random;
		public Projectile_zigzag(Vector2 position) {
			random = new Random();
			this.position = position;
			size = new Vector2(20, 20);
			if (random.Next(2)==0){
				speed = new Vector2(-8, -1*DEFAULT_SPEED_Y);
			}
			else {
				speed = new Vector2(-8, DEFAULT_SPEED_Y);
			}
			
			bound = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
		}
		public Projectile_zigzag(float x, float y)
		{
			random = new Random();
			position = new Vector2(x, y);
			size = new Vector2(20, 20);
			if (random.Next(2) == 0){
				speed = new Vector2(-8, -1 * DEFAULT_SPEED_Y);
			}
			else{
				speed = new Vector2(-8, DEFAULT_SPEED_Y);
			}
			bound = new Rectangle((int)x, (int)y, (int)size.X, (int)size.Y);
		}
		public override void update (){
			
			if (position.Y <= Platform.DEFAULT_SKY_Y + Platform.SIZE_TYPE_1.Y + random.Next(200)){
				speed.Y = DEFAULT_SPEED_Y;
			}
			else if (position.Y >= Platform.DEFAULT_GROUND_Y - 10 - random.Next(200)){
				speed.Y = -1*DEFAULT_SPEED_Y;
			}
			base.update();
		}
	}
}
