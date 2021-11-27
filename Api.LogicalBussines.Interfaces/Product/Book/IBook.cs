namespace Api.LogicalBussines.Interfaces
{
    public interface IBook : IResumeBook, ILinkBook, IProduct
    {

        string Image { get;}

        string Author { get; set; }
    }
}
