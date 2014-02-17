using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
<<<<<<< HEAD
using Microsoft.Xna.Framework.Media;
=======
>>>>>>> 1e5995f41b29c1f9c72aad7f7c1df53c04cfb3f8

namespace RunRun.Game_Classes {
	public class GameHandler {

		private readonly float maxMotionTime = 500;
		private float motionTime;
		private bool addMotionTime;
		private Character character;
		private Platforms platforms;
		private Obstacles obstacles, spikes;
		//private Pointers pointers;
		private Projectiles projectiles;
		private Coins coins;
		private Background bg1, bg2, sky, sky2;
		private int delayProjectiles, delayCoins, delayObstacles;
		private bool freeze;
		private float runTime;
		private Animation hero, flipHero, motionEffect;
		private Random random;
		private int DELAY_MIN_PRO, DELAY_MAX_PRO;
<<<<<<< HEAD
        private bool songstart = false;
        private Song bgmplay;
=======
>>>>>>> 1e5995f41b29c1f9c72aad7f7c1df53c04cfb3f8
		public int state;
		public static readonly int STATE_ALIVE = 0;
		public static readonly int STATE_DEAD = 1;
		

		public GameHandler() {
			character = new Character(0);
			platforms = new Platforms();
			obstacles = new Obstacles();
			spikes = new Obstacles();
			//pointers = new Pointers();
			projectiles = new Projectiles();
			coins = new Coins();
			bg1 = new Background(0, 0, Background.NORMAL);
			bg2 = new Background(1512, 0, Background.NORMAL);
			sky = new Background(0, 0, Background.FAR);
			sky2 = new Background(1512, 0, Background.FAR);
			sky.setSpeed(-1, 0);
			sky2.setSpeed(-1, 0);
			platforms.addPlatform(0, Platform.DEFAULT_GROUND_Y, Platform.SIZE_TYPE_4);
			platforms.addPlatform(platforms.getLast().getBound().Right, Platform.DEFAULT_GROUND_Y, Platform.SIZE_TYPE_4);
			delayProjectiles = 0; delayCoins = 0; delayObstacles = 0;
			motionTime = 0;
			addMotionTime = false;
			state = GameHandler.STATE_ALIVE;
			hero = new Animation(Animation.DEPENDENT_SPEED);
			flipHero = new Animation(Animation.DEPENDENT_SPEED);
			freeze = false;
			random = new Random();
			motionEffect = new Animation(Animation.INDEPENDENT_SPEED);
			DELAY_MIN_PRO=2000;
			DELAY_MAX_PRO = 5000;
		}

		public void newLevel() {
			Game1.gameSpeed = 1;
			character = new Character(0);
			platforms = new Platforms();
			obstacles = new Obstacles();
			spikes = new Obstacles();
			//pointers = new Pointers();
			projectiles = new Projectiles();
			bg1 = new Background(0, 0, Background.NORMAL);
			bg2 = new Background(1512, 0, Background.NORMAL);
			sky = new Background(0, 0, Background.FAR);
			sky2 = new Background(1512, 0, Background.FAR);
			sky.setSpeed(-1, 0);
			sky2.setSpeed(-1, 0);
			coins = new Coins();
			platforms.addPlatform(0, Platform.DEFAULT_GROUND_Y, Platform.SIZE_TYPE_4);
			platforms.addPlatform(platforms.getLast().getBound().Right, Platform.DEFAULT_GROUND_Y, Platform.SIZE_TYPE_4);
			delayProjectiles = 0; delayCoins = 0; delayObstacles = 0;
			motionTime = 0;
			addMotionTime = false;
			state = GameHandler.STATE_ALIVE;
			freeze = false;
			DELAY_MIN_PRO=2000;
			DELAY_MAX_PRO = 5000;
		}

		public void update(GameTime gameTime) {
			if(character.health > 0){
				state = GameHandler.STATE_ALIVE;
			}
			else{
				state = GameHandler.STATE_DEAD;
				Game1.gameSpeed = 0;
			}
			if(state == GameHandler.STATE_ALIVE){
				updateRunning(gameTime);
			}
				
			else if(state == GameHandler.STATE_DEAD) {
				updateGameOver(gameTime);
				Game1.gameSpeed = 0;
			}
		}

