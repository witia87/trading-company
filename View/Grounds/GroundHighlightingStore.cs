using TradingCompany.Common.Math;
using TradingCompany.View.Dispatchers;

namespace TradingCompany.View.Grounds {
	public class GroundHighlightingStore {
		public GroundHighlightingStore(ActionsDispatcher actionsDispatcher) {
			actionsDispatcher.RegisterAsStore(ActionType.UserHoveredOverGround, OnUserHoveredOverGround);
			actionsDispatcher.RegisterAsStore(ActionType.UserHoveredOverHero, OnUserHoveredOverHero);
		}

		public bool IsFieldHighlighted { get; private set; }
		public IntVector2 HighlightedFieldPosition { get; private set; }

		private void OnUserHoveredOverGround(object boardPosition) {
			if (IsOverBoard((IntVector2) boardPosition)) {
				IsFieldHighlighted = true;
				HighlightedFieldPosition = (IntVector2) boardPosition;
			}
			else {
				IsFieldHighlighted = false;
			}
		}

		private void OnUserHoveredOverHero(object hero) {
			IsFieldHighlighted = false;
		}

		private bool IsOverBoard(IntVector2 position) {
			return position.x >= 0
			       && position.x < ViewModel.BoardStore.Columns
			       && position.y >= 0
			       && position.y < ViewModel.BoardStore.Rows;
		}
	}
}