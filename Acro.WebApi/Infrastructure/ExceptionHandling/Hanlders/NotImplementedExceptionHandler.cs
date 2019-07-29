using System;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace Acro.WebApi.Infrastructure.ExceptionHandling.Hanlders
{
	public class NotImplementedExceptionHandler : DefaultExceptionHandler
	{
		protected override int GetStatusCode()
		{
			return (int)HttpStatusCode.NotImplemented;
		}

		public NotImplementedExceptionHandler(HttpContext httpContext, Exception exception) : base(httpContext, exception)
		{
		}
	}
}