		public void draw(SpriteBatch spriteBatch, GameTime gameTime) {
			if(state == GameHandler.STATE_ALIVE)
				freeze = false;
			else if(state == GameHandler.STATE_DEAD)
				freeze = true;
			drawRunning(spriteBatch, gameTime);
			//else if(state == GameHandler.STATE_DEAD)
				//drawGameOver(spriteBatch, gameTime);
		}

		public void updateRunning(GameTime gameTime) {
			GestureSample gesture;
			while(TouchPanel.IsGestureAvailable) {
				gesture = TouchPanel.ReadGesture();
				//pointers.addPointer(gesture.Position);
				switch(gesture.GestureType) {
				case GestureType.Tap:
					if(platforms.getPlatforms().Count < Platforms.MAX_COUNT) {
						if(platforms.lastType == Platform.TYPE_GROUND) {
							if(platforms.lastSky != null) {
								if(platforms.lastSky.getBound().Right < character.getBound().Right - 5) {
									platforms.addPlatform(character.getBound().Right - 5/*+ 40*/, Platform.DEFAULT_SKY_Y, Platform.SIZE_TYPE_1);
								}
								else {
									platforms.addPlatform(platforms.lastSky.getBound().Right, Platform.DEFAULT_SKY_Y, Platform.SIZE_TYPE_1);
								}
							}
							else {
								platforms.addPlatform(character.getBound().Right - 5/*+ 40*/, Platform.DEFAULT_SKY_Y, Platform.SIZE_TYPE_1);
							}
						}
						else if(platforms.lastType == Platform.TYPE_SKY) {
							if(platforms.lastGround != null) {
								if(platforms.lastGround.getBound().Right < character.getBound().Right - 5) {
									platforms.addPlatform(character.getBound().Right - 5/*+ 40*/, Platform.DEFAULT_GROUND_Y, Platform.SIZE_TYPE_1);
								}
								else {
									platforms.addPlatform(platforms.lastGround.getBound().Right, Platform.DEFAULT_GROUND_Y, Platform.SIZE_TYPE_1);
								}
							}
							else {
								platforms.addPlatform(character.getBound().Right - 5/*+ 40*/, Platform.DEFAULT_GROUND_Y, Platform.SIZE_TYPE_1);
							}
						}
					}
					break;
				case GestureType.HorizontalDrag:
					if(gesture.Delta.X > 10 && !addMotionTime) {
						Game1.gameSpeed = 2;
						addMotionTime = true;
						motionEffect.reset();
					}
					else if(gesture.Delta.X < -10 && !addMotionTime) {
						Game1.gameSpeed = 0.5f;
						addMotionTime = true;
						motionEffect.reset();
					}
					break;
				case GestureType.VerticalDrag: 

					break;

				case GestureType.DragComplete:
					Game1.gameSpeed = 1;
					addMotionTime = false;
					break;
				}
			}
			if(addMotionTime) {
				motionTime += gameTime.ElapsedGameTime.Milliseconds;
				motionEffect.animate(gameTime);
			}
			else {
				if(motionTime > 0) {
					motionTime -= gameTime.ElapsedGameTime.Milliseconds / 5;
				}
				else {
					motionTime = 0;
				}
			}
			if(motionTime > maxMotionTime) {
				Game1.gameSpeed = 1;
				addMotionTime = false;
			}
			delayObstacles += gameTime.ElapsedGameTime.Milliseconds;
			delayProjectiles += gameTime.ElapsedGameTime.Milliseconds;
			delayCoins += gameTime.ElapsedGameTime.Milliseconds;
			if (DELAY_MIN_PRO>400){
				DELAY_MIN_PRO = DELAY_MIN_PRO - (gameTime.ElapsedGameTime.Milliseconds / 40);
			}
			if (DELAY_MAX_PRO > 1000){
				DELAY_MAX_PRO = DELAY_MAX_PRO - (gameTime.ElapsedGameTime.Milliseconds / 40);
			}
			if(delayProjectiles > random.Next(DELAY_MIN_PRO,DELAY_MAX_PRO)) {
				delayProjectiles = 0;
				projectiles.addProjectile(Game1.screenSize.X, new Random().Next((int)Game1.screenSize.Y - (int)Platform.SIZE_TYPE_1.Y));
			}
			if(delayCoins > random.Next(4000,10000)) {
				delayCoins = 0;
				coins.addCoin(Game1.screenSize.X + Coin.DEFAULT_SIZE.X, (float)random.Next((int)(Platform.SIZE_TYPE_1.Y), (int)(Game1.screenSize.Y - Platform.SIZE_TYPE_1.Y)));
			}
			if(delayObstacles > random.Next(500, 2000)) {
				delayObstacles = 0;
				obstacles.addObstacle(Game1.screenSize.X, new Random().Next((int)Game1.screenSize.Y - (int)Platform.SIZE_TYPE_1.Y));
			}
			if(delayObstacles > random.Next(10000, 20000)) {
				delayObstacles = 0;
				spikes.addObstacle(Game1.screenSize.X, new Random().Next((int)Game1.screenSize.Y - (int)Platform.SIZE_TYPE_1.Y));
			}
			character.update(platforms, obstacles, spikes);
			bg1.update();
			bg2.update();
			sky.update();
			sky2.update();
			platforms.update();
			projectiles.update(character);
			obstacles.update();
			spikes.update();
			coins.update(character);
			hero.animate(gameTime);
			flipHero.animate(gameTime);
			//pointers.update(gameTime.ElapsedGameTime.Milliseconds);
		}

