using System.ComponentModel;
using TradingCompany.Model;

namespace TradingCompany.View.Board {
	public class BoardStore {
		private Model.Board _board;

		public BoardStore(Model.Board board) {
			_board = board;
		}

		public int Rows => _board.Rows;
		public int Columns => _board.Columns;
		public Field[][] Fields => _board.Fields;
	}
}