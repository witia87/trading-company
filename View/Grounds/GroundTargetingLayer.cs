using System;
using Godot;
using TradingCompany.Common.Math;

namespace TradingCompany.View.Grounds {
	public class GroundTargetingLayer : TileMap {
		private readonly Tween _tween = new Tween();
		private TileMap _groundTileMap;
		private IntVector2 _selectedFieldPosition;

		private bool _wasFieldSelected;


		public GroundTargetingLayer() {
			ViewModel.ViewModelCreated += () => ViewModel.GroundTargetingStore.FieldTargeted.Register(OnFieldTargeted);
		}

		public override void _Ready() {
			_groundTileMap = GetNode<TileMap>("../Ground");

			AddChild(_tween);
		}

		private void OnFieldTargeted(IntVector2 position,
		                             Action done) {
			ClearCell();
			if (ViewModel.GroundHighlightingStore.IsFieldHighlighted) {
				_wasFieldSelected = true;
				_selectedFieldPosition = ViewModel.GroundHighlightingStore.HighlightedFieldPosition;
				UpdateCell();
				LaunchTween();
			}

			done();
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
				new Color(1, 1, 1),
				new Color(1, 1, 1, 0),
				1,
				Tween.TransitionType.Linear, Tween.EaseType.Out);
			_tween.Start();
		}
	}
}