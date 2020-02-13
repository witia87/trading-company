using System;
using System.Threading.Tasks;
using Godot;
using TradingCompany.Common.Math;
using TradingCompany.Common.Promises;
using TradingCompany.Model;
using TradingCompany.Model.Commands;
using TradingCompany.Model.Heroes;
using TradingCompany.PlayerSupport.PathFinding;

namespace TradingCompany.PlayerSupport {
	public class Planner : IPlanner {
		private static PathFinder _pathFinder;

		public Planner(IBoard board) {
			_pathFinder = new PathFinder(board);
		}

		public IPromise<Plan> GetActionPlan(IHero hero,
		                                    IntVector2 targetPosition) {
			return new Promise<Plan>(resolve => {
				// TODO: Remove forced delay (added for testing purpose)
				Task.Delay(TimeSpan.FromMilliseconds(100)).ContinueWith(task => {
					var path = _pathFinder.FindPath(hero.Position, targetPosition);
					if (path.Count > 0) {
						resolve(new Plan(hero, path.ConvertAll(position => new Command(position, CommandType.Move))));
					}
					else {
						GD.Print("Cannot find path");
					}
				});
			});
		}
	}
}