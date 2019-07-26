using System;
using System.Collections.Generic;
using System.Text;

namespace Acro.BusinessLogic.Dto
{
	public class ProductsFilter
	{
		public bool? IsActive { get; set; }
	}

	public class ProductDto
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

	public class CreateProductDto
	{
		public string ProductName { get; set; }

		public string SupplierID { get; set; }
		public int CategoryID { get; set; }

		public string QuantityPerUnit { get; set; }
		public decimal UnitPrice { get; set; }
		public int UnitsInStock { get; set; }
		public int UnitsInOrder { get; set; }
		public int ReorderLevel { get; set; }

		public bool Discontinued { get; set; }
	}

	public class UpdateProductDto
	{
		public string ProductName { get; set; }

		public string SupplierID { get; set; }
		public int CategoryID { get; set; }

		public string QuantityPerUnit { get; set; }
		public decimal UnitPrice { get; set; }
		public int UnitsInStock { get; set; }
		public int UnitsInOrder { get; set; }
		public int ReorderLevel { get; set; }

		public bool Discontinued { get; set; }
	}
}
