using System;
using System.Collections.Generic;
using System.Linq;
using Acro.BusinessLogic.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Acro.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<ProductDto> Get([FromQuery]ProductsFilter filter)
        {
            return Enumerable.Empty<ProductDto>();
        }

        [HttpGet("{id}")]
        public ProductDto Get(int id)
        {
            return new ProductDto();
        }

        [HttpPost]
        public void Post([FromBody] CreateProductDto product)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UpdateProductDto product)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
