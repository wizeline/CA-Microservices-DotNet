
namespace CA_Microservices_DotNet.Domain.Entities;

public class Review
{
    public int Id { get; set; }

    public double Stars { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? Description { get; set; }

    public int BookId { get; set; } = default!;
    public Book Book { get; set; } = default!;

    /// <summary>
    /// Owner of the Review
    /// </summary>
    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;
}
