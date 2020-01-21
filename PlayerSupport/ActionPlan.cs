using System;
using System.Collections.Generic;
using TradingCompany.Model.Commands;

namespace TradingCompany.PlayerSupport {
	public struct ActionPlan : IEquatable<ActionPlan> {
		public readonly List<Command> CommandsSequence;

		public ActionPlan(List<Command> commandsSequence) {
			CommandsSequence = commandsSequence;
		}

		public bool Equals(ActionPlan other) {
			return Equals(CommandsSequence, other.CommandsSequence);
		}

		public override bool Equals(object obj) {
			return obj is ActionPlan other && Equals(other);
		}

		public override int GetHashCode() {
			return (CommandsSequence != null ? CommandsSequence.GetHashCode() : 0);
		}
	}
}