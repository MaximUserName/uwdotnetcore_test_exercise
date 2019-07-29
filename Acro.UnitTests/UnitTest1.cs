using System;
using Acro.BusinessLogic.Dto;
using Acro.BusinessLogic.Implementations;
using Acro.BusinessLogic.Validators;
using Acro.Data.Interfaces;
using Acro.WebApi.Controllers;
using AutoMapper;
using FluentValidation;
using Moq;
using NUnit.Framework;

namespace Acro.UnitTests
{
	[TestFixture]
    public class ProductBusinessLogicTests
    {
        [Test]
        public void ProductEmptyName_ShouldThrow()
        {
			
			// Arrange
			var sut = new ProductBusinessLogic(
				Mock.Of<IProductRepository>(),
				Mock.Of<IMapper>(),
				new CreateProductValidator(),
				Mock.Of<UpdateProductValidator>());

			// Act
			// Assert
			Assert.Throws<ValidationException>(() =>
			{
				sut.AddNew(new CreateProductDto()
				{
					ProductName = string.Empty
				});
			});
		}
    }
}
