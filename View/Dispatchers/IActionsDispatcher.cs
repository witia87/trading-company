namespace TradingCompany.View.Dispatchers {
	public interface IActionsDispatcher {
		void Dispatch(ActionType actionType,
		              object payload);
	}
}