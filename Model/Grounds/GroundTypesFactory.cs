using System.Collections.Generic;

namespace TradingCompany.Model.Grounds {
	public static class GroundTypesFactory {
		private static readonly Dictionary<GroundType, GroundTypeConfig> Configs =
			new Dictionary<GroundType, GroundTypeConfig> {
				{
					GroundType.Water,
					new GroundTypeConfig {
						IsAccessible = false
					}
				}, {
					GroundType.Grass,
					new GroundTypeConfig {
						IsAccessible = true
					}
				}, {
					GroundType.Forest,
					new GroundTypeConfig {
						IsAccessible = false
					}
				}, {
					GroundType.Castle,
					new GroundTypeConfig {
						IsAccessible = true
					}
				}
			};


		public static Ground Create(GroundType groundType) {
			return new Ground(groundType, Configs[groundType].IsAccessible);
		}
	}
}