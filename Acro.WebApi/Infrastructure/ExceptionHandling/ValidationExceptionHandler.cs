using System;
using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace Acro.WebApi.Infrastructure.ExceptionHandling
{
	public class ValidationExceptionHandler : DefaultExceptionHandler
	{
		public override void Handle()
		{
			var exception = this.Exception.GetInnermostException();

			var valEx = exception as ValidationException;
			if (valEx == null)
				return;
			var cont = new ErrorsContainerDto();
			foreach (var error in valEx.Errors)
			{
				cont.items.Add(new ErrorDto()
				{
					field = char.ToLowerInvariant(error.PropertyName[0]) + error.PropertyName.Substring(1),
					message = error.ErrorMessage
				});
			}
			var jsonResponse = JObject.FromObject(cont);

			this.WriteHttpResponse(HttpStatusCode.BadRequest, jsonResponse);
		}

		public ValidationExceptionHandler(HttpContext httpContext, Exception exception) : base(httpContext, exception)
		{
		}
	}
}