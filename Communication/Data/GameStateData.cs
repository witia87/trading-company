using System.Collections.Generic;

namespace TradingCompany.Communication.Data {
	public struct GameStateData {
		public readonly BoardData BoardData;
		public readonly ISet<HeroData> HeroesData;

		public GameStateData(BoardData boardData,
		                     ISet<HeroData> heroesData) {
			BoardData = boardData;
			HeroesData = heroesData;
		}
	}
}