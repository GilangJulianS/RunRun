using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using RunRun.Game_Classes;
using System.Diagnostics;

namespace RunRun{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Microsoft.Xna.Framework.Game{

		public static float gameSpeed = 1;
		public static Vector2 screenSize;
		public GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Input input;
		List<GestureSample> gestures;
		GameHandler world;
		public static SpriteFont font1;

		GraphicsDeviceManager graphicsMenu;
		SpriteBatch spriteBatchMenu;

		public static GameStateNumbers gameState = new GameStateNumbers();

		Texture2D MenuBG;
		Texture2D EndFG;
		Texture2D QuitBG;
		Texture2D TutorialBG;
<<<<<<< HEAD
        Texture2D QuitAsk;

        private bool songstart = false;
=======
>>>>>>> 1e5995f41b29c1f9c72aad7f7c1df53c04cfb3f8

		MenuButton ExitButton = new MenuButton();
		MenuButton PlayButton = new MenuButton();
		MenuButton TutorialButton = new MenuButton();
		MenuButton YesButton = new MenuButton();
		MenuButton NoButton = new MenuButton();
		MenuButton BackButton = new MenuButton();

		public Game1(){
			graphics = new GraphicsDeviceManager(this){
				PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, 
				PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height,
				IsFullScreen = true,
			};
			Content.RootDirectory = "Content";
			// Frame rate is 30 fps by default for Windows Phone.
			TargetElapsedTime = TimeSpan.FromTicks(333333);

			// Extend battery life under lock.
			InactiveSleepTime = TimeSpan.FromSeconds(1);
			
			
			// World initialization
			input = new Input();
			gestures = new List<GestureSample>();
			world = new GameHandler();
			screenSize = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height, 
				GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width);
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize(){
			TouchPanel.EnabledGestures = GestureType.Tap | GestureType.HorizontalDrag | GestureType.VerticalDrag | GestureType.DragComplete;
			
			//menu
<<<<<<< HEAD
			PlayButton.pos = new Vector2(780, 40);
			TutorialButton.pos = new Vector2(780, 170);
			ExitButton.pos = new Vector2(790, 300);
=======
			PlayButton.pos = new Vector2(900, 100);
			TutorialButton.pos = new Vector2(900, 220);
			ExitButton.pos = new Vector2(900, 340);
>>>>>>> 1e5995f41b29c1f9c72aad7f7c1df53c04cfb3f8
			YesButton.pos = new Vector2(-100, 380);
			NoButton.pos = new Vector2(800, 380);
			BackButton.pos = new Vector2(-100, 30);

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent(){
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
			Assets.char1 = Content.Load<Texture2D>("Bitmap/fChar1");
			Assets.char2 = Content.Load<Texture2D>("Bitmap/fChar2");
			Assets.char3 = Content.Load<Texture2D>("Bitmap/fChar3");
			Assets.char4 = Content.Load<Texture2D>("Bitmap/fChar4");
			//Assets.char5 = Content.Load<Texture2D>("Bitmap/nChar5");
			Assets.fchar1 = Content.Load<Texture2D>("Bitmap/flipChar1");
			Assets.fchar2 = Content.Load<Texture2D>("Bitmap/flipChar2");
			Assets.fchar3 = Content.Load<Texture2D>("Bitmap/flipChar3");
			Assets.fchar4 = Content.Load<Texture2D>("Bitmap/flipChar4");
			//Assets.fchar5 = Content.Load<Texture2D>("Bitmap/nflipChar5");
			Assets.pointer = Content.Load<Texture2D>("Bitmap/Pointer");
			//Assets.motionEffect = Content.Load<Texture2D>("Bitmap/MotionEffect");
			Assets.slowEffect1 = Content.Load<Texture2D>("Bitmap/nEffect1");
			Assets.slowEffect2 = Content.Load<Texture2D>("Bitmap/nEffect2");
			Assets.slowEffect3 = Content.Load<Texture2D>("Bitmap/nEffect3");
			Assets.slowEffect4 = Content.Load<Texture2D>("Bitmap/nEffect4");
			Assets.slowEffect5 = Content.Load<Texture2D>("Bitmap/nEffect5");
			Assets.slowEffect6 = Content.Load<Texture2D>("Bitmap/nEffect6");
			Assets.slowEffect7 = Content.Load<Texture2D>("Bitmap/nEffect7");
			Assets.slowEffect8 = Content.Load<Texture2D>("Bitmap/nEffect8");
			Assets.slowEffect9 = Content.Load<Texture2D>("Bitmap/nEffect9");
			Assets.metal2 = Content.Load<Texture2D>("Bitmap/Metal2");
			Assets.platform = Content.Load<Texture2D>("Bitmap/Platform");
			Assets.platformNCT = Content.Load<Texture2D>("Bitmap/PlatformNCT");
			Assets.background1 = Content.Load<Texture2D>("Bitmap/Background1");
			Assets.background2 = Content.Load<Texture2D>("Bitmap/Background2");
			Assets.projectile = Content.Load<Texture2D>("Bitmap/Projectile");
			Assets.coin = Content.Load<Texture2D>("Bitmap/Coin");
			Assets.heart = Content.Load<Texture2D>("Bitmap/Heart");
			Assets.timer = Content.Load<Texture2D>("Bitmap/Timer");
			Assets.sky1 = Content.Load<Texture2D>("Bitmap/Sky1");
			Assets.sky2 = Content.Load<Texture2D>("Bitmap/Sky2");
			Assets.spike1 = Content.Load<Texture2D>("Bitmap/spike1");
			Assets.spike2 = Content.Load<Texture2D>("Bitmap/spike2");
			Assets.gameOver = Content.Load<Texture2D>("Bitmap/GameOver");
			Game1.font1 = Content.Load<SpriteFont>("Font/font1");
<<<<<<< HEAD

            MediaPlayer.IsRepeating = true;
            Assets.PlayBGM = Content.Load<Song>("BGM/PlayBGM");
            Assets.ScreamBGM = Content.Load<Song>("BGM/scream");

=======
			
>>>>>>> 1e5995f41b29c1f9c72aad7f7c1df53c04cfb3f8
			// menu content 
			spriteBatchMenu = new SpriteBatch(GraphicsDevice);

			MenuBG = Content.Load<Texture2D>("Button/bg");
			EndFG = Content.Load<Texture2D>("Button/endgamefg");
			QuitBG = Content.Load<Texture2D>("Button/quitgamebg");
			TutorialBG = Content.Load<Texture2D>("Button/tutorialbg");
<<<<<<< HEAD
            QuitAsk = Content.Load<Texture2D>("Button/quitgame");
=======
>>>>>>> 1e5995f41b29c1f9c72aad7f7c1df53c04cfb3f8

			ExitButton.texture = Content.Load<Texture2D>("Button/exitbutton");
			PlayButton.texture = Content.Load<Texture2D>("Button/playbutton");
			TutorialButton.texture = Content.Load<Texture2D>("Button/tutorialbutton");

			YesButton.texture = Content.Load<Texture2D>("Button/yesbutton");
			NoButton.texture = Content.Load<Texture2D>("Button/nobutton");

			BackButton.texture = Content.Load<Texture2D>("Button/backbutton");
			
			world.initializeAnimation();
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent(){
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime){
			// Allows the game to exit
			
			// TODO: Add your update logic here
			switch (gameState.top_level_state)
			{
				case GameStateNumbers.STATE_MENU:
					MenuMain();
					break;
				case GameStateNumbers.STATE_PLAY:
					GameMain(gameTime);
					break;
				case GameStateNumbers.STATE_EXIT:
					ExitMain();
					break;
				default:
					// Exit Function
					break;
			};
			
			base.Update(gameTime);
			
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime){
			GraphicsDevice.Clear(Color.DarkViolet);
			// TODO: Add your drawing code here
			GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatchMenu.Begin();

			switch (gameState.top_level_state)
			{
				case GameStateNumbers.STATE_MENU:

					#region Draw Main Menu/Tutorial

					switch (gameState.menu_level_state)
					{
						case GameStateNumbers.MENU_STATE_ROOT:

							#region Buttons

							spriteBatchMenu.Draw(MenuBG, new Vector2(0, 0), Color.White);
							spriteBatchMenu.Draw(ExitButton.texture, ExitButton.pos, Color.White);
							spriteBatchMenu.Draw(PlayButton.texture, PlayButton.pos, Color.White);
							spriteBatchMenu.Draw(TutorialButton.texture, TutorialButton.pos, Color.White);
							spriteBatchMenu.DrawString(font1, "Gilang Julian S.",new Vector2(30, 30), Color.White);
							spriteBatchMenu.DrawString(font1, "Yanfa Adi P.",new Vector2(30, 80), Color.White);
							spriteBatchMenu.DrawString(font1, "Riady Sastra K.",new Vector2(30, 130), Color.White);
							spriteBatchMenu.DrawString(font1, "Linda Sekawati",new Vector2(30, 180), Color.White);
							#endregion

							break;

						case GameStateNumbers.MENU_STATE_TUTORIAL:

							spriteBatchMenu.Draw(TutorialBG, new Vector2(0, 0), Color.White);

							#region Buttons

							spriteBatchMenu.Draw(BackButton.texture, BackButton.pos, Color.White);

							#endregion

							break;
					}

					#endregion

					break;

				case GameStateNumbers.STATE_PLAY:

					#region Draw Game

					drawWorld(gameTime);

					#region Pause Draw

					if (gameState.game_level_state == GameStateNumbers.GAME_STATE_PAUSE)
					{
<<<<<<< HEAD
						spriteBatchMenu.Draw(EndFG, new Vector2(215,270), Color.White);
=======
						spriteBatchMenu.Draw(EndFG, new Vector2(0, 0), Color.White);
>>>>>>> 1e5995f41b29c1f9c72aad7f7c1df53c04cfb3f8

						#region Buttons

						spriteBatchMenu.Draw(YesButton.texture, YesButton.pos, Color.White);
						spriteBatchMenu.Draw(NoButton.texture, NoButton.pos, Color.White);

						#endregion

					}

					#endregion

					#endregion

					break;

				case GameStateNumbers.STATE_EXIT:

					#region Draw Quit Screen

					spriteBatchMenu.Draw(QuitBG, new Vector2(0, 0), Color.White);
<<<<<<< HEAD
                    spriteBatchMenu.Draw(QuitAsk, new Vector2(215, 270), Color.White);
=======
>>>>>>> 1e5995f41b29c1f9c72aad7f7c1df53c04cfb3f8

					#region Buttons

					spriteBatchMenu.Draw(YesButton.texture, YesButton.pos, Color.White);
					spriteBatchMenu.Draw(NoButton.texture, NoButton.pos, Color.White);

					#endregion

					#endregion

					break;
			};

			spriteBatchMenu.End();
			base.Draw(gameTime);
		}

		protected void drawWorld(GameTime gameTime){
			spriteBatch.Begin();
			world.draw(spriteBatch, gameTime);
			spriteBatch.End();
		}

		void MenuMain()
		{

			#region Update Touch Location
			
			Rectangle touchLoc = Rectangle.Empty;
			GestureSample gesture;
			while(TouchPanel.IsGestureAvailable) {
				gesture = TouchPanel.ReadGesture();
				switch (gesture.GestureType){
				case GestureType.Tap:
					touchLoc = new Rectangle((int)gesture.Position.X - 20, (int)gesture.Position.Y - 20, 40, 40);
					break;
				}
			}

			#endregion

			switch (gameState.menu_level_state)
			{
				case GameStateNumbers.MENU_STATE_ROOT:

					#region Update Back Button Function

					if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
					{
<<<<<<< HEAD
						PlayButton.pos = new Vector2(780, 40);
						TutorialButton.pos = new Vector2(780, 170);
						ExitButton.pos = new Vector2(790, 300);
=======
						PlayButton.pos = new Vector2(900, 100);
						TutorialButton.pos = new Vector2(900, 220);
						ExitButton.pos = new Vector2(900, 340);
>>>>>>> 1e5995f41b29c1f9c72aad7f7c1df53c04cfb3f8

						gameState.top_level_state = GameStateNumbers.STATE_EXIT;
					}

					#endregion

					#region Smooth Button Transition into Frame

<<<<<<< HEAD
					if (PlayButton.pos.X > 420)
					{
						float dist = PlayButton.pos.X - 500;
=======
					if (PlayButton.pos.X > 620)
					{
						float dist = PlayButton.pos.X - 620;
>>>>>>> 1e5995f41b29c1f9c72aad7f7c1df53c04cfb3f8
						PlayButton.pos.X -= (dist / 4);
					}
					if (PlayButton.pos.X <= 640)
						PlayButton.available = true;


<<<<<<< HEAD
					if (TutorialButton.pos.X > 420)
					{
						float dist = TutorialButton.pos.X - 500;
=======
					if (TutorialButton.pos.X > 620)
					{
						float dist = TutorialButton.pos.X - 620;
>>>>>>> 1e5995f41b29c1f9c72aad7f7c1df53c04cfb3f8
						TutorialButton.pos.X -= (dist / 6);
					}
					if (PlayButton.pos.X <= 640)
						TutorialButton.available = true;


<<<<<<< HEAD
					if (ExitButton.pos.X > 420)
					{
						float dist = ExitButton.pos.X - 510;
=======
					if (ExitButton.pos.X > 620)
					{
						float dist = ExitButton.pos.X - 620;
>>>>>>> 1e5995f41b29c1f9c72aad7f7c1df53c04cfb3f8
						ExitButton.pos.X -= (dist / 8);
					}
					if (ExitButton.pos.X <= 640)
						ExitButton.available = true;

					#endregion

					#region Update Buttons

					if (PlayButton.update(touchLoc))
					{
						gameState.exit_level_state = 0;
						gameState.menu_level_state = 0;
						gameState.game_level_state = 0;

<<<<<<< HEAD
						PlayButton.pos = new Vector2(780, 40);
						TutorialButton.pos = new Vector2(780, 170);
						ExitButton.pos = new Vector2(790, 300);
=======
						PlayButton.pos = new Vector2(900, 100);
						TutorialButton.pos = new Vector2(900, 220);
						ExitButton.pos = new Vector2(900, 340);
>>>>>>> 1e5995f41b29c1f9c72aad7f7c1df53c04cfb3f8

						gameState.top_level_state = GameStateNumbers.STATE_PLAY;
						world.newLevel();
					}

					else if (TutorialButton.update(touchLoc))
					{
						gameState.exit_level_state = 0;
						gameState.game_level_state = 0;

<<<<<<< HEAD
						PlayButton.pos = new Vector2(780, 40);
						TutorialButton.pos = new Vector2(780, 170);
						ExitButton.pos = new Vector2(790, 300);
=======
						PlayButton.pos = new Vector2(900, 100);
						TutorialButton.pos = new Vector2(900, 220);
						ExitButton.pos = new Vector2(900, 340);
>>>>>>> 1e5995f41b29c1f9c72aad7f7c1df53c04cfb3f8

						gameState.menu_level_state = GameStateNumbers.MENU_STATE_TUTORIAL;
					}

					else if (ExitButton.update(touchLoc))
					{
						gameState.exit_level_state = 0;
						gameState.menu_level_state = 0;
						gameState.game_level_state = 0;

<<<<<<< HEAD
						PlayButton.pos = new Vector2(780, 40);
						TutorialButton.pos = new Vector2(780, 170);
						ExitButton.pos = new Vector2(790, 300);
=======
						PlayButton.pos = new Vector2(900, 100);
						TutorialButton.pos = new Vector2(900, 220);
						ExitButton.pos = new Vector2(900, 340);
>>>>>>> 1e5995f41b29c1f9c72aad7f7c1df53c04cfb3f8

						gameState.top_level_state = GameStateNumbers.STATE_EXIT;
					}

					#endregion

					break;

				case GameStateNumbers.MENU_STATE_TUTORIAL:

					#region Update Back Button Function

					if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
					{
						BackButton.pos = new Vector2(-100, 30);

						gameState.menu_level_state = GameStateNumbers.MENU_STATE_ROOT;
					}

					#endregion

					#region Smooth Button Transition into Frame

					if (BackButton.pos.X < 180)
					{
						float dist = BackButton.pos.X - 40;
						BackButton.pos.X -= (dist / 5);
					}
					if (BackButton.pos.X >= 20)
						BackButton.available = true;

					#endregion

					#region Update Buttons

					if (BackButton.update(touchLoc))
					{
						BackButton.pos = new Vector2(-100, 30);

						gameState.menu_level_state = GameStateNumbers.MENU_STATE_ROOT;
					}

					break;

					#endregion
			}
		}

		//Handle Game Logic
		void GameMain(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
				gameState.game_level_state = GameStateNumbers.GAME_STATE_PAUSE;

			switch (gameState.game_level_state)
			{
				case GameStateNumbers.GAME_STATE_PLAY:
					// Allows the game to exit
				if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
					gameState.top_level_state = GameStateNumbers.MENU_STATE_ROOT;

					// TODO: Add your update logic here
<<<<<<< HEAD
                    if (!songstart)
                    {
                        MediaPlayer.Play(Assets.PlayBGM);
                        songstart = true;
                    }
					world.update(gameTime);
                    base.Update(gameTime);

=======

					world.update(gameTime);

					base.Update(gameTime);
>>>>>>> 1e5995f41b29c1f9c72aad7f7c1df53c04cfb3f8
					break;

				case GameStateNumbers.GAME_STATE_PAUSE:

					#region Update Touch Location

					Rectangle touchLoc = Rectangle.Empty;
					GestureSample gesture;
					while(TouchPanel.IsGestureAvailable) {
						gesture = TouchPanel.ReadGesture();
						switch (gesture.GestureType){
						case GestureType.Tap:
							touchLoc = new Rectangle((int)gesture.Position.X - 20, (int)gesture.Position.Y - 20, 40, 40);
							break;
						}
					}

					#endregion

					#region Smooth Button Transition into Frame

					if (YesButton.pos.X < 180)
					{
						float dist = YesButton.pos.X - 80;
						YesButton.pos.X -= (dist / 5);
					}
<<<<<<< HEAD
					if (YesButton.pos.X >= 40)
=======
					if (YesButton.pos.X >= 60)
>>>>>>> 1e5995f41b29c1f9c72aad7f7c1df53c04cfb3f8
						YesButton.available = true;


					if (NoButton.pos.X > 620)
					{
						float dist = NoButton.pos.X - 620;
						NoButton.pos.X -= (dist / 4);
					}
					if (NoButton.pos.X <= 640)
						NoButton.available = true;

					#endregion

					#region Update Buttons

					if (YesButton.update(touchLoc))
					{
						YesButton.pos = new Vector2(-100, 380);
						NoButton.pos = new Vector2(800, 380);

						gameState.top_level_state = GameStateNumbers.STATE_MENU;
						gameState.game_level_state = GameStateNumbers.GAME_STATE_PLAY;
<<<<<<< HEAD
                        MediaPlayer.Stop();
                        songstart = false;
=======
>>>>>>> 1e5995f41b29c1f9c72aad7f7c1df53c04cfb3f8
					}
					else if (NoButton.update(touchLoc))
					{
						YesButton.pos = new Vector2(-100, 380);
						NoButton.pos = new Vector2(800, 380);

						gameState.game_level_state = GameStateNumbers.GAME_STATE_PLAY;
					}

					#endregion

					break;
			}
		}

		// Handle Application Termination
		void ExitMain()
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
				gameState.top_level_state = GameStateNumbers.STATE_MENU;

			#region Update Touch Location

			Rectangle touchLoc = Rectangle.Empty;
			GestureSample gesture;
			while(TouchPanel.IsGestureAvailable) {
				gesture = TouchPanel.ReadGesture();
				switch (gesture.GestureType){
				case GestureType.Tap:
					touchLoc = new Rectangle((int)gesture.Position.X - 20, (int)gesture.Position.Y - 20, 40, 40);
					break;
				}
			}

			#endregion

			switch (gameState.exit_level_state)
			{
				case GameStateNumbers.EXIT_STATE_CONFIRM:

					#region Smooth Button Transition into Frame

					if (YesButton.pos.X < 180)
					{
						float dist = YesButton.pos.X - 80;
						YesButton.pos.X -= (dist / 5);
					}
					if (YesButton.pos.X >= 60)
						YesButton.available = true;


					if (NoButton.pos.X > 620)
					{
						float dist = NoButton.pos.X - 620;
						NoButton.pos.X -= (dist / 4);
					}
					if (NoButton.pos.X <= 640)
						NoButton.available = true;

					#endregion

					#region Update Buttons

					if (YesButton.update(touchLoc))
					{
						gameState.exit_level_state = GameStateNumbers.EXIT_STATE_WILLEXIT;
					}
					else if (NoButton.update(touchLoc))
					{
						YesButton.pos = new Vector2(-100, 380);
						NoButton.pos = new Vector2(800, 380);

						gameState.top_level_state = GameStateNumbers.STATE_MENU;
					}

					#endregion

					break;

				case GameStateNumbers.EXIT_STATE_WILLEXIT:
					this.Exit();
					break;

				default:
					break;
			}

		}
	}
}
