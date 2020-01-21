using Godot;
using TradingCompany.Model.Math;

namespace TradingCompany.View.Highlighting {
	public class HighlightingController : Node {
		private TileMap _highlightingTileMap;

		public override void _Ready() {
			_highlightingTileMap = GetParent<TileMap>();
		}

		public override void _Process(float delta) {
			var fieldPosition = _highlightingTileMap.WorldToMap(Stores.Mouse.MousePosition);

			EventDispatcher.Dispatch(EventType.TileHighlighted, IntVector2.FromVector2(fieldPosition));
		}
	}
}