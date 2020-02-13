using System.Collections.Generic;
using Godot;
using TradingCompany.Common.Math;
using TradingCompany.Communication.Data;

namespace TradingCompany.Communication.InitializationMockup {
	public class HeroesInitializer : Node {
		// TODO: Temporary solution, view will not be a base for board generation

		[Export] private Vector2 _initialHeroPosition;

		public ISet<HeroData> CreateHeroesData() {
			var id = 0;
			return
				new HashSet<HeroData> {
					new HeroData(0, IntVector2.FromVector2(_initialHeroPosition))
				};
		}
	}
}