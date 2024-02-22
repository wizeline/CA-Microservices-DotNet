namespace CA_Microservices_DotNet.Common.Models;

public class ReviewModel
{
    public required string? Description { get; set; }

    public required double Stars { get; set; }

    public int BookId { get; set; }
}
