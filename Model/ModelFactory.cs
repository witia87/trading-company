using System.Collections.Generic;
using TradingCompany.Communication;
using TradingCompany.Communication.Data;
using TradingCompany.Model.Grounds;
using TradingCompany.Model.Heroes;
using TradingCompany.Model.Rounds;

namespace TradingCompany.Model {
	public static class ModelFactory {
		public static IGame Create(IGateway gateway) {
			var initializationData = gateway.StartGame();
			var roundsManager = CreateRoundsManager(initializationData);
			var board = CreateBoard(initializationData.GameStateData.BoardData);
			var heroesManager = CreateHeroesManager(initializationData.GameStateData.HeroesData, gateway);
			return new Game(gateway, roundsManager, board, heroesManager);
		}

		private static RoundsManager CreateRoundsManager(InitializationData initializationData) {
			return new RoundsManager(initializationData);
		}

		private static Board CreateBoard(BoardData boardData) {
			var fields = new Field[boardData.Rows, boardData.Columns];
			for (var row = 0; row < boardData.Rows; row++) {
				for (var column = 0; column < boardData.Columns; column++) {
					var groundType =
						GroundTypesMapping.GetGroundType(boardData.FieldTypes[row * boardData.Columns + column]);
					fields[row, column] = new Field(column, row,
						GroundsFactory.Create(groundType));
				}
			}

			return new Board(fields);
		}

		private static HeroesManager CreateHeroesManager(ISet<HeroData> heroesData,
		                                                 IGateway gateway) {
			var heroes = new HashSet<Hero>();
			foreach (var heroData in heroesData) {
				heroes.Add(new Hero(heroData.Id, heroData.Position, gateway));
			}

			return new HeroesManager(heroes);
		}
	}
}