using TradingCompany.Common.Math;
using TradingCompany.Common.Promises;
using TradingCompany.Model.Heroes;

namespace TradingCompany.PlayerSupport {
	public interface IPlanner {
		IPromise<Plan> GetActionPlan(IHero hero,
		                             IntVector2 targetPosition);
	}
}