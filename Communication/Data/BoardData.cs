namespace TradingCompany.Communication.Data {
	public struct BoardData {
		public readonly int Rows, Columns;
		public readonly byte[] FieldTypes;

		public BoardData(int columns,
		                 int rows,
		                 byte[] fieldTypes) {
			Rows = rows;
			Columns = columns;
			FieldTypes = fieldTypes;
		}
	}
}