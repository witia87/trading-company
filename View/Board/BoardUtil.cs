using Godot;
using TradingCompany.Common.Math;

namespace TradingCompany.View.Board {
	public static class BoardUtil {
		private static readonly IntVector2 CellSize = new IntVector2(24, 24);

		public static IntVector2 ToBoardPosition(Vector2 worldPosition) {
			var column = (int) worldPosition.x / CellSize.x;
			return new IntVector2(column,
				(Mathf.RoundToInt(worldPosition.y) - column % 2 * CellSize.y / 2) / CellSize.y);
		}

		public static Vector2 ToWorldPosition(IntVector2 boardPosition) {
			var column = boardPosition.x;
			var row = boardPosition.y;
			return new Vector2(boardPosition.x * CellSize.x + CellSize.x / 2,
				row * CellSize.y +
				+(column % 2) * CellSize.y / 2 +
				CellSize.x / 6);
		}
	}
}