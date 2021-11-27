
namespace API.Unit.Tests
{
    using API.Controllers;
    using Microsoft.Extensions.Logging;
    using NSubstitute;
    using System;
    using Xunit;


    public class BooksControllerTests
    {
        private  BooksController controller;
        private  ILogger<BooksController> logger;
        [Fact]
        public void Test1()
        {
            this.logger = Substitute.For<ILogger<BooksController>>();

            this.controller = new BooksController(this.logger);
        }
    }
}
