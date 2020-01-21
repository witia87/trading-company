using System.Collections.Generic;

namespace TradingCompany.Model.Units {
	public interface IHeroesManager {
		ISet<IHero> Heroes { get; }
	}
}