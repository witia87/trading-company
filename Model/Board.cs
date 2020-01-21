namespace TradingCompany.Model {
	public class Board : IBoard {
		public Board(Field[][] fields) {
			Fields = fields;

			Rows = fields.Length;
			Columns = fields[0].Length;
		}

		public Field[][] Fields { get; }


		public int Rows { get; }

		public int Columns { get; }
	}
}