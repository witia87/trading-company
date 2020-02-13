using System;
using TradingCompany.Communication.Data;
using TradingCompany.Model.Commands;

namespace TradingCompany.Communication {
	public interface IGateway {
		InitializationData StartGame();

		void PushCommandsForHero(int heroId,
		                         Command command);

		event Action<RoundResultData> RoundResolved;
	}
}