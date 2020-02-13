using TradingCompany.Model.Grounds;

namespace TradingCompany.Model {
	public static class GroundTypesMapping {
		private static readonly GroundType[] _codesMapping = {
			GroundType.Water, GroundType.Grass, GroundType.Forest, GroundType.Castle
		};

		public static GroundType GetGroundType(byte groundTypeCode) {
			return _codesMapping[groundTypeCode];
		}
	}
}