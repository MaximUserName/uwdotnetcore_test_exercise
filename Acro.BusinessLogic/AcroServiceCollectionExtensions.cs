using System;
using Acro.BusinessLogic.Implementations;
using Acro.BusinessLogic.Interfaces;
using Acro.BusinessLogic.MapperProfiles;
using Acro.Data.Implementations;
using Acro.Data.Interfaces;
using Acro.Data.StoredProcs;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Acro.BusinessLogic
{
	public static class AcroServiceCollectionExtensions
	{
		public static void AddAcroServices(this IServiceCollection services)
		{
			services.AddAutomapperProfiles();

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
