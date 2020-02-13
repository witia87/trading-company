using TradingCompany.Common.Math;
using TradingCompany.Model;

namespace TradingCompany.PlayerSupport.PathFinding {
	public static class WeightsFactory {
		public static byte[,,] Create(IBoard board) {
			var weights = new byte[board.Rows, board.Columns, HexOffsets.OffsetsCount];
			for (var row = 0; row < board.Rows; row++) {
				for (var column = 0; column < board.Columns; column++) {
					var currentPosition = new IntVector2(column, row);
					var hexOffsets = HexOffsets.GetHexOffsets(currentPosition);
					for (var offsetIndex = 0; offsetIndex < hexOffsets.Length; offsetIndex++) {
						var neighborPosition = currentPosition + hexOffsets[offsetIndex];
						weights[row, column, offsetIndex] = IsPositionOnBoard(neighborPosition, board)
						                                    && board.Fields[neighborPosition.y, neighborPosition.x]
							                                    .Ground.IsAccessible
							? (byte) 1
							: (byte) 0;
					}
				}
			}

			return weights;
		}

		private static bool IsPositionOnBoard(IntVector2 position,
		                                      IBoard board) {
			return position.x >= 0
			       && position.x < board.Columns
			       && position.y >= 0
			       && position.y < board.Rows;
		}
	}
}