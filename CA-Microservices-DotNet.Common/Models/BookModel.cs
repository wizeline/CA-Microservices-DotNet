namespace CA_Microservices_DotNet.Common.Models;

public class BookModel
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    public string Author { get; set; } = "";

    public double Rating { get; set; }

    public IEnumerable<ReviewModel> Reviews { get; set; } = new List<ReviewModel>();
}