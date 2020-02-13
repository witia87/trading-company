using System;
using TradingCompany.Model.Rounds;

namespace TradingCompany.View.Rounds {
	public class RoundStore {
		private readonly IRoundsManager _roundsManager;

		public RoundStore(IRoundsManager roundsManager) {
			_roundsManager = roundsManager;
		}

		public int RoundBeingPreparedIndex => _roundsManager.RoundBeingPreparedIndex;
		public DateTime RoundBeingPreparedDeadline => _roundsManager.RoundBeingPreparedDeadline;
		public DateTime GameStartTime => _roundsManager.GameStartTime;
	}
}