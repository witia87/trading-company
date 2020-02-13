using System;
using System.Timers;

namespace TradingCompany.Communication {
	public class Ticker : ITicker {
		private const int Interval = 500;
		private readonly Timer _timer;

		public Ticker() {
			_timer = new Timer();
			_timer.Interval = Interval;
			_timer.AutoReset = true;
			_timer.Elapsed += OnIntervalElapsed;
			_timer.Start();
		}

		public event Action Tick;

		private void OnIntervalElapsed(object target,
		                               ElapsedEventArgs args) {
			Tick?.Invoke();
		}
	}
}