using TradingCompany.Model.Heroes;
using TradingCompany.View.Dispatchers;

namespace TradingCompany.View.Heroes {
	public class HeroesSelectingStore {
		private StoreEvent<IHero> _heroSelected = new StoreEvent<IHero>();


		public HeroesSelectingStore(ActionsDispatcher actionsDispatcher) {
			actionsDispatcher.RegisterAsStore(ActionType.UserSelectedHero, OnUserSelectedHero);
		}

		public IHero SelectedHero { get; private set; }
		public bool IsHeroSelected => SelectedHero != null;

		private void OnUserSelectedHero(object hero) {
			SelectedHero = (IHero) hero;
		}
	}
}