namespace Api.LogicalBussines.Interfaces
{
    public interface ISummaryBook :ILink
    {
        string[] Related { get; set; }

        double Price { get; set; }

        string Title { get; set; }

        string[] Terms { get; set; }
    }
}
