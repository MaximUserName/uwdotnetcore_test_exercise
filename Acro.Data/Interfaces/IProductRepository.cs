using System.Collections.Generic;

namespace Acro.Data.Interfaces
{
	public interface IProductRepository
	{
		IEnumerable<ProductDo> GetActiveProducts();
		IEnumerable<ProductDo> GetAllProducts();
		ProductDo GetOne(int id);
		int AddNew(ProductDo product);
		void Update(ProductDo product);
		void Delete(int id);
	}
}