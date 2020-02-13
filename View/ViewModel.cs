using System;
using TradingCompany.Communication;
using TradingCompany.PlayerSupport;
using TradingCompany.View.Board;
using TradingCompany.View.Dispatchers;
using TradingCompany.View.Grounds;
using TradingCompany.View.Heroes;
using TradingCompany.View.Rounds;

namespace TradingCompany.View {
	public class ViewModel {
		private static ViewModel _instance;

		private readonly ActionsDispatcher _actionsDispatcher;

		private readonly BoardStore _boardStore;
		private readonly IGateway _gateway;
		private readonly GroundHighlightingStore _groundHighlightingStore;
		private readonly GroundTargetingStore _groundTargetingStore;
		private readonly HeroesHighlightingStore _heroesHighlightingStore;
		private readonly HeroesSelectingStore _heroesSelectingStore;
		private readonly HeroesStore _heroesStore;
		private readonly IPlanner _planner;
		private readonly PlanningStore _planningStore;
		private readonly RoundStore _roundStore;


		public ViewModel(ActionsDispatcher actionsDispatcher,
		                 IPlanner planner,
		                 IGateway gateway,
		                 BoardStore boardStore,
		                 GroundHighlightingStore groundHighlightingStore,
		                 GroundTargetingStore groundTargetingStore,
		                 HeroesStore heroesStore,
		                 HeroesHighlightingStore heroesHighlightingStore,
		                 HeroesSelectingStore heroesSelectingStore,
		                 PlanningStore planningStore,
		                 RoundStore roundStore) {
			_actionsDispatcher = actionsDispatcher;
			_planner = planner;
			_gateway = gateway;
			_boardStore = boardStore;
			_groundHighlightingStore = groundHighlightingStore;
			_groundTargetingStore = groundTargetingStore;
			_heroesStore = heroesStore;
			_heroesHighlightingStore = heroesHighlightingStore;
			_heroesSelectingStore = heroesSelectingStore;
			_planningStore = planningStore;
			_roundStore = roundStore;
		}

		public static IActionsDispatcher ActionsDispatcher => _instance._actionsDispatcher;
		public static IPlanner Planner => _instance._planner;

		public static IGateway Gateway => _instance._gateway;

		public static BoardStore BoardStore => _instance._boardStore;
		public static GroundHighlightingStore GroundHighlightingStore => _instance._groundHighlightingStore;
		public static GroundTargetingStore GroundTargetingStore => _instance._groundTargetingStore;
		public static HeroesStore HeroesStore => _instance._heroesStore;
		public static HeroesHighlightingStore HeroesHighlightingStore => _instance._heroesHighlightingStore;
		public static HeroesSelectingStore HeroesSelectingStore => _instance._heroesSelectingStore;
		public static PlanningStore PlanningStore => _instance._planningStore;
		public static RoundStore RoundStore => _instance._roundStore;

		public static event Action ViewModelCreated;


		public static void Initialize(ActionsDispatcher actionsDispatcher,
		                              IPlanner planner,
		                              IGateway gateway,
		                              BoardStore boardStore,
		                              GroundHighlightingStore groundHighlightingStore,
		                              GroundTargetingStore groundTargetingStore,
		                              HeroesStore heroesStore,
		                              HeroesHighlightingStore heroesHighlightingStore,
		                              HeroesSelectingStore heroesSelectingStore,
		                              PlanningStore planningStore,
		                              RoundStore roundStore) {
			_instance = new ViewModel(actionsDispatcher,
				planner,
				gateway,
				boardStore,
				groundHighlightingStore,
				groundTargetingStore,
				heroesStore,
				heroesHighlightingStore,
				heroesSelectingStore,
				planningStore,
				roundStore);

			ViewModelCreated?.Invoke();
		}
	}
}