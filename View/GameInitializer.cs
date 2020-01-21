using Godot;
using TradingCompany.PlayerSupport;
using TradingCompany.View.Board;

namespace TradingCompany.View {
	public class GameInitializer : Node {
		public override void _Ready() {
			var boardInitializer = GetNode<BoardInitializer>("../Ground");
			var board = boardInitializer.CreateBoard();
			Stores.Initialize(board);
			ActionPlanner.Initialize(board);
		}
	}
}