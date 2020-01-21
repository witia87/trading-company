using TradingCompany.Model;
using TradingCompany.Model.Math;

namespace TradingCompany.PlayerSupport.Ai.PathFinding {
	public static class WeightsFactory {
		public static byte[][][] Create(IBoard board) {
			var weights = new byte[board.Rows][][];
			for (var row = 0; row < board.Rows; row++) {
				weights[row] = new byte[board.Columns][];
				for (var column = 0; row < board.Columns; row++) {
					weights[row][column] = new byte[IntVector2.HexOffsets.Length];
					var currentPosition = new IntVector2(column, row);
					for (var offsetIndex = 0; offsetIndex < IntVector2.HexOffsets.Length; offsetIndex++) {
						var neighborPosition = currentPosition + IntVector2.HexOffsets[offsetIndex];
						weights[row][column][offsetIndex] = IsPositionOnBoard(neighborPosition, board)
						                                    && board.Fields[row][column].Ground.IsAccessible
							? (byte) 1
							: (byte) 0;
					}

					foreach (var offset in IntVector2.HexOffsets) {
					}
				}
			}

			return weights;
		}

		private static bool IsPositionOnBoard(IntVector2 position, IBoard board) {
			return position.x >= 0
			       && position.x < board.Columns
			       && position.y >= 0
			       && position.y < board.Rows;
		}
	}
}