using System.Collections.Generic;
using TradingCompany.Model;
using TradingCompany.Model.Math;
using TradingCompany.PlayerSupport.Ai.PathFinding.PriorityQueues;

namespace TradingCompany.PlayerSupport.Ai.PathFinding {
	public class PathFinder {
		private readonly int _columns;
		private readonly int _rows;
		private readonly byte[][][] _weights;

		public PathFinder(IBoard board) {
			_weights = WeightsFactory.Create(board);
			_rows = board.Rows;
			_columns = board.Columns;
		}

		public List<IntVector2> FindPath(IntVector2 from, IntVector2 to) {
			var priorityQueue = new PriorityQueue(_weights.GetLength(0) * _weights.GetLength(1));

			priorityQueue.Enqueue(from, 0, new IntVector2(-1, -1));
			while (priorityQueue.Count > 0) {
				var currentEntry = priorityQueue.Dequeue();
				var currentPosition = currentEntry.Position;
				for (var offsetIndex = 0; offsetIndex < IntVector2.HexOffsets.Length; offsetIndex++) {
					var weight = _weights[currentPosition.y][currentPosition.x][offsetIndex];
					if (weight > 0) {
						var neighborPosition = currentPosition + IntVector2.HexOffsets[offsetIndex];
						if (!priorityQueue.HasBeenEnqueued(neighborPosition)) {
							priorityQueue.Enqueue(neighborPosition, currentEntry.Weight + weight,
								currentPosition);
						}
						else {
							if (priorityQueue.Get(neighborPosition).Weight > currentEntry.Weight + weight) {
								priorityQueue.DecreaseWeight(neighborPosition, currentEntry.Weight + weight,
									currentPosition);
							}
						}
					}
				}
			}

			return priorityQueue.HasBeenEnqueued(to)
				? RecreatePath(priorityQueue.Get(to), priorityQueue)
				: null;
		}

		private List<IntVector2> RecreatePath(WeightedNode weightedNode, PriorityQueue priorityQueue) {
			var path = new List<IntVector2>();
			while (weightedNode != null) {
				path.Add(weightedNode.LastVisitedFrom);
				weightedNode = priorityQueue.Get(weightedNode.LastVisitedFrom);
			}

			path.Reverse();
			return path;
		}
	}
}