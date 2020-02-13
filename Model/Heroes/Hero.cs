using System;
using TradingCompany.Common.Math;
using TradingCompany.Communication;
using TradingCompany.Model.Commands;

namespace TradingCompany.Model.Heroes {
	public class Hero : IHero {
		private readonly IGateway _gateway;

		public Hero(int id,
		            IntVector2 position,
		            IGateway gateway) {
			Id = id;
			Position = position;
			_gateway = gateway;
		}

		public int Id { get; }

		public IntVector2 Position { get; set; }

		public event Action<IntVector2> PositionChanged;
		public event Action<Command> CommandResolved;


		public void SetNextCommand(Command command) {
			_gateway.PushCommandsForHero(Id, command);
		}

		public void ResolveCommand(Command command) {
			if (command.Type.Equals(CommandType.Move)) {
				if (!Position.Equals(command.TargetPosition)) {
					var oldPosition = Position;
					Position = command.TargetPosition;
					PositionChanged?.Invoke(oldPosition);
				}
				else {
					throw new ApplicationException("Position is the same as before");
				}
			}

			CommandResolved?.Invoke(command);
		}
	}
}