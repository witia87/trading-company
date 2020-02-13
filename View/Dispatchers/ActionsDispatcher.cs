using System;
using System.Collections.Generic;

namespace TradingCompany.View.Dispatchers {
	public class ActionsDispatcher : IActionsDispatcher {
		private readonly Dictionary<ActionType, List<Action<object>>> StoreSubscriptions =
			new Dictionary<ActionType, List<Action<object>>>();

		private ActionType _dispatchedActionType;

		private bool _isDispatching;

		public void Dispatch(ActionType actionType,
		                     object payload) {
			if (_isDispatching) {
				throw new ApplicationException("Other action (" + _dispatchedActionType +
				                               ") is already being executed while trying to dispatch " + actionType);
			}

			_isDispatching = true;
			_dispatchedActionType = actionType;

			if (StoreSubscriptions.ContainsKey(actionType)) {
				StoreSubscriptions[actionType].ForEach(subscription => { subscription.Invoke(payload); });
			}

			_isDispatching = false;
		}


		public void RegisterAsStore(ActionType actionType,
		                            Action<object> handler) {
			if (!StoreSubscriptions.ContainsKey(actionType)) {
				StoreSubscriptions.Add(actionType, new List<Action<object>>());
			}

			StoreSubscriptions[actionType].Add(handler);
		}
	}
}