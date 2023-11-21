namespace CA_Microservices_DotNet.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
