using System.Collections.Generic;
using TradingCompany.Model.Commands;
using TradingCompany.Model.Heroes;

namespace TradingCompany.PlayerSupport {
	public class Plan {
		public Plan(IHero hero,
		            List<Command> commandsSequence) {
			Hero = hero;
			CommandsSequence = commandsSequence;
		}

		public IHero Hero { get; }
		public List<Command> CommandsSequence { get; }
	}
}