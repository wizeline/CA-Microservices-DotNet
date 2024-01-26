using CA_Microservices_DotNet.Domain.Entities;
using CA_Microservices_DotNet.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_Microservices_DotNet.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    { 
        private readonly List<User> _users = [];
        private readonly MyDbContext _dbContext;

        public UserRepository(MyDbContext dbContext)
        {
            _users = new List<User>()
            {
                new()
                {
                    Id = 1,
                    FirstName = "Rebeca",
                    LastName = "Lozano",
                    SecondLastName = "",
                    Email ="rebeca.lozano@email.com",
                    Phone = "8119632587"
                },
                new()
                {
                    Id = 2,
                    FirstName = "Karla",
                    LastName = "Melendez",
                    SecondLastName = "Rios",
                    Email ="karla.melendez@email.com",
                    Phone = "8117412589"
                },
                new()
                {
                    FirstName = "Luis",
                    LastName = "Hernandez",
                    SecondLastName = "Perez",
                    Email ="luis.hernandez@email.com",
                    Phone = "8113698521"
                }
            };
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public Task<List<User>> GetAllUsers()
        {
            return Task.FromResult(_users);
        }

        /// <inheritdoc/>
        public Task<User> GetUser(int id)
        {
            var user = _users.Find(b => b.Id == id)
                ?? new User();

            return Task.FromResult(user);
        }
    }
}
