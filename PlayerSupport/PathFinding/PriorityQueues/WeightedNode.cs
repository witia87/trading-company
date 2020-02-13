using TradingCompany.Common.Math;

namespace TradingCompany.PlayerSupport.PathFinding.PriorityQueues {
	public class WeightedNode {
		public WeightedNode(IntVector2 position,
		                    int initialWeight,
		                    int initialIndex,
		                    IntVector2 lastVisitedFrom) {
			Position = position;
			Weight = initialWeight;
			Index = initialIndex;
			LastVisitedFrom = lastVisitedFrom;
		}

		public IntVector2 Position { get; }
		public int Weight { get; set; }
		public int Index { get; set; }
		public IntVector2 LastVisitedFrom { get; set; }
	}
}