using System;
using System.Collections.Generic;
using System.Text;
using Acro.BusinessLogic.Dto;
using Acro.Data;
using AutoMapper;

namespace Acro.BusinessLogic.MapperProfiles
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			this.CreateMap<ProductDo, ProductDto>();
		}
	}
}
