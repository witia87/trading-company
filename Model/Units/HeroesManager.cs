using System.Collections.Generic;

namespace TradingCompany.Model.Units {
	public class HeroesManager : IHeroesManager {
		public ISet<IHero> Heroes { get; }

		public HeroesManager(ISet<IHero> heroes) {
			Heroes = heroes;
		}
	}
}