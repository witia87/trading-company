using System;

namespace TradingCompany.View.Dispatchers {
	public interface IStoreEvent<T> {
		void Register(Action<T, Action> callback,
		              SubscriptionPriority priority = SubscriptionPriority.Normal);
	}
}