using Godot;
using TradingCompany.Model.Math;

namespace TradingCompany.View.Selection {
	public class TilesSelectionLayer : TileMap {
		private TileMap _groundTileMap;
		private IntVector2 _selectedFieldPosition;

		private bool _wasFieldSelected;

		private Tween _tween = new Tween();


		public override void _Ready() {
			_groundTileMap = GetNode<TileMap>("../Ground");

			EventDispatcher.RegisterAsView(EventType.MousePressed, UpdateSelection);

			AddChild(_tween);
		}

		private void UpdateSelection() {
			ClearCell();
			if (Stores.TilesHighlighting.IsFieldHighlighted) {
				_wasFieldSelected = true;
				_selectedFieldPosition = Stores.TilesHighlighting.HighlightedFieldPosition;
				UpdateCell();
				LaunchTween();
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

		private void LaunchTween() {
			_tween.InterpolateProperty(this, "Modulate",
				new Color(1, 1, 1, 1),
				new Color(1, 1, 1, 0),
				1,
				Tween.TransitionType.Linear, Tween.EaseType.Out);
			_tween.Start();
		}
	}
}