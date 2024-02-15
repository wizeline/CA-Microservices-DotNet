using CA_Microservices_DotNet.Domain.Entities;

namespace CA_Microservices_DotNet.Domain.Interfaces.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Gets a single User by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User> GetUser(string id);

        /// <summary>
        /// Gets all the Users.
        /// </summary>
        /// <returns></returns>
        Task<List<User>> GetAllUsers();
    }
}