		public void updateGameOver(GameTime gameTime) {
			GestureSample gesture;
			while(TouchPanel.IsGestureAvailable) {
				gesture = TouchPanel.ReadGesture();
				//pointers.addPointer(gesture.Position);
				switch(gesture.GestureType) {
				case GestureType.Tap:
					Game1.gameState.top_level_state = GameStateNumbers.MENU_STATE_ROOT;
					break;
				}
			}
		}

		public void drawRunning(SpriteBatch spriteBatch, GameTime gameTime) {
			if(!freeze)
				runTime += gameTime.ElapsedGameTime.Milliseconds;
<<<<<<< HEAD

=======
>>>>>>> 1e5995f41b29c1f9c72aad7f7c1df53c04cfb3f8
			spriteBatch.Draw(Assets.sky1, sky.getPos(), Color.White);
			spriteBatch.Draw(Assets.sky2, sky2.getPos(), Color.White);
			spriteBatch.Draw(Assets.background1, bg1.getPos(), Color.White);
			spriteBatch.Draw(Assets.background2, bg2.getPos(), Color.White);
			
			// Draw platforms + check active platform
			Character.curPlatforms = -1;
			int n;
			Platform platform;
			n = platforms.getSize();
			for(int i = 0; i < n; i++) {
				platform = platforms.getPlatform(i);
				if(character.getBound().Center.X > platform.getPos().X - Character.EXTRA_SPACE &&
					character.getBound().Center.X < platform.getPos().X + platform.getSize().X + Character.EXTRA_SPACE){
					Character.curPlatforms = i;
				}
				if(Character.lastCurPlat < Character.curPlatforms)
						Character.lastCurPlat = Character.curPlatforms;
				if(i >= Character.lastCurPlat)
					spriteBatch.Draw(Assets.metal2, platform.getBound(), Color.White);
				else
					spriteBatch.Draw(Assets.platformNCT, platform.getBound(), Color.White);
			}
			n = projectiles.getSize();
			for(int i = 0; i < n; i++) {
				spriteBatch.Draw(Assets.projectile, projectiles.getProjectile(i).getBound(), Color.White);
			}
			n = coins.getSize();
			for(int i = 0; i < n; i++) {
				spriteBatch.Draw(Assets.coin, coins.getCoin(i).getBound(), Color.White);
			}
			n = obstacles.getSize();
			for(int i = 0; i < n; i++) {
				spriteBatch.Draw(Assets.platformNCT, obstacles.getObstacle(i).getBound(), Color.White);
			}
			n = spikes.getSize();
			for(int i = 0; i < n; i++) {
				spriteBatch.Draw(Assets.spike1, spikes.getObstacle(i).getBound(), Color.White);
			}
			//pointers.draw(spriteBatch);
			if(character.state == Character.STATE_BOTTOM || character.state == Character.STATE_SKY_DOWN) {
				if(hero.sprites.Count > 0)
					spriteBatch.Draw(hero.getSprite(gameTime), character.getBound(), Color.White);
			}
			else if(character.state == Character.STATE_SKY_UP || character.state == Character.STATE_TOP) {
				if(flipHero.sprites.Count > 0)
					spriteBatch.Draw(flipHero.getSprite(gameTime), character.getBound(), Color.White);
			}
			if(Game1.gameSpeed != 1 && addMotionTime && motionEffect.sprites.Count > 0 && motionEffect.getLoopCounter() < 1) {
				spriteBatch.Draw(motionEffect.getSprite(gameTime), new Rectangle(0, 0, 800, 480), Color.White);
			}
				

			
			// status bar
			StringBuilder a = new StringBuilder("Distance: ");
			a.Append((character.getDistance()/20).ToString("n1"));
			a.Append(" m");
			spriteBatch.DrawString(Game1.font1, a.ToString(), new Vector2(0, 0), Color.Red);
			a.Clear();
			a.Append(character.points.ToString());
			spriteBatch.Draw(Assets.coin, new Rectangle(180, 3, 20, 20), Color.White);
			spriteBatch.DrawString(Game1.font1, a.ToString(), new Vector2(205, 0), Color.Red);
			a.Clear();
			a.Append(character.health);
			spriteBatch.Draw(Assets.heart, new Rectangle(255, 3, 20, 20), Color.White);
			spriteBatch.DrawString(Game1.font1, a.ToString(), new Vector2(280, 0), Color.Red);
			a.Clear();
			a.Append((Platforms.MAX_COUNT - platforms.getSize()).ToString());
			spriteBatch.Draw(Assets.metal2, new Rectangle(325, 3, 20, 20), Color.White);
			spriteBatch.DrawString(Game1.font1, a.ToString(), new Vector2(350, 0), Color.Red);
			a.Clear();
			a.Append(((maxMotionTime - motionTime)/1000).ToString("n2"));
			spriteBatch.Draw(Assets.timer, new Rectangle(400, 3, 20, 20), Color.White);
			spriteBatch.DrawString(Game1.font1, a.ToString(), new Vector2(425, 0), Color.Red);
			if(state == GameHandler.STATE_DEAD) {
				spriteBatch.Draw(Assets.gameOver, new Rectangle(0, 0, (int)Game1.screenSize.X, (int)Game1.screenSize.Y), Color.White);
			}
		}

