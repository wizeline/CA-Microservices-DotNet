using CA_Microservices_DotNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_Microservices_DotNet.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Gets a single User by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User> GetUser(int id);

        /// <summary>
        /// Gets all the Users.
        /// </summary>
        /// <returns></returns>
        Task<List<User>> GetAllUsers();
    }
}
