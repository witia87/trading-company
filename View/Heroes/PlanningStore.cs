using System;
using System.Collections.Generic;
using System.Linq;
using TradingCompany.Model.Heroes;
using TradingCompany.PlayerSupport;
using TradingCompany.View.Dispatchers;

namespace TradingCompany.View.Heroes {
	public class PlanningStore {
		public PlanningStore(ActionsDispatcher actionsDispatcher) {
			actionsDispatcher.RegisterAsStore(ActionType.PlanCreated, SetPlanForHero);
			actionsDispatcher.RegisterAsStore(ActionType.HeroCommandExecuted, UpdateHeroesPlans);
		}

		public IDictionary<IHero, Plan> HeroesPlans { get; } = new Dictionary<IHero, Plan>();

		private void UpdateHeroesPlans(object obj) {
			var payload = (ExecutedCommandPayload) obj;
			var commands = HeroesPlans[payload.Hero].CommandsSequence;
			if (commands.First().Equals(payload.Command)) {
				commands.RemoveAt(0);
				if (commands.Count > 0) {
					payload.Hero.SetNextCommand(commands.First());
				}
			}
			else {
				throw new ApplicationException("Executed command was not planned");
			}
		}

		private void SetPlanForHero(object planObject) {
			var plan = planObject as Plan;
			HeroesPlans[plan.Hero] = plan;
			plan.Hero.SetNextCommand(plan.CommandsSequence.First());
		}
	}
}