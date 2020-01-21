using Godot;

namespace TradingCompany.View.Input {
	public class MouseController : Node {
		private const int ButtonLeft = 1;

		private bool _wasLeftButtonPressed;

		public override void _Process(float delta) {
			EventDispatcher.Dispatch(EventType.MousePositionChanged, GetViewport().GetMousePosition());

			if (!_wasLeftButtonPressed && Godot.Input.IsMouseButtonPressed(ButtonLeft)) {
				GD.Print("User clicked " + GetViewport().GetMousePosition());
				EventDispatcher.Dispatch(EventType.MousePressed, null);
			}

			_wasLeftButtonPressed = Godot.Input.IsMouseButtonPressed(ButtonLeft);
		}
	}
}