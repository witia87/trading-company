using System;
using System.Collections.Generic;
using TradingCompany.Common.Math;
using TradingCompany.Model.Commands;

namespace TradingCompany.Model.Heroes {
	public class HeroesManager : IHeroesManager {
		private readonly IDictionary<int, Hero> _heroes = new Dictionary<int, Hero>();

		public HeroesManager(ISet<Hero> heroes) {
			foreach (var hero in heroes) {
				_heroes.Add(hero.Id, hero);
			}

			PositionsToHeroesDictionary = new Dictionary<IntVector2, IHero>();

			foreach (var hero in heroes) {
				PositionsToHeroesDictionary.Add(hero.Position, hero);
				hero.PositionChanged += GetHeroOnPositionChanged(hero);
			}
		}

		// TODO: Remove?
		public ISet<IHero> Heroes => new HashSet<IHero>(_heroes.Values);
		public IDictionary<IntVector2, IHero> PositionsToHeroesDictionary { get; }

		private Action<IntVector2> GetHeroOnPositionChanged(Hero hero) {
			return oldPosition => {
				PositionsToHeroesDictionary.Remove(oldPosition);
				PositionsToHeroesDictionary.Add(hero.Position, hero);
			};
		}

		public void Update(IDictionary<int, Command> commandsAppliedForHeroes) {
			foreach (var id in commandsAppliedForHeroes.Keys) {
				_heroes[id].ResolveCommand(commandsAppliedForHeroes[id]);
			}
		}
	}
}