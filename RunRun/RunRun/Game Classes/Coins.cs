using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RunRun.Game_Classes {
	class Coins {

		public static readonly int SHAPE_V = 0;
		public static readonly int SHAPE_SQUARE = 1;
		public static readonly int SHAPE_HORIZONTAL = 2;
		public static readonly int SHAPE_VERTICAL = 3;
		public static readonly int SHAPE_X = 4;
		public static readonly int SHAPE_ITB = 5;
		public static readonly int SHAPE_SINGLE = 6;
		private List<Coin> coins;
		Random random;

		public Coins() {
			coins = new List<Coin>();
			random = new Random();
		}

		public void update(Character character) {
			int n;
			Coin coin;
			Rectangle charBound = character.getBound(); 
			n = coins.Count;
			for(int i = 0; i < n; i++) {
				coin = coins.ElementAt(i);
				coin.update();
				if(coin.getBound().Intersects(charBound)) {
					character.points++;
					coins.RemoveAt(i);
					i--; n--;
				}
			}
		}

		public void addCoin(float x, float y) {
			
			int n;
			int type = random.Next(0, 6);
			if(type == Coins.SHAPE_HORIZONTAL) {
				n = random.Next(1, 4);
				for(int i = 1; i <= n; i++) {
					coins.Add(new Coin(x + (i * Coin.DEFAULT_SIZE.X), y));
				}
			}
			else if(type == Coins.SHAPE_VERTICAL) {
				n = random.Next(1, 4);
				for(int i = 1; i <= n; i++) {
					if(y + ((i + 1) * Coin.DEFAULT_SIZE.Y) < Game1.screenSize.Y - Platform.SIZE_TYPE_1.Y) {
						coins.Add(new Coin(x, y + (i * Coin.DEFAULT_SIZE.Y)));
					}
				}
			}
			else if(type == Coins.SHAPE_V) {
				if(y + (2 * Coin.DEFAULT_SIZE.Y) < Game1.screenSize.Y - Platform.SIZE_TYPE_1.Y) {
					coins.Add(new Coin(x + (3*Coin.DEFAULT_SIZE.X), y + Coin.DEFAULT_SIZE.Y));
					coins.Add(new Coin(x + Coin.DEFAULT_SIZE.X, y + Coin.DEFAULT_SIZE.Y));
				}
				if(y + (3*Coin.DEFAULT_SIZE.Y) < Game1.screenSize.Y - Platform.SIZE_TYPE_1.Y)	
					coins.Add(new Coin(x + (2*Coin.DEFAULT_SIZE.X), y + (2*Coin.DEFAULT_SIZE.Y)));
				if(y + Coin.DEFAULT_SIZE.Y < Game1.screenSize.Y - Platform.SIZE_TYPE_1.Y) {
					coins.Add(new Coin(x + (4*Coin.DEFAULT_SIZE.X), y));
					coins.Add(new Coin(x, y));
				}
				
			}
			else if(type == Coins.SHAPE_X) {
				if(y + Coin.DEFAULT_SIZE.Y < Game1.screenSize.Y - Platform.SIZE_TYPE_1.Y) {
					coins.Add(new Coin(x, y));
					coins.Add(new Coin(x + (4 * Coin.DEFAULT_SIZE.X), y));
				}
				if(y + (2 * Coin.DEFAULT_SIZE.Y) < Game1.screenSize.Y - Platform.SIZE_TYPE_1.Y) {
					coins.Add(new Coin(x + Coin.DEFAULT_SIZE.X, y + Coin.DEFAULT_SIZE.Y));
					coins.Add(new Coin(x + (3 * Coin.DEFAULT_SIZE.X), y + Coin.DEFAULT_SIZE.Y));
				}
				if(y + (3 * Coin.DEFAULT_SIZE.Y) < Game1.screenSize.Y - Platform.SIZE_TYPE_1.Y) {
					coins.Add(new Coin(x + (2 * Coin.DEFAULT_SIZE.X), y + (2 * Coin.DEFAULT_SIZE.Y)));
				}
				if(y + (4 * Coin.DEFAULT_SIZE.Y) < Game1.screenSize.Y - Platform.SIZE_TYPE_1.Y) {
					coins.Add(new Coin(x + Coin.DEFAULT_SIZE.X, y + (3*Coin.DEFAULT_SIZE.Y)));
					coins.Add(new Coin(x + (3 * Coin.DEFAULT_SIZE.X), y + (3*Coin.DEFAULT_SIZE.Y)));
				}
				if(y + (5 * Coin.DEFAULT_SIZE.Y) < Game1.screenSize.Y - Platform.SIZE_TYPE_1.Y) {
					coins.Add(new Coin(x, y + (4*Coin.DEFAULT_SIZE.Y)));
					coins.Add(new Coin(x + (4 * Coin.DEFAULT_SIZE.X), y + (4*Coin.DEFAULT_SIZE.Y)));
				}
				
			}
			else if(type == Coins.SHAPE_SQUARE){
				n = random.Next(1, 5);
				for(int i = 1; i <= 5; i++) {
					if(y + ((i + 1) * Coin.DEFAULT_SIZE.Y) < Game1.screenSize.Y - Platform.SIZE_TYPE_1.Y) {
						for(int j = 1; j <= 5; j++) {
							coins.Add(new Coin(x + (j * Coin.DEFAULT_SIZE.X), y + (i * Coin.DEFAULT_SIZE.Y)));
						}
					}
					
				}
			}
			else if(type == Coins.SHAPE_SINGLE) {
				coins.Add(new Coin(x, y));
			}
		}

		public void addCoin(Vector2 position) {
			coins.Add(new Coin(position));
		}

		public int getSize() {
			return coins.Count;
		}

		public Coin getCoin(int i) {
			return coins.ElementAt(i);
		}
	}
}
