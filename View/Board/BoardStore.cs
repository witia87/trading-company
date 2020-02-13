using TradingCompany.Model;

namespace TradingCompany.View.Board {
	public class BoardStore {
		private readonly IBoard _board;

		public BoardStore(IBoard board) {
			_board = board;
		}

		public int Rows => _board.Rows;
		public int Columns => _board.Columns;

		public Field[,] Fields => _board.Fields;
	}
}