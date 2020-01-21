using System;
using System.Collections.Generic;

namespace TradingCompany.View {
	public static class EventDispatcher {
		private static readonly Dictionary<EventType, List<Action<object>>> StoreSubscriptions =
			new Dictionary<EventType, List<Action<object>>>();

		private static readonly Dictionary<EventType, List<Action>> ViewSubscriptions =
			new Dictionary<EventType, List<Action>>();

		private static bool _isDispatching;


		public static void RegisterAsStore(EventType eventType,
		                                   Action<object> handler) {
			if (!StoreSubscriptions.ContainsKey(eventType)) {
				StoreSubscriptions.Add(eventType, new List<Action<object>>());
			}

			StoreSubscriptions[eventType].Add(handler);
		}

		public static void RegisterAsView(EventType eventType,
		                                  Action handler) {
			if (!ViewSubscriptions.ContainsKey(eventType)) {
				ViewSubscriptions.Add(eventType, new List<Action>());
			}

			ViewSubscriptions[eventType].Add(handler);
		}

		public static void Dispatch(EventType eventType,
		                            object payload) {
			if (_isDispatching) {
				throw new ApplicationException("Other event is already being executed");
			}

			_isDispatching = true;

			if (StoreSubscriptions.ContainsKey(eventType)) {
				StoreSubscriptions[eventType].ForEach(subscription => { subscription.Invoke(payload); });
			}

			if (ViewSubscriptions.ContainsKey(eventType)) {
				ViewSubscriptions[eventType].ForEach(subscription => { subscription.Invoke(); });
			}

			_isDispatching = false;
		}
	}
}