using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RunRun.Game_Classes {
	public class Platforms {

		private List<Platform> platforms;
		public static readonly int MAX_COUNT = 4;
		public Platform lastGround, lastSky;
		public int lastType;

		public Platforms() {
			platforms = new List<Platform>();
		}

		public void update() {
			int n = platforms.Count;
			Platform platform;
			for(int i = 0; i < n; i++) {
				platform = platforms.ElementAt(i);
				platform.update();
				if(platform.getBound().Right < 0) {
					if(Character.curPlatforms > i){
						Character.curPlatforms--;
						Character.lastCurPlat--;
					}
					else if(Character.curPlatforms == i)
						Character.curPlatforms = -1;
					platforms.RemoveAt(i);
					i--; n--;
				}
			}
		}

		public void addPlatform(float x, float y, Vector2 sizetype) {
			Platform platform = new Platform(x, y, sizetype);
			if(platforms.Count < Platforms.MAX_COUNT) {
				platforms.Add(platform);
				if(platform.getType() == Platform.TYPE_GROUND) {
					lastGround = platform;
					lastType = Platform.TYPE_GROUND;
				}
				else if(platform.getType() == Platform.TYPE_SKY) {
					lastSky = platform;
					lastType = Platform.TYPE_SKY;
				}
			}
			
		}

		public void addPlatform(Vector2 position, Vector2 sizetype) {
			Platform platform = new Platform(position, sizetype);
			if(platforms.Count < Platforms.MAX_COUNT) {
				platforms.Add(platform);
				if(platform.getType() == Platform.TYPE_GROUND) {
					lastGround = platform;
					lastType = Platform.TYPE_GROUND;
				}
				else if(platform.getType() == Platform.TYPE_SKY) {
					lastSky = platform;
					lastType = Platform.TYPE_SKY;
				}
			}
		}

		public void removePlatform(int i) {
			if(i < platforms.Count) {
				platforms.RemoveAt(i);
			}
		}

		public Platform getPlatform(int i){
			Platform platform = platforms[i];
			return platform;
		}

		public Platform getLast() {
			return platforms.Last();
		}

		public int getSize() {
			return platforms.Count;
		}

		public List<Platform> getPlatforms() {
			return platforms;
		}
	}
}
