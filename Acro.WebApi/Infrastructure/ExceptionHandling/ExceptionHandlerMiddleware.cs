using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Acro.WebApi.Infrastructure.ExceptionHandling
{
	/// <summary>
	/// Central error/exception handler Middleware
	/// </summary>
	public class ExceptionHandlerMiddleware
	{
		private readonly RequestDelegate _request;

		/// <summary>
		/// Initializes a new instance of the <see cref="ExceptionHandlerMiddleware"/> class.
		/// </summary>
		/// <param name="next">The next.</param>
		public ExceptionHandlerMiddleware(RequestDelegate next)
		{
			this._request = next;
		}

		/// <summary>
		/// Invokes the specified context.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <returns></returns>
		public async Task Invoke(HttpContext context,
			ILogger<ExceptionHandlerMiddleware> logger
			//, IExceptionConvertStrategy exceptionConvertStrategy
		)
		{
			try
			{
				await this._request(context);
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception);
				Console.WriteLine(exception.Message);
				//logger.LogError(exception.Message, exception);
				//if (exception.InnerException != null)
				//{
				//	logger.LogError(exception.InnerException.Message, exception.InnerException);
				//}
				await HandleExceptionAsync(context, exception);
			}
		}

		private static Task HandleExceptionAsync(HttpContext context, Exception exception)
		{

			var handler = ExceptionHandlerFactory.GetHandler(context, exception);
			handler.Handle();
			return Task.CompletedTask;
		}
	}
}