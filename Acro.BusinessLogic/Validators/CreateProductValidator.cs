using Acro.BusinessLogic.Dto;
using FluentValidation;

namespace Acro.BusinessLogic.Validators
{
	public class CreateProductValidator : AbstractValidator<CreateProductDto>
	{
		public CreateProductValidator()
		{
			InitalizeRules();
		}

		private void InitalizeRules()
		{
			this.RuleFor(e => e.ProductName)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotEmpty()
				.NotNull();

			this.RuleFor(e => e.SupplierID)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.GreaterThan(0);

			this.RuleFor(e => e.CategoryID)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.GreaterThan(0);
		}
	}
}