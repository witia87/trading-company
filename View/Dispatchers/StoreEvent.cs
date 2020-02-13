using System;
using System.Collections.Generic;

namespace TradingCompany.View.Dispatchers {
	public class StoreEvent<T> : IStoreEvent<T> {
		private readonly List<Action<T, Action>>[] _prioritizedCallbacks;

		public StoreEvent() {
			var enumValues = Enum.GetValues(typeof(SubscriptionPriority));
			_prioritizedCallbacks = new List<Action<T, Action>>[enumValues.Length];
			foreach (var enumValue in enumValues) {
				_prioritizedCallbacks[(int) enumValue] = new List<Action<T, Action>>();
			}
		}

		public void Register(Action<T, Action> callback,
		                     SubscriptionPriority priority = SubscriptionPriority.Normal) {
			_prioritizedCallbacks[(int) priority].Add(callback);
		}

		public void Dispatch(T payload) {
			var fixedCallbacksList = new List<Action<T, Action>>();
			for (var i = _prioritizedCallbacks.Length - 1; i >= 0; i--) {
				_prioritizedCallbacks[i].Shuffle();
				fixedCallbacksList.AddRange(_prioritizedCallbacks[i]);
			}

			ExecuteCallbacks(fixedCallbacksList, payload);
		}

		private static void ExecuteCallbacks(List<Action<T, Action>> remainingCallbacks,
		                                     T payload) {
			if (remainingCallbacks.Count == 0) {
				return;
			}

			var firstCallback = remainingCallbacks[0];
			remainingCallbacks.RemoveAt(0);
			firstCallback(payload, () => { ExecuteCallbacks(remainingCallbacks, payload); });
		}
	}
}