
namespace API.Unit.Tests
{
    using Api.BussinesLogical.Interfaces;
    using Api.LogicalBussines;
    using API.Controllers;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using NSubstitute;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text.Json;
    using Xunit;


    public class BooksControllerTests
    {
        private  BooksController controller;
        private  ILogger<BooksController> logger;
        private readonly IBookValidationRules bookValidationRules;
        public  BooksControllerTests()
        {
            this.logger = Substitute.For<ILogger<BooksController>>();
            this.bookValidationRules = Substitute.For<IBookValidationRules>();

            this.controller = new BooksController(this.logger, this.bookValidationRules);
        }


        [Fact]
        public async void Offset_Should_be_callToOffset_succed()
        {

            var nextIdExpected = 2; 
            //stubs
            //should be  as mapper and reposiotry

            //action
            JsonResult rsp = await this.controller.Offset(1, 1).ConfigureAwait(false);
            var items = this.ExtractJsonResultFromList(rsp);
            // assert

            //we have to verify to call mock method
            rsp.Should().NotBeNull();
            items.Should().HaveCount(1);
            items.FirstOrDefault().Id.Should().Be(nextIdExpected); 

        }

        [Fact]
        public async void Offset_CountBiggest_thanData_returnAllExistents()
        {
            //stubs
            //should be  as mapper and reposiotry

            //action
            JsonResult rsp = await this.controller.Offset(1, 100).ConfigureAwait(false);
            var items = this.ExtractJsonResultFromList(rsp);
            // assert
            rsp.Should().NotBeNull();
            items.Should().NotBeEmpty(); 
        }


        [Fact]
        public async void GetById_ShoulBe_ReturnOne()
        {
            //stubs
            this.bookValidationRules.ValidateId(Arg.Any<long>()).Returns(new List<ValidationResult>());

            //action
            JsonResult rsp = await this.controller.ById(1).ConfigureAwait(false);
            var item = this.ExtractJsonResult(rsp);

            // assert
            item.Should().NotBeNull();
            item.Id.Should().Be(1);    
        }

        [Fact]
        public async void GetById_NotFound_Succed()
        {
            //stubs
            this.bookValidationRules.ValidateId(Arg.Any<long>()).Returns(new List<ValidationResult>());

            //action
            JsonResult rsp = await this.controller.ById(22).ConfigureAwait(false);

            // assert
            rsp.Value.Should().Be(string.Empty);
        }

        private List<Book> ExtractJsonResultFromList(JsonResult rsp)
        {
            var jsonString = JsonSerializer.Serialize(rsp.Value);
            var deserialied = JsonSerializer.Deserialize<List<Book>>(jsonString);
            return deserialied;
        }
        private Book ExtractJsonResult(JsonResult rsp)
        {
            var jsonString = JsonSerializer.Serialize(rsp.Value);
            var deserialied = JsonSerializer.Deserialize<Book>(jsonString);
            return deserialied;
        }
    }
}
