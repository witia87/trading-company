using Godot;
using TradingCompany.Model.Commands;
using TradingCompany.Model.Heroes;
using TradingCompany.View.Dispatchers;

namespace TradingCompany.View.Heroes {
	public class HeroCommandsActionCreator : Node {
		private IHero _hero;

		public override void _Ready() {
			_hero = GetParent<HeroView>().Hero;
			_hero.CommandResolved += HeroOnCommandResolved;
		}

		private void HeroOnCommandResolved(Command obj) {
			ViewModel.ActionsDispatcher.Dispatch(ActionType.HeroCommandExecuted,
				new ExecutedCommandPayload(_hero, obj));
		}
	}
}