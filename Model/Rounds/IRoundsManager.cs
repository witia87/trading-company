using System;

namespace TradingCompany.Model.Rounds {
	public interface IRoundsManager {
		int RoundBeingPreparedIndex { get; }
		DateTime RoundBeingPreparedDeadline { get; }
		DateTime GameStartTime { get; }

		event Action RoundResolved;
	}
}