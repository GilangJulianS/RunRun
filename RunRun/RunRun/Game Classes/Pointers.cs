using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RunRun.Game_Classes {
	public class Pointers {

		int maxNum = 15;
		List<Pointer> pointers;

		public Pointers() {
			pointers = new List<Pointer>();
		}

		public void update(int deltaTime) {
			int n;
			Pointer pointer;
			n = pointers.Count;
			for(int i = 0; i < n; i++) {
				pointer = pointers.ElementAt(i);
				pointer.update(deltaTime);
				if(!pointer.isActive()) {
					pointers.RemoveAt(i);
					i--; n--;
				}
			}
		}

		public void draw(SpriteBatch spriteBatch) {
			
			int n;
			Pointer pointer;
			n = pointers.Count;
			for(int i = 0; i < n; i++) {
				spriteBatch.Draw(Assets.pointer, new Rectangle(30, 30, 15, 15), Color.White);
				pointer = pointers.ElementAt(i);
				if(pointer.isActive()) {
					spriteBatch.Draw(Assets.pointer, pointer.getBound(), Color.White);
				}
			}
		}

		public void addPointer(Vector2 position) {
			pointers.Add(new Pointer(position));
			if(pointers.Count > 15)
				pointers.RemoveAt(0);
		}

		public void addPointer(float x, float y) {
			pointers.Add(new Pointer(x, y));
			if(pointers.Count > 15)
				pointers.RemoveAt(0);
		}


	}
}
