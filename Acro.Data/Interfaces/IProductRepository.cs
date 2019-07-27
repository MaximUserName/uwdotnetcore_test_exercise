using System.Collections.Generic;

namespace Acro.Data.Interfaces
{
	public interface IProductRepository
	{
		IEnumerable<ProductDo> GetActiveProducts();
		IEnumerable<ProductDo> GetAllProducts();
		ProductDo AddNew();
		void Update();
		void Delete(int id);
	}
}