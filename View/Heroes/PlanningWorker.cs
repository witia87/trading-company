using System;
using Godot;
using TradingCompany.Common.Math;
using TradingCompany.PlayerSupport;

namespace TradingCompany.View.Heroes {
	public class PlanningWorker : Node {
		private int _requestedPlanId;
		
		/// <summary>
		/// HalfCycle Contract:
		/// Asynchronous events need to be synchronized with Godot timeline for View purpose. 
		/// </summary>
		private bool _doesRecievedPlanRequirePushing;
		private Plan _recievedPlan;

		public PlanningWorker() {
			ViewModel.ViewModelCreated += () =>
				ViewModel.GroundTargetingStore.FieldTargeted.Register(OnFieldTargeted);
		}

		public event Action<Plan> PlanCreated;

		private void OnFieldTargeted(IntVector2 targetPosition,
		                             Action done) {
			if (ViewModel.HeroesSelectingStore.IsHeroSelected) {
				_requestedPlanId++;
				ViewModel.Planner
					.GetActionPlan(ViewModel.HeroesSelectingStore.SelectedHero,
						ViewModel.GroundHighlightingStore.HighlightedFieldPosition)
					.Then(GetPlanCreatedCallback(_requestedPlanId));
			}

			done();
		}

		private Action<Plan> GetPlanCreatedCallback(int requestedPlanId) {
			return plan => {
				if (requestedPlanId == _requestedPlanId) {
					_doesRecievedPlanRequirePushing = true;
					_recievedPlan = plan;
				}
			};
		}

		public override void _Process(float delta) {
			if (_doesRecievedPlanRequirePushing) {
				_doesRecievedPlanRequirePushing = false;
				PlanCreated?.Invoke(_recievedPlan);
				_recievedPlan = null;
			}
		}
	}
}