using Godot;
using TradingCompany.View.Board;
using TradingCompany.View.Common;
using TradingCompany.View.Dispatchers;

namespace TradingCompany.View.Grounds {
	public class GroundActionsCreator : Node2D {
		private InputDetector _inputDetector;

		public override void _Ready() {
			_inputDetector = GetChild<InputDetector>(0);
			_inputDetector.HoverEventDetected += OnHoverInputDetected;
			_inputDetector.TargetEventDetected += OnTargetEventDetected;
		}

		private void OnHoverInputDetected(Vector2 position) {
			var boardPosition = BoardUtil.ToBoardPosition(position);
			ViewModel.ActionsDispatcher.Dispatch(ActionType.UserHoveredOverGround, boardPosition);
		}

		private void OnTargetEventDetected(Vector2 position) {
			var boardPosition = BoardUtil.ToBoardPosition(position);
			ViewModel.ActionsDispatcher.Dispatch(ActionType.UserTargetedGround, boardPosition);
		}
	}
}