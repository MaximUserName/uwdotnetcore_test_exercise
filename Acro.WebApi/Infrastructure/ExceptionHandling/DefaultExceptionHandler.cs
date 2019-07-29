using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace Acro.WebApi.Infrastructure.ExceptionHandling
{
	public class DefaultExceptionHandler : IExceptionHandler
	{
		public DefaultExceptionHandler(HttpContext httpContext, Exception exception)
		{
			this.HttpContext = httpContext;
			this.Exception = exception;
		}

		protected HttpContext HttpContext { get; }

		protected Exception Exception { get; }

		protected virtual int GetStatusCode()
		{
			return (int)HttpStatusCode.InternalServerError;
		}

		protected virtual ErrorsContainerDto CreateErrorResponse()
		{
			var message = this.Exception.Message;
			return ErrorsContainerDto.CreateGlobal(message);
		}

		public virtual void Handle()
		{
			var errorContainer = this.CreateErrorResponse();
			var jsonResponse = JObject.FromObject(errorContainer);
			var statusCode = this.GetStatusCode();
			this.WriteHttpResponse((HttpStatusCode)statusCode, jsonResponse);
		}

		protected void WriteHttpResponse(HttpStatusCode statusCode, JObject jsonResponse)
		{
			var httpResponse = this.HttpContext.Response;
			httpResponse.Clear();
			httpResponse.StatusCode = (int)statusCode;
			httpResponse.ContentType = "application/json";
			Task.WaitAll(httpResponse.WriteAsync(jsonResponse.ToString()));
		}
	}
}