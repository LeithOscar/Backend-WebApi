
namespace Api.LogicalBussines
{

    using Api.LogicalBussines.Interfaces;
    using System.Collections.Generic;
    public class BookMapper 
    {
        public List<SummaryBook> MapTo(List<Book> books) 
        {
            var resumeList = new List<SummaryBook>();
            books.ForEach(book =>
            {
                var resume = new SummaryBook()
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
