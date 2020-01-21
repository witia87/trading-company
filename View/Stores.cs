using TradingCompany.View.Board;
using TradingCompany.View.Highlighting;
using TradingCompany.View.Input;

namespace TradingCompany.View {
	public static class Stores {
		public static MouseStore Mouse;
		public static TilesHighlightingStore TilesHighlighting;
		public static BoardStore Board;

		public static void Initialize(Model.Board board) {
			Mouse = new MouseStore();
			TilesHighlighting = new TilesHighlightingStore();
			Board = new BoardStore(board);
		}
	}
}