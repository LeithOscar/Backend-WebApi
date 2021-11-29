namespace API.Controllers
{
    using Api.BussinesLogical.Interfaces;
    using Api.LogicalBussines;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Authorize]
    [Route("api/v{version:ApiVersion}")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly List<Book> data;
        
        //we must to IoC to initialize on contructor
        private Product<Book> book;
        private readonly BookMapper map;
        private readonly IBookValidationRules validations;

        public BooksController(ILogger<BooksController> logger, IBookValidationRules bookValidationRules)
        {
            _logger =logger ?? throw new ArgumentNullException(nameof(logger)); ;
            validations =bookValidationRules ?? throw new ArgumentNullException(nameof(bookValidationRules)); 
            map = new BookMapper();

            //simulate having data but must be a repository injected 
            this.data = new List<Book>()
            {
                new Book() { Id= 1, Title="To Kill a Mockingbird", Price=10.20, Related = new[] { "2" },  Terms= new[] { "Mockingbird" }, Author="Andrew" },
                new Book() { Id= 2, Title="Ulysses", Price=11.30, Related = new[] { "2" }, Terms= new[] { "Ulysses" } , Author="Jace"},
                new Book() { Id= 3, Title="The Great Gatsby", Price=12.20, Related = new[] { "2" }, Terms= new[] { "Gatsby" } , Author="Magda" },
                new Book() { Id= 4, Title="Little Women", Price=13.20, Related = new[] { "2" },  Terms= new[] { "Little" }, Author="Scott" },
                new Book() { Id= 5, Title="Pride and Prejudice", Price=14.20, Related = new[] { "2" }, Terms= new[] { "Prejudice" } , Author="Samanta" },
                new Book() { Id= 6, Title="In Cold Blood", Price=15.20, Related = new[] { "2" }, Terms= new[] { "Cold" } , Author="Rius" },
                new Book() { Id= 7, Title="Oliver Twist", Price=16.20, Related = new[] { "2" },  Terms= new[] { "Twist" } , Author="McDowell" },
                new Book() { Id= 8, Title="The Wind in the Willows", Price=17.20, Related = new[] { "2" },  Terms= new[] { "Willows" } , Author="James" },
                new Book() { Id= 9, Title="Homage to Catalonia", Price=17.20, Related = new[] { "2" }, Terms= new[] { "Homage" }, Author="Scoott feur" },
            };
            this.book = new Product<Book>(this.data);
            //must be injected
        }


        /// <summary>
        ///Retrieves a list of all items in the catalog.
        /// </summary>
        [HttpGet("items/{offset}/{count}")]
        [MapToApiVersion("1.0")]

        public async Task<JsonResult> Offset(int offset, int count)
        {


            var leftovers = this.book.Offset(offset, count);
            var resumes = this.map.MapTo(leftovers);
            return new JsonResult(resumes);
        }

        /// <summary>
        ///Retrieves the details for a specified item
        ///</summary>
        [HttpGet("items/{id}")]
        [MapToApiVersion("1.0")]

        public async Task<JsonResult> ById(long id)
        {

            var errors = this.validations.ValidateId(id);
            if (errors.Any())
            {
                throw new ArgumentException();
            }

            var has = this.book.GetById(id);
            if (has!= null)
            {
                return new JsonResult(has);
            }
            else {
                return new JsonResult("");
            }
        }
    }
}
