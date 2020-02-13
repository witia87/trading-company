using TradingCompany.Model.Heroes;
using TradingCompany.Model.Rounds;

namespace TradingCompany.Model {
	public interface IGame {
		IRoundsManager RoundsManager { get; }
		IBoard Board { get; }
		IHeroesManager HeroesManager { get; }
	}
}