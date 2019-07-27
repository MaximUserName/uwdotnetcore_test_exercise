namespace Acro.Data
{
	public class ProductDo
	{
		public int ProductID { get; set; }
		public string ProductName { get; set; }

		public string SupplierID { get; set; }
		public string Supplier { get; set; }
		public int CategoryID { get; set; }
		
		public string CategoryName { get; set; }
		public string QuantityPerUnit { get; set; }
		public decimal UnitPrice { get; set; }
		public int UnitsInStock { get; set; }
		public int UnitsInOrder { get; set; }
		public int ReorderLevel { get; set; }

		public bool Discontinued { get; set; }
	}
}