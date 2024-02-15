using CA_Microservices_DotNet.Domain.Entities;

namespace CA_Microservices_DotNet.Domain.Interfaces.Repositories
{
    public interface IBookRepository
    {
        /// <summary>
        /// Gets a single Book by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Book?> GetBook(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets all the Books.
        /// </summary>
        /// <returns></returns>
        Task<List<Book>> GetAllBooks();
    }
}
