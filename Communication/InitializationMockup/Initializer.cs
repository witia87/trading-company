using Godot;
using TradingCompany.Communication.Data;

namespace TradingCompany.Communication.InitializationMockup {
	public class Initializer : Node {
		public GameStateData GetInitialGameState() {
			var boardInitializer = GetNode<BoardInitializer>("./BoardInitializer");
			var heroesInitializer = GetNode<HeroesInitializer>("./HeroesInitializer");
			var boardData = boardInitializer.CreateBoardData();
			var heroesData = heroesInitializer.CreateHeroesData();

			return new GameStateData(boardData, heroesData);
		}
	}
}