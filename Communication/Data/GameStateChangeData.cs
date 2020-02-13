using System.Collections.Generic;
using TradingCompany.Model.Commands;

namespace TradingCompany.Communication.Data {
	public struct GameStateChangeData {
		public readonly IDictionary<int, Command> CommandsAppliedForHeroes;

		public GameStateChangeData(IDictionary<int, Command> commandsAppliedForHeroes) {
			CommandsAppliedForHeroes = commandsAppliedForHeroes;
		}
	}
}