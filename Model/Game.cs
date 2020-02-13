using TradingCompany.Communication;
using TradingCompany.Communication.Data;
using TradingCompany.Model.Heroes;
using TradingCompany.Model.Rounds;

namespace TradingCompany.Model {
	public class Game : IGame {
		private readonly Board _board;
		private readonly IGateway _gateway;
		private readonly HeroesManager _heroesManager;

		private readonly RoundsManager _roundsManager;

		public Game(IGateway gateway,
		            RoundsManager roundsManager,
		            Board board,
		            HeroesManager heroesManager) {
			_gateway = gateway;

			_roundsManager = roundsManager;
			_board = board;
			_heroesManager = heroesManager;

			_gateway.RoundResolved += GatewayOnRoundResolved;
		}

		public IRoundsManager RoundsManager => _roundsManager;

		public IBoard Board => _board;

		public IHeroesManager HeroesManager => _heroesManager;

		private void GatewayOnRoundResolved(RoundResultData roundResultData) {
			_roundsManager.Update(roundResultData);
			_heroesManager.Update(roundResultData.GameStateChangeData.CommandsAppliedForHeroes);
		}
	}
}