using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace RunRun{
	public class Animation{
		public List<Texture2D> sprites;
		List<float> duration;
		float totalDuration, timePassed;
		int curSprite, type, counter;
		public static readonly int INDEPENDENT_SPEED = 0;
		public static readonly int DEPENDENT_SPEED = 1;

		public Animation(int type){
			sprites = new List<Texture2D>();
			duration = new List<float>();
			totalDuration = 0;
			curSprite = 0;
			timePassed = 0;
			counter = 0;
			this.type = type;
		}

		public void reset(){
			totalDuration = 0;
			curSprite = 0;
			timePassed = 0;
			counter = 0;
		}

		public void addSprite(Texture2D sprite, float delay) {
			sprites.Add(sprite);
			totalDuration += delay;
			duration.Add(totalDuration);
		}

		public Texture2D getSprite(GameTime gameTime) {
			return sprites.ElementAt(curSprite);
		}

		public int getLoopCounter() {
			return counter;
		}

		public void animate(GameTime gameTime) {
			if(type == Animation.DEPENDENT_SPEED)
				timePassed += (gameTime.ElapsedGameTime.Milliseconds * Game1.gameSpeed);
			else if(type == Animation.INDEPENDENT_SPEED)
				timePassed += gameTime.ElapsedGameTime.Milliseconds;
			if(timePassed > duration.ElementAt(curSprite)) {
				curSprite++;
			}
			if(curSprite > sprites.Count - 1) {
				timePassed = 0;
				curSprite = 0;
				counter++;
			}
		}
	}
}
