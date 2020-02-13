namespace TradingCompany.Model {
	public class Board : IBoard {
		public Board(Field[,] fields) {
			Fields = fields;

			Rows = fields.GetLength(0);
			Columns = fields.GetLength(1);
		}

		public Field[,] Fields { get; }

		public int Rows { get; }

		public int Columns { get; }
	}
}