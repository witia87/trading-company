using System;

namespace TradingCompany.Communication.Data {
	public struct InitializationData {
		public readonly DateTime GameStartTime;
		public readonly DateTime NextUpdateDeadline;
		public readonly GameStateData GameStateData;

		public InitializationData(DateTime gameStartTime,
		                          DateTime nextUpdateDeadline,
		                          GameStateData gameStateData) {
			GameStartTime = gameStartTime;
			NextUpdateDeadline = nextUpdateDeadline;
			GameStateData = gameStateData;
		}
	}
}