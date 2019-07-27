using System.Collections.Generic;
using Acro.BusinessLogic.Dto;

namespace Acro.BusinessLogic.Interfaces
{
	public interface IProductBusinessLogic
	{
		IEnumerable<ProductDto> Get(ProductsFilter filter);
		ProductDto GetOne(int id);
		ProductDto AddNew(CreateProductDto product);
		ProductDto Update(UpdateProductDto product);
		void Delete(int id);
	}
}