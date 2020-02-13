using System.Collections.Generic;
using TradingCompany.Common.Math;
using TradingCompany.Model.Heroes;

namespace TradingCompany.View.Heroes {
	public class HeroesStore : IHeroesManager {
		private readonly IHeroesManager _heroesManager;

		public HeroesStore(IHeroesManager heroesManager) {
			_heroesManager = heroesManager;
		}

		public ISet<IHero> Heroes => _heroesManager.Heroes;
		public IDictionary<IntVector2, IHero> PositionsToHeroesDictionary => _heroesManager.PositionsToHeroesDictionary;
	}
}