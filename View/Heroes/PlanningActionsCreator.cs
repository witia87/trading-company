using Godot;
using TradingCompany.PlayerSupport;
using TradingCompany.View.Dispatchers;

namespace TradingCompany.View.Heroes {
	public class PlanningActionsCreator : Node {
		private PlanningWorker _planningWorker;

		public override void _Ready() {
			_planningWorker = GetChild<PlanningWorker>(0);
			_planningWorker.PlanCreated += DispatchPlanCreatedAction;
		}

		private void DispatchPlanCreatedAction(Plan plan) {
			ViewModel.ActionsDispatcher.Dispatch(ActionType.PlanCreated, plan);
		}
	}
}