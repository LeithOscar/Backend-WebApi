
namespace Api.LogicalBussines.Mappers
{
    using Api.LogicalBussines;
    using System.Collections.Generic;


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
