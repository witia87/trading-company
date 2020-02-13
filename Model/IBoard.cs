namespace TradingCompany.Model {
	public interface IBoard {
		int Rows { get; }
		int Columns { get; }

		Field[,] Fields { get; }
	}
}