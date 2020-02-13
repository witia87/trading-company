using Godot;
using TradingCompany.Communication;
using TradingCompany.Model;
using TradingCompany.PlayerSupport;
using TradingCompany.View.Board;
using TradingCompany.View.Dispatchers;
using TradingCompany.View.Grounds;
using TradingCompany.View.Heroes;
using TradingCompany.View.Rounds;

namespace TradingCompany.View {
	public class GameInitializer : Node {
		public override void _Ready() {
			var gateway = GetGateway();

			var game = ModelFactory.Create(gateway);

			var planner = new Planner(game.Board);

			CreateViewModel(game, planner, gateway);
		}

		private Gateway GetGateway() {
			return GetNode<Gateway>("./Gateway");
		}

		private static void CreateViewModel(IGame game,
		                                    IPlanner planner,
		                                    IGateway gateway) {
			var actionsDispatcher = new ActionsDispatcher();
			var boardStore = new BoardStore(game.Board);
			var heroesStore = new HeroesStore(game.HeroesManager);
			var roundsStore = new RoundStore(game.RoundsManager);

			ViewModel.Initialize(
				actionsDispatcher,
				planner,
				gateway,
				boardStore,
				new GroundHighlightingStore(actionsDispatcher),
				new GroundTargetingStore(actionsDispatcher),
				heroesStore,
				new HeroesHighlightingStore(actionsDispatcher),
				new HeroesSelectingStore(actionsDispatcher),
				new PlanningStore(actionsDispatcher),
				roundsStore);
		}
	}
}