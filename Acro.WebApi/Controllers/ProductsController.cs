using System;
using System.Collections.Generic;
using System.Linq;
using Acro.BusinessLogic.Dto;
using Acro.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Acro.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
	    private readonly IProductBusinessLogic _productBusinessLogic;

	    public ProductsController(IProductBusinessLogic productBusinessLogic)
	    {
		    _productBusinessLogic = productBusinessLogic;
	    }

        [HttpGet]
        public IEnumerable<ProductDto> Get([FromQuery]ProductsFilter filter)
        {
            return _productBusinessLogic.Get(filter);
        }

        [HttpGet("{id}")]
        public ProductDto Get(int id)
        {
            return _productBusinessLogic.GetOne(id);
		}

        [HttpPost]
        public IActionResult Post([FromBody] CreateProductDto product)
        {
	        return this.Created(string.Empty, _productBusinessLogic.AddNew(product));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProductDto product)
        {
	        product.ProductID = id;
	        _productBusinessLogic.Update(product);
	        return NoContent();
        }

		[HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
			_productBusinessLogic.Delete(id);
	        return NoContent();
		}
	}
}
