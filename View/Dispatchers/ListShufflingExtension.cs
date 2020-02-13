using System;
using System.Collections.Generic;

namespace TradingCompany.View.Dispatchers {
	public static class ListShufflingExtension {
		private static readonly Random rng = new Random();

		public static void Shuffle<T>(this IList<T> list) {
			var n = list.Count;
			while (n > 1) {
				n--;
				var k = rng.Next(n + 1);
				var value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}
	}
}