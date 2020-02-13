using System;

namespace TradingCompany.Communication {
	public interface ITicker {
		event Action Tick;
	}
}