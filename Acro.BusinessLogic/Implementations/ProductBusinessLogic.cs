using System.Collections.Generic;
using System.IO;
using Acro.BusinessLogic.Dto;
using Acro.BusinessLogic.Interfaces;
using Acro.Data.Interfaces;

namespace Acro.BusinessLogic.Implementations
{
	public class ProductBusinessLogic : IProductBusinessLogic
	{
		private readonly IProductRepository _productRepository;

		public ProductBusinessLogic(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public IEnumerable<ProductDto> Get(ProductsFilter filter)
		{
			return null;
			//if (filter.IsActive == true)
			//	return _productRepository.GetActiveProducts();
		}

		public ProductDto GetOne(int id)
		{
			throw new System.NotImplementedException();
		}

		public ProductDto AddNew(CreateProductDto product)
		{
			throw new System.NotImplementedException();
		}

		public ProductDto Update(UpdateProductDto product)
		{
			throw new System.NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new System.NotImplementedException();
		}
	}
}