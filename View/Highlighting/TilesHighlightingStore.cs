using System.ComponentModel;
using TradingCompany.Model.Math;

namespace TradingCompany.View.Highlighting {
	public class TilesHighlightingStore {
		public TilesHighlightingStore() {
			EventDispatcher.RegisterAsStore(EventType.TileHighlighted, TileHighlightedChanged);
		}

		private void TileHighlightedChanged(object position) {
			var fieldPosition = (IntVector2) position;

			if (IsOverBoard(fieldPosition)) {
				IsFieldHighlighted = true;
				HighlightedFieldPosition = fieldPosition;
			}
			else {
				IsFieldHighlighted = false;
			}
		}

		public bool IsFieldHighlighted { get; private set; }
		public IntVector2 HighlightedFieldPosition { get; private set; }


		private bool IsOverBoard(IntVector2 position) {
			return position.x >= 0
			       && position.x < Stores.Board.Columns
			       && position.y >= 0
			       && position.y < Stores.Board.Rows;
		}
	}
}