		public void drawGameOver(SpriteBatch spriteBatch, GameTime gameTime) {

		}

		public Character getCharacter() {
			return character;
		}

		public void setState(int state) {
			this.state = state;
		}

		public void initializeAnimation() {
			
			hero.addSprite(Assets.char1, 100);
			hero.addSprite(Assets.char2, 100);
			hero.addSprite(Assets.char3, 100);
			hero.addSprite(Assets.char4, 100);
			//hero.addSprite(Assets.char5, 100);
			//hero.addSprite(Assets.char4, 100);
			hero.addSprite(Assets.char3, 100);
			hero.addSprite(Assets.char2, 100);
			
			motionEffect.addSprite(Assets.slowEffect1, 40);
			motionEffect.addSprite(Assets.slowEffect2, 40);
			motionEffect.addSprite(Assets.slowEffect3, 40);
			motionEffect.addSprite(Assets.slowEffect4, 40);
			motionEffect.addSprite(Assets.slowEffect5, 40);
			motionEffect.addSprite(Assets.slowEffect6, 40);
			motionEffect.addSprite(Assets.slowEffect7, 40);
			motionEffect.addSprite(Assets.slowEffect8, 40);
			motionEffect.addSprite(Assets.slowEffect9, 40);


			flipHero.addSprite(Assets.fchar1, 100);
			flipHero.addSprite(Assets.fchar2, 100);
			flipHero.addSprite(Assets.fchar3, 100);
			flipHero.addSprite(Assets.fchar4, 100);
			//flipHero.addSprite(Assets.fchar5, 100);
			//flipHero.addSprite(Assets.fchar4, 100);
			flipHero.addSprite(Assets.fchar3, 100);
			flipHero.addSprite(Assets.fchar2, 100);

			
		}
	}
}
