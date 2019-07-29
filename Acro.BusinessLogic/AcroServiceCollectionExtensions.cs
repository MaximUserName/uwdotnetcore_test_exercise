using System;
using Acro.BusinessLogic.Dto;
using Acro.BusinessLogic.Implementations;
using Acro.BusinessLogic.Interfaces;
using Acro.BusinessLogic.MapperProfiles;
using Acro.BusinessLogic.Validators;
using Acro.Data.Implementations;
using Acro.Data.Interfaces;
using Acro.Data.StoredProcs;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Acro.BusinessLogic
{
	public static class AcroServiceCollectionExtensions
	{
		public static void AddAcroServices(this IServiceCollection services)
		{
			services.AddAutomapperProfiles();

			services.AddScoped<IValidator<CreateProductDto>, CreateProductValidator>();
			services.AddScoped<IValidator<UpdateProductDto>, UpdateProductValidator>();

			services.AddScoped<IProductBusinessLogic, ProductBusinessLogic>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<StoredProcWrapper>();

			// todo AddInThisAssembly
			//services.AddFluentValidatorsInAsseblyContaining<SignUpFreelancerDto>();

			//services.AddScoped<ISignupFreelancerValidator, SignupFreelancerValidator>();

		}

		private static void AddAutomapperProfiles(this IServiceCollection services)
		{
			Mapper.Reset();
			services.AddAutoMapper(typeof(ProductProfile));
		}
	}
}
