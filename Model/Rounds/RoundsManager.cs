using System;
using TradingCompany.Communication.Data;

namespace TradingCompany.Model.Rounds {
	public class RoundsManager : IRoundsManager {
		public RoundsManager(InitializationData initializationData) {
			RoundBeingPreparedIndex = 0;
			GameStartTime = initializationData.GameStartTime;
			RoundBeingPreparedDeadline = initializationData.NextUpdateDeadline;
		}

		public int RoundBeingPreparedIndex { get; private set; }
		public DateTime RoundBeingPreparedDeadline { get; private set; }
		public DateTime GameStartTime { get; }

		public event Action RoundResolved;

		public void Update(RoundResultData roundResultData) {
			RoundBeingPreparedIndex = roundResultData.RoundIndex;
			RoundBeingPreparedDeadline = roundResultData.NextUpdateDeadline;
			RoundResolved?.Invoke();
		}
	}
}