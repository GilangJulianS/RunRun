using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Input.Touch;


namespace RunRun.Game_Classes {
	public class Input {

		TouchCollection touchState;
		List<GestureSample> gestures;

		public Input() {
			gestures = new List<GestureSample>();
		}

		public void update() {
			touchState = TouchPanel.GetState();
			gestures.Clear();
			while(TouchPanel.IsGestureAvailable) {
				gestures.Add(TouchPanel.ReadGesture());
			}
		}

		public List<GestureSample> getGestures() {
			return gestures;
		}
	}
}
