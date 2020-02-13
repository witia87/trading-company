namespace TradingCompany.Model.Grounds {
	public struct Ground {
		public GroundType GroundType;
		public bool IsAccessible;

		public Ground(GroundType groundType,
		              bool isAccessible) {
			GroundType = groundType;
			IsAccessible = isAccessible;
		}
	}
}