using System.Collections.Generic;
using System.Linq;
using Acro.Data.Interfaces;
using Acro.Data.StoredProcs;

namespace Acro.Data.Implementations
{
	public class ProductRepository : IProductRepository
	{
		private readonly StoredProcWrapper _storedProcWrapper;

		public ProductRepository(StoredProcWrapper storedProcWrapper)
		{
			_storedProcWrapper = storedProcWrapper;
		}

		public IEnumerable<ProductDo> GetActiveProducts()
		{
			return _storedProcWrapper.Execute<ProductDo>(new StoredProcedureParameters()
			{
				StoredProcName = SpProducts.Name,
				Params = new {Action = SpProducts.ActionSelectActive}
			});
		}

		public IEnumerable<ProductDo> GetAllProducts()
		{
			return _storedProcWrapper.Execute<ProductDo>(new StoredProcedureParameters()
			{
				StoredProcName = SpProducts.Name,
				Params = new { Action = SpProducts.ActionSelectAll }
			});
		}

		public ProductDo GetOne(int id)
		{
			return _storedProcWrapper.ExecuteOne<ProductDo>(new StoredProcedureParameters()
			{
				StoredProcName = SpProducts.Name,
				Params = new { Action = SpProducts.ActionSelectOne, ProductID = id }
			});
		}

		public int AddNew(ProductDo product)
		{
			return _storedProcWrapper.ExecuteOne<int>(new StoredProcedureParameters()
			{
				StoredProcName = SpProducts.Name,
				Params = new
				{
					Action = SpProducts.ActionAddNew,
					product.ProductName,
					product.SupplierID,
					product.CategoryID,
					product.QuantityPerUnit,
					product.UnitPrice,
					product.UnitsInStock,
					UnitsOnOrder = product.UnitsOnOrder,
					product.ReorderLevel,
					product.Discontinued,
				}
			});
		}

		public void Update(ProductDo product)
		{
			_storedProcWrapper.ExecuteNonQuery(new StoredProcedureParameters()
			{
				StoredProcName = SpProducts.Name,
				Params = new
				{
					Action = SpProducts.ActionUpdate,
					product.ProductID,
					product.ProductName,
					product.SupplierID,
					product.CategoryID,
					product.QuantityPerUnit,
					product.UnitPrice,
					product.UnitsInStock,
					UnitsOnOrder = product.UnitsOnOrder,
					product.ReorderLevel,
					product.Discontinued,
				}
			});
		}


		public void Delete(int id)
		{
			_storedProcWrapper.ExecuteNonQuery(new StoredProcedureParameters()
			{
				StoredProcName = SpProducts.Name,
				Params = new
				{
					Action = SpProducts.ActionDelete,
					ProductID = id
				}
			});
		}
	}

	public class StoredProcedureParameters
	{
		public string StoredProcName { get; set; }
		public object Params { get; set; }
	}
}