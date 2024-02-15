namespace CA_Microservices_DotNet.Domain.Entities;

public class Book
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    public string Author { get; set; } = "";

}
