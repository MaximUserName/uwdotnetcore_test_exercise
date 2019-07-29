using System.Collections.Generic;

namespace Acro.WebApi.Infrastructure.ExceptionHandling
{
	/// <summary>The errors container</summary>
	public class ErrorsContainerDto
	{
		/// <summary>The _items</summary>
		private readonly List<ErrorDto> _items = new List<ErrorDto>();

		/// <summary>Gets or sets the errors.</summary>
		public List<ErrorDto> items
		{
			get { return this._items; }
			set { this._items.Clear(); this._items.AddRange(value ?? new List<ErrorDto>()); }
		}

		public static ErrorsContainerDto CreateGlobal(string message)
		{
			return new ErrorsContainerDto()
			{
				items = new List<ErrorDto>()
				{
					new ErrorDto(){field = "global", message = message }
				}
			};
		}

		public static ErrorsContainerDto Failed()
		{
			return CreateGlobal("Failed");
		}
	}
}