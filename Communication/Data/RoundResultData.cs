using System;

namespace TradingCompany.Communication.Data {
	public struct RoundResultData {
		public readonly int RoundIndex;
		public readonly DateTime NextUpdateDeadline;
		public readonly GameStateChangeData GameStateChangeData;

		public RoundResultData(int roundIndex,
		                       DateTime nextUpdateDeadline,
		                       GameStateChangeData gameStateChangeData) {
			RoundIndex = roundIndex;
			NextUpdateDeadline = nextUpdateDeadline;
			GameStateChangeData = gameStateChangeData;
		}
	}
}