using System;

namespace TradingCompany.Common.Promises {
	public class Promise<T> : IPromise<T> {
		private readonly Action<Action<T>> _execute;
		private Action<T> _guardedResolveCallback;
		private bool _hasReturned;
		private readonly object _locker = new object();

		public Promise(Action<Action<T>> execute) {
			_execute = execute;
		}

		public IPromise<T> Then(Action<T> resolveCallback) {
			_guardedResolveCallback = input => {
				lock (_locker) {
					if (_hasReturned) {
						throw new ApplicationException("Multiple promise resolves");
					}

					_hasReturned = true;
				}

				resolveCallback(input);
			};

			_execute(_guardedResolveCallback);

			return this;
		}
	}
}