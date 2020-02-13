using System;
using TradingCompany.Common.Math;
using TradingCompany.Model.Commands;

namespace TradingCompany.Model.Heroes {
	public interface IHero {
		IntVector2 Position { get; }

		event Action<IntVector2> PositionChanged;

		event Action<Command> CommandResolved;

		void SetNextCommand(Command command);
	}
}