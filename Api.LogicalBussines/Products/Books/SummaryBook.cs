using Api.LogicalBussines.Interfaces;

namespace Api.LogicalBussines
{
    public class SummaryBook : ISummaryBook, IProduct
    {
        public string[] Related {get; set;}
        public double Price {get; set;}
        public string Title {get; set;}
        public string[] Terms {get; set;}
        public string Link { get; set; }
        public long Id { get; set; }
    }
}
