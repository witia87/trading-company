using Godot;
using TradingCompany.Model.Heroes;
using TradingCompany.View.Common;
using TradingCompany.View.Dispatchers;

namespace TradingCompany.View.Heroes {
	public class HeroMouseActionsCreator : Node2D {
		private IHero _hero;

		private InputDetector _inputDetector;

		public override void _Ready() {
			_hero = GetParent<HeroView>().Hero;
			_inputDetector = GetChild<InputDetector>(0);
			_inputDetector.HoverEventDetected += OnHoverInputDetected;
			_inputDetector.SelectEventDetected += OnSelectEventDetected;
		}

		private void OnHoverInputDetected(Vector2 position) {
			ViewModel.ActionsDispatcher.Dispatch(ActionType.UserHoveredOverHero, _hero);
		}

		private void OnSelectEventDetected(Vector2 position) {
			ViewModel.ActionsDispatcher.Dispatch(ActionType.UserSelectedHero, _hero);
		}
	}
}