using System;
using System.Collections.Generic;
using TradingCompany.Common.Math;

namespace TradingCompany.PlayerSupport.PathFinding.PriorityQueues {
	public class PriorityQueue {
		private readonly WeightedNode[] _positions;

		private readonly Dictionary<IntVector2, WeightedNode> _weightedNodes =
			new Dictionary<IntVector2, WeightedNode>();

		public PriorityQueue(int totalNodesCount) {
			_positions = new WeightedNode[totalNodesCount];
		}

		public int Count { get; private set; }

		public void Enqueue(IntVector2 position,
		                    int initialWeight,
		                    IntVector2 initiallyVisitedFrom) {
			if (_weightedNodes.ContainsKey(position)) {
				throw new ApplicationException("Cannot register Node twice");
			}

			_positions[Count] = new WeightedNode(position, initialWeight, Count, initiallyVisitedFrom);
			_weightedNodes[position] = _positions[Count];
			Count++;
			SortUp(Count - 1);
		}

		public WeightedNode Peek() {
			return _positions[0];
		}

		public WeightedNode Dequeue() {
			Swap(0, Count - 1);
			Count--;
			SortDown(0);
			return _positions[Count];
		}

		public bool HasBeenEnqueued(IntVector2 position) {
			return _weightedNodes.ContainsKey(position);
		}

		public WeightedNode Get(IntVector2 position) {
			return _weightedNodes[position];
		}

		public void DecreaseWeight(IntVector2 position,
		                           int newWeight,
		                           IntVector2 lastVisitedFrom) {
			_weightedNodes[position].Weight = newWeight;
			_weightedNodes[position].LastVisitedFrom = lastVisitedFrom;
			SortUp(_weightedNodes[position].Index);
		}

		private void SortUp(int positionIndex) {
			while (positionIndex > 0 && _positions[positionIndex].Weight < _positions[(positionIndex - 1) / 2].Weight) {
				Swap(positionIndex, positionIndex / 2);
				positionIndex /= 2;
			}
		}

		private void SortDown(int positionIndex) {
			if (positionIndex * 2 + 1 >= Count) {
				return;
			}

			var minIndex = positionIndex * 2 + 2 >= Count ||
			               _positions[positionIndex * 2 + 1].Weight <= _positions[positionIndex * 2 + 2].Weight
				? positionIndex * 2 + 1
				: positionIndex * 2 + 2;

			Swap(positionIndex, minIndex);
			SortDown(minIndex);
		}

		private void Swap(int index1,
		                  int index2) {
			var temp = _positions[index1];
			_positions[index1] = _positions[index2];
			_positions[index2] = temp;
			_positions[index1].Index = index1;
			_positions[index2].Index = index2;
		}
	}
}