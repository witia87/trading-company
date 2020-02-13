using System;
using TradingCompany.Common.Math;

namespace TradingCompany.Model.Commands {
	public struct Command : IEquatable<Command> {
		public readonly IntVector2 TargetPosition;
		public readonly CommandType Type;

		public Command(IntVector2 targetPosition,
		               CommandType type) {
			TargetPosition = targetPosition;
			Type = type;
		}

		public bool Equals(Command other) {
			return TargetPosition.Equals(other.TargetPosition) && Type == other.Type;
		}

		public override bool Equals(object obj) {
			return obj is Command other && Equals(other);
		}

		public override int GetHashCode() {
			unchecked {
				return (TargetPosition.GetHashCode() * 397) ^ (int) Type;
			}
		}
	}
}