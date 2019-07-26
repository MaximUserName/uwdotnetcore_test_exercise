using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Acro.WebApi.Infrastructure
{

	/// <summary>
	/// Swagger API documentation components start-up configuration
	/// </summary>
	public static class MvcBuilderExtensions
	{
		/// <summary>
		/// Configures the service.
		/// </summary>
		/// <param name="services">The services.</param>
		public static IMvcBuilder AddMvcFiltersAndOptions(this IServiceCollection services)
		{
			return services.AddMvc()
					.AddJsonOptions(options =>
					{
						options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
						options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
					})
				;
		}
	}
}
