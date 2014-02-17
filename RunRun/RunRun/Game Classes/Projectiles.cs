using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RunRun.Game_Classes {
	public class Projectiles {

		List<Projectile> projectiles;
		private Random random;

		public Projectiles() {
			projectiles = new List<Projectile>();
		}

		public void update(Character character) {
			int n;
			Projectile projectile;
			n = projectiles.Count;
			float x = character.getPos().X;
			float projX;
			Rectangle charBound = character.getColliBound();
			for(int i = 0; i < n; i++) {
				projectile = projectiles.ElementAt(i);
				projectile.update();
				projX = projectile.getPos().X;
				if(projX < -100) {
					projectiles.RemoveAt(i);
					i--; n--;
				}
				if((x - projX) < 100 && (x - projX) > -100) {
					if(projectile.getBound().Intersects(charBound)){
						character.health--;
						projectiles.RemoveAt(i);
						i--; n--;
					}
				}

			}
		}

		public void addProjectile(float x, float y){
			random = new Random();
			if (random.Next(3) == 0){
				projectiles.Add(new Projectile(x, y));
			}
			else if (random.Next(3) == 1){
				projectiles.Add(new Projectile_straight(x, y));
			}
			else {
				projectiles.Add(new Projectile_zigzag(x, y));
			}
		}

		public void addProjectile(Vector2 position) {
			random = new Random();
			if (random.Next(3) == 0){
				projectiles.Add(new Projectile(position.X, position.Y));
			}
			else if (random.Next(3) == 1){
				projectiles.Add(new Projectile_straight(position.X, position.Y));
			}
			else {
				projectiles.Add(new Projectile_zigzag(position.X, position.Y));
			}
		}

		public int getSize() {
			return projectiles.Count;
		}

		public Projectile getProjectile(int i) {
			return projectiles.ElementAt(i);
		}
	}
}
