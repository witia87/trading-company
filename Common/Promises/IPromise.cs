using System;

namespace TradingCompany.Common.Promises {
	public interface IPromise<out T> {
		IPromise<T> Then(Action<T> resolveCallback);
	}
}