using TradingCompany.Common.Math;
using TradingCompany.View.Dispatchers;

namespace TradingCompany.View.Grounds {
	public class GroundTargetingStore {
		private readonly StoreEvent<IntVector2> _fieldTargeted = new StoreEvent<IntVector2>();

		public GroundTargetingStore(ActionsDispatcher actionsDispatcher) {
			actionsDispatcher.RegisterAsStore(ActionType.UserTargetedGround, OnUserTargetedGround);
		}

		public IStoreEvent<IntVector2> FieldTargeted => _fieldTargeted;

		private void OnUserTargetedGround(object boardPosition) {
			_fieldTargeted.Dispatch((IntVector2) boardPosition);
		}
	}
}