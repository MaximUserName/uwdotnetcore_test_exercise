using System;
using System.Collections.Generic;
using System.IO;
using Acro.BusinessLogic.Dto;
using Acro.BusinessLogic.Interfaces;
using Acro.Data;
using Acro.Data.Interfaces;
using AutoMapper;

namespace Acro.BusinessLogic.Implementations
{
	public class ProductBusinessLogic : IProductBusinessLogic
	{
		#region Fields

		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;

		#endregion

		#region Ctor

		public ProductBusinessLogic(IProductRepository productRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}

		#endregion

		#region Public Methods

		public IEnumerable<ProductDto> Get(ProductsFilter filter)
		{
			var productDos = GetProductsByFilter(filter);
			return _mapper.Map<IEnumerable<ProductDto>>(productDos);
		}
		
		public ProductDto GetOne(int id)
		{
			var product = _productRepository.GetOne(id);
			return _mapper.Map<ProductDto>(product);
		}

		public ProductDto AddNew(CreateProductDto product)
		{
			var id = _productRepository.AddNew(_mapper.Map<ProductDo>(product));
			return GetOne(id);
		}

		public ProductDto Update(UpdateProductDto product)
		{
			_productRepository.Update(_mapper.Map<ProductDo>(product));
			return GetOne(product.ProductID);
		}

		public void Delete(int id)
		{
			_productRepository.Delete(id);
		}

		#endregion

		#region Private Methods

		private IEnumerable<ProductDo> GetProductsByFilter(ProductsFilter filter)
		{
			if (filter.IsActive == true)
				return _productRepository.GetActiveProducts();
			return _productRepository.GetAllProducts();
		}

		#endregion

	}
}