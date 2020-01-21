using System;
using Godot;

namespace TradingCompany.Model.Math {
	public struct IntVector2 : IEquatable<IntVector2> {
		public static readonly IntVector2 Zero = new IntVector2(0, 0);
		public static readonly IntVector2 Up = new IntVector2(0, -1);
		public static readonly IntVector2 Down = new IntVector2(0, 1);
		public static readonly IntVector2 LeftTop = new IntVector2(-1, 0);
		public static readonly IntVector2 LeftBottom = new IntVector2(-1, 1);
		public static readonly IntVector2 RightTop = new IntVector2(1, 0);
		public static readonly IntVector2 RightBottom = new IntVector2(1, 1);

		public static readonly IntVector2[] HexOffsets = {
			Up, LeftTop, LeftBottom, Down, RightBottom, RightTop
		};

		public int x;
		public int y;

		public IntVector2(int x, int y) {
			this.x = x;
			this.y = y;
		}

		public bool Equals(IntVector2 other) {
			return x == other.x && y == other.y;
		}

		public static IntVector2 operator +(IntVector2 left, IntVector2 right) {
			left.x += right.x;
			left.y += right.y;
			return left;
		}

		public static IntVector2 operator -(IntVector2 left, IntVector2 right) {
			left.x -= right.x;
			left.y -= right.y;
			return left;
		}

		public static IntVector2 FromVector2(Vector2 v) {
			return new IntVector2(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y));
		}

		public Vector2 ToVector2() {
			return new Vector2(x, y);
		}
	}
}