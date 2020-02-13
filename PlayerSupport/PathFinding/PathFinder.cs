using System.Collections.Generic;
using TradingCompany.Common.Math;
using TradingCompany.Model;
using TradingCompany.PlayerSupport.PathFinding.PriorityQueues;

namespace TradingCompany.PlayerSupport.PathFinding {
	public class PathFinder {
		private static readonly IntVector2 Guard = new IntVector2(-1, -1);
		private readonly int _columns;

		private readonly int _rows;
		private readonly byte[,,] _weights;

		public PathFinder(IBoard board) {
			_weights = WeightsFactory.Create(board);
			_rows = board.Rows;
			_columns = board.Columns;
		}

		public List<IntVector2> FindPath(IntVector2 from,
		                                 IntVector2 to) {
			var priorityQueue = new PriorityQueue(_rows * _columns);

			priorityQueue.Enqueue(from, 0, Guard);
			while (priorityQueue.Count > 0 && !priorityQueue.Peek().Position.Equals(to)) {
				var currentEntry = priorityQueue.Dequeue();
				var currentPosition = currentEntry.Position;
				var hexOffsets = HexOffsets.GetHexOffsets(currentPosition);
				for (var offsetIndex = 0; offsetIndex < hexOffsets.Length; offsetIndex++) {
					var weight = _weights[currentPosition.y, currentPosition.x, offsetIndex];
					if (weight > 0) {
						var neighborPosition = currentPosition + hexOffsets[offsetIndex];
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
				: new List<IntVector2>();
		}

		private List<IntVector2> RecreatePath(WeightedNode weightedNode,
		                                      PriorityQueue priorityQueue) {
			var path = new List<IntVector2>();
			while (!weightedNode.LastVisitedFrom.Equals(Guard)) {
				path.Add(weightedNode.Position);
				weightedNode = priorityQueue.Get(weightedNode.LastVisitedFrom);
			}

			path.Reverse();
			return path;
		}
	}
}