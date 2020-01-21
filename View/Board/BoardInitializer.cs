using Godot;
using TradingCompany.Model;
using TradingCompany.Model.Grounds;

namespace TradingCompany.View.Board {
	public class BoardInitializer : TileMap {
		private readonly int _columns = 32;
		private readonly int _rows = 32;

		public Model.Board CreateBoard() {
			// TODO: Temporary solution, should be swapped to content generation
			var fields = new Field[_rows][];
			for (var row = 0; row < _rows; row++) {
				fields[row] = new Field[_columns];
				for (var column = 0; column < _columns; column++) {
					fields[row][column] = new Field(column, row,
						GroundTypesFactory.Create((GroundType) GetCell(column, row)));
				}
			}

			return new Model.Board(fields);
		}
	}
}