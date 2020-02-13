using System;
using System.Collections.Generic;
using Godot;
using TradingCompany.Communication.Data;
using TradingCompany.Communication.InitializationMockup;
using TradingCompany.Model.Commands;

namespace TradingCompany.Communication {
	public class Gateway : Node, IGateway {
		public static readonly TimeSpan RoundInterval = new TimeSpan(0, 0, 1);
		private IDictionary<int, Command> _commandsForHeroes = new Dictionary<int, Command>();
		private int _roundIndex;
		private ITicker _ticker;

		public void PushCommandsForHero(int heroId,
		                                Command command) {
			//TODO: Verify and apply on server side
			_commandsForHeroes[heroId] = command;
		}

		public event Action<RoundResultData> RoundResolved;

		public InitializationData StartGame() {
			var initializer = GetNode<Initializer>("./MockupInitializer");
			_ticker = new Ticker();
			_ticker.Tick += TickerOnTick;
			return new InitializationData(DateTime.Now,
				DateTime.Now.Add(RoundInterval),
				initializer.GetInitialGameState());
		}

		private void TickerOnTick() {
			var gameStateChangeData = new GameStateChangeData(_commandsForHeroes);

			// TODO: connect to ticker
			var roundResultData =
				new RoundResultData(_roundIndex++, DateTime.Now.Add(RoundInterval), gameStateChangeData);

			_commandsForHeroes = new Dictionary<int, Command>();
			OnRoundResolved(roundResultData);
		}

		protected virtual void OnRoundResolved(RoundResultData obj) {
			RoundResolved?.Invoke(obj);
		}
	}
}