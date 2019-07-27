using System.Collections.Generic;
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
			throw new System.NotImplementedException();
		}

		public IEnumerable<ProductDo> GetAllProducts()
		{
			throw new System.NotImplementedException();
		}

		public ProductDo AddNew()
		{
			throw new System.NotImplementedException();
		}

		public void Update()
		{
			throw new System.NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new System.NotImplementedException();
		}
	}
}