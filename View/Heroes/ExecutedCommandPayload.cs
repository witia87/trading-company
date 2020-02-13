using TradingCompany.Model.Commands;
using TradingCompany.Model.Heroes;

namespace TradingCompany.View.Heroes {
	public struct ExecutedCommandPayload {
		public readonly IHero Hero;
		public readonly Command Command;

		public ExecutedCommandPayload(IHero hero,
		                              Command command) {
			Hero = hero;
			Command = command;
		}
	}
}