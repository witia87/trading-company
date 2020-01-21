using Godot;

namespace TradingCompany.View.Input {
	public class MouseStore {
		public MouseStore() {
			EventDispatcher.RegisterAsStore(EventType.MousePositionChanged, OnMousePositionChanged);
		}

		public Vector2 MousePosition { get; private set; }

		private void OnMousePositionChanged(object position) {
			MousePosition = (Vector2) position;
		}
	}
}