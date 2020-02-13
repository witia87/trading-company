namespace TradingCompany.Common.Math {
	public class HexOffsets {
		public static readonly int OffsetsCount = 6;

		public static readonly HexOffsets ForEvenPosition = new HexOffsets(new IntVector2(0, 0),
			new IntVector2(0, -1),
			new IntVector2(0, 1),
			new IntVector2(-1, -1),
			new IntVector2(-1, 0),
			new IntVector2(1, -1),
			new IntVector2(1, 0)
		);

		public static readonly HexOffsets ForOddPosition = new HexOffsets(new IntVector2(0, 0),
			new IntVector2(0, -1),
			new IntVector2(0, 1),
			new IntVector2(-1, 0),
			new IntVector2(-1, 1),
			new IntVector2(1, 0),
			new IntVector2(1, 1)
		);

		public readonly IntVector2 Down;
		public readonly IntVector2 LeftBottom;
		public readonly IntVector2 LeftTop;

		public readonly IntVector2[] Offsets;
		public readonly IntVector2 RightBottom;
		public readonly IntVector2 RightTop;
		public readonly IntVector2 Up;

		public readonly IntVector2 Zero;

		public HexOffsets(IntVector2 zero,
		                  IntVector2 up,
		                  IntVector2 down,
		                  IntVector2 leftTop,
		                  IntVector2 leftBottom,
		                  IntVector2 rightTop,
		                  IntVector2 rightBottom) {
			Zero = zero;
			Up = up;
			Down = down;
			LeftTop = leftTop;
			LeftBottom = leftBottom;
			RightTop = rightTop;
			RightBottom = rightBottom;

			Offsets = new[] {
				Up, LeftTop, LeftBottom, Down, RightBottom, RightTop
			};
		}

		public static IntVector2[] GetHexOffsets(IntVector2 position) {
			return position.x % 2 == 0 ? ForEvenPosition.Offsets : ForOddPosition.Offsets;
		}
	}
}