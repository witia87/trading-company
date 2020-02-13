using System.Linq;
using Godot;
using TradingCompany.Common.Math;
using TradingCompany.Model.Heroes;
using TradingCompany.View.Board;

namespace TradingCompany.View.Heroes {
	public class HeroView : Sprite {
		private readonly Tween _tween = new Tween();

		public HeroView() {
			ViewModel.ViewModelCreated += () => {
				Hero = ViewModel.HeroesStore.Heroes.First();
				Position = BoardUtil.ToWorldPosition(Hero.Position);
				Hero.PositionChanged += HeroOnPositionChanged;
			};
		}

		public IHero Hero { get; private set; }

		public override void _Ready() {
			AddChild(_tween);
		}

		public override void _Process(float delta) {
			if (ViewModel.HeroesSelectingStore.IsHeroSelected
			    && Hero.Equals(ViewModel.HeroesSelectingStore.SelectedHero)) {
				Modulate = Colors.Green;
			}
			else if (ViewModel.HeroesHighlightingStore.IsHeroHighlighted
			         && Hero.Equals(ViewModel.HeroesHighlightingStore.HighlightedHero)) {
				Modulate = Colors.White;
			}
			else {
				Modulate = Colors.Black;
			}
		}

		private void HeroOnPositionChanged(IntVector2 oldPosition) {
			_tween.RemoveAll();
			_tween.InterpolateProperty(this, "Position", 
				BoardUtil.ToWorldPosition(oldPosition),
				BoardUtil.ToWorldPosition(Hero.Position),
				0.5f, Tween.TransitionType.Linear, Tween.EaseType.InOut);
			_tween.Start();
		}
	}
}