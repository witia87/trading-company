using TradingCompany.Model;
using TradingCompany.Model.Commands;
using TradingCompany.Model.Math;
using TradingCompany.Model.Units;
using TradingCompany.PlayerSupport.Ai.PathFinding;
using TradingCompany.Properties;

namespace TradingCompany.PlayerSupport {
	public static class ActionPlanner {
		private static Board _board;
		private static PathFinder _pathFinder;

		public static void Initialize(Board board) {
			_board = board;
			_pathFinder = new PathFinder(board);
		}

		public static CommandType GetActionType(IntVector2 position) {
			return CommandType.Move; // TODO: Implement
		}

		public static ActionPlan GetActionPlan(IHero hero,
		                                       IntVector2 targetPosition) {
			var path = _pathFinder.FindPath(hero.Position, targetPosition);
			return new ActionPlan(path.ConvertAll(position => new Command(position, CommandType.Move)));
		}
	}
}