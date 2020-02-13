using System.Collections.Generic;
using TradingCompany.Common.Math;

namespace TradingCompany.Model.Heroes {
	public interface IHeroesManager {
		ISet<IHero> Heroes { get; }
		IDictionary<IntVector2, IHero> PositionsToHeroesDictionary { get; }
	}
}