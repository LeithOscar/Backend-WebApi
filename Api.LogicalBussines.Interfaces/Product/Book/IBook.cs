namespace Api.LogicalBussines.Interfaces
{
    public interface IBook : ISummaryBook, ILink, IProduct
    {

        string Image { get;}

        string Author { get; set; }
    }
}
