using Api.LogicalBussines.Interfaces;
using Api.LogicalBussines.Products.Books;
using System.Collections.Generic;

namespace Api.LogicalBussines.Mappers
{
    public class BookMapper
    {


        public List<ResumeBook> MapTo(List<Book> books) 
        {
            var resumeList = new List<ResumeBook>();
            books.ForEach(book =>
            {
                var resume = new ResumeBook()
                {
                    Id=book.Id,
                    Link = book.Link,
                    Price = book.Price,
                    Related=book.Related,
                    Terms=book.Terms,
                    Title=book.Title

                };

                resumeList.Add(resume);
            });


            return resumeList;

            
        }
    }
}
