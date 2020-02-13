using TradingCompany.Model.Heroes;
using TradingCompany.View.Dispatchers;

namespace TradingCompany.View.Heroes {
	public class HeroesHighlightingStore {
		public HeroesHighlightingStore(ActionsDispatcher actionsDispatcher) {
			actionsDispatcher.RegisterAsStore(ActionType.UserHoveredOverHero, OnUserHoveredOverHero);
			actionsDispatcher.RegisterAsStore(ActionType.UserHoveredOverGround, OnUserHoveredOverGround);
		}

		public bool IsHeroHighlighted { get; private set; }
		public IHero HighlightedHero { get; private set; }

		private void OnUserHoveredOverHero(object hero) {
			IsHeroHighlighted = true;
			HighlightedHero = (IHero) hero;
		}

		private void OnUserHoveredOverGround(object position) {
			IsHeroHighlighted = false;
			HighlightedHero = null;
		}
	}
}