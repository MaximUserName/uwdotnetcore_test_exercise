using System;
using Acro.WebApi.Infrastructure.ExceptionHandling.Hanlders;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Acro.WebApi.Infrastructure.ExceptionHandling
{
	public static class ExceptionHandlerFactory
	{
		public static IExceptionHandler GetHandler(ExceptionContext context)
		{
			return GetHandler(context.HttpContext, context.Exception);
		}

		public static IExceptionHandler GetHandler(HttpContext httpContext, Exception exception)
		{
			var exceptionType = exception.GetType();
			switch (exceptionType.Name)
			{
				case nameof(ValidationException):
					return new ValidationExceptionHandler(httpContext, exception);
				
				case nameof(NotImplementedException):
					return new NotImplementedExceptionHandler(httpContext, exception);
				
				//case nameof(NotAuthorizedException):
				//	return new NotAuthorizedExceptionHanlder(httpContext, exception);
				default:
					return new DefaultExceptionHandler(httpContext, exception);
			}
		}


	}
}