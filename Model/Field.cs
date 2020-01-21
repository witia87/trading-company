using TradingCompany.Model.Grounds;

namespace TradingCompany.Model {
	public struct Field {
		public readonly int Row, Column;
		public readonly Ground Ground;

		public Field(int row, int column, Ground ground) {
			Row = row;
			Column = column;
			Ground = ground;
		}
	}
}