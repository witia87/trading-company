using Godot;
using TradingCompany.Communication.Data;

namespace TradingCompany.Communication.InitializationMockup {
	public class BoardInitializer : Node {
		private readonly int _columns = 32;
		private readonly int _rows = 32;

		public BoardData CreateBoardData() {
			// TODO: Temporary solution, should be swapped to content generation
			var baseTileMap = GetNode<TileMap>("./Ground");

			var fields = new byte[_rows * _columns];
			for (var row = 0; row < _rows; row++) {
				for (var column = 0; column < _columns; column++) {
					var autotileCoord = baseTileMap.GetCellAutotileCoord(column, row);
					fields[row * _columns + column] = (byte) autotileCoord.x;
				}
			}

			return new BoardData(_columns, _rows, fields);
		}
	}
}