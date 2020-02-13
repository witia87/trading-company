using TradingCompany.Common.Math;

namespace TradingCompany.Communication.Data {
	public struct HeroData {
		public readonly int Id;
		public readonly IntVector2 Position;

		public HeroData(int id,
		                IntVector2 position) {
			Id = id;
			Position = position;
		}
	}
}