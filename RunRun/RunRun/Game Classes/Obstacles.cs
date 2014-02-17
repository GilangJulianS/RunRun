using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RunRun.Game_Classes {
	public class Obstacles {

		public List<Obstacle> obstacles;

		public Obstacles() {
			obstacles = new List<Obstacle>();
		}

		public void update() {
			Obstacle obstacle;
			int n;
			n = obstacles.Count;
			for(int i = 0; i < n; i++) {
				obstacle = obstacles.ElementAt(i);
				obstacle.update();
			}
		}

		public void addObstacle(float x, float y) {
			obstacles.Add(new Obstacle(x, y));
		}

		public void removeObstacle(int i) {
			if(i < obstacles.Count) {
				obstacles.RemoveAt(i);
			}
		}

		public Obstacle getObstacle(int i){
			Obstacle obstacle = obstacles[i];
			return obstacle;
		}

		public Obstacle getLast() {
			return obstacles.Last();
		}

		public int getSize() {
			return obstacles.Count;
		}

		public List<Obstacle> getobstacles() {
			return obstacles;
		}
	}
}
