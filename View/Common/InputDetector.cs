using System;
using Godot;

namespace TradingCompany.View.Common {
	public class InputDetector : Control {
		private const int ButtonLeft = 1;
		private const int ButtonRight = 2;

		public event Action<Vector2> HoverEventDetected;
		public event Action<Vector2> SelectEventDetected;
		public event Action<Vector2> TargetEventDetected;

		public override void _GuiInput(InputEvent @event) {
			if (@event is InputEventMouseMotion mouseMotionEvent) {
				HoverEventDetected?.Invoke(mouseMotionEvent.Position);
			}

			if (@event is InputEventMouseButton mouseButtonEvent
			    && mouseButtonEvent.Pressed) {
				if (mouseButtonEvent.ButtonIndex == ButtonLeft) {
					SelectEventDetected?.Invoke(mouseButtonEvent.Position);
				}
				else if (mouseButtonEvent.ButtonIndex == ButtonRight) {
					TargetEventDetected?.Invoke(mouseButtonEvent.Position);
				}
			}
		}
	}
}