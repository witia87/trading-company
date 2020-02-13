using Godot;
using TradingCompany.Common.Math;

namespace TradingCompany.View.Grounds {
	public class GroundHighlightingLayer : TileMap {
		private TileMap _groundTileMap;
		private IntVector2 _selectedFieldPosition;

		private bool _wasFieldHighlighted;


		public override void _Ready() {
			_groundTileMap = GetNode<TileMap>("../Ground");
		}

		public override void _Process(float delta) {
			ClearCell();

			if (ViewModel.GroundHighlightingStore.IsFieldHighlighted) {
				_wasFieldHighlighted = true;
				_selectedFieldPosition = ViewModel.GroundHighlightingStore.HighlightedFieldPosition;
				UpdateCell();
			}
		}

		private void ClearCell() {
			if (_wasFieldHighlighted) {
				_wasFieldHighlighted = false;
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