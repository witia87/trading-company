using Godot;
using TradingCompany.Model.Math;

namespace TradingCompany.View.Highlighting {
	public class TilesHighlightingLayer : TileMap {
		private TileMap _groundTileMap;
		private IntVector2 _selectedFieldPosition;

		private bool _wasFieldSelected;


		public override void _Ready() {
			_groundTileMap = GetNode<TileMap>("../Ground");

			EventDispatcher.RegisterAsView(EventType.TileHighlighted, UpdateHighlight);
		}

		private void UpdateHighlight() {
			ClearCell();

			if (Stores.TilesHighlighting.IsFieldHighlighted) {
				_wasFieldSelected = true;
				_selectedFieldPosition = Stores.TilesHighlighting.HighlightedFieldPosition;
				UpdateCell();
			}
		}

		private void ClearCell() {
			if (_wasFieldSelected) {
				_wasFieldSelected = false;
				SetCellv(_selectedFieldPosition.ToVector2(), -1);
			}
		}

		private void UpdateCell() {
			var x = _selectedFieldPosition.x;
			var y = _selectedFieldPosition.y;
			var newTileIndex = _groundTileMap.GetCell(x, y);
			var autoTileCoordinates = _groundTileMap.GetCellAutotileCoord(x, y);
			SetCell(x, y, newTileIndex, false, false, false, autoTileCoordinates);
		}
	}
}