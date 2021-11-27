namespace Api.LogicalBussines
{
    using Api.LogicalBussines.Interfaces;

    public class Book: IBook, IProduct
    {
        public long Id { get; set; }
        public string[] Related { get; set; }
        public double Price { get; set; }
        public string Link { get { return $"/api/v1/items/{Id}"; } }
        public string Title { get; set; }
        public string[] Terms { get; set; }
        public string Image { get { return $"http://test.com/images/{Id}"; } }
        public string Author { get; set; }
    }

}
