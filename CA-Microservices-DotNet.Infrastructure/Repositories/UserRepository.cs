using CA_Microservices_DotNet.Domain.Entities;
using CA_Microservices_DotNet.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

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
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Rebeca",
                    LastName = "Lozano",
                    SecondLastName = "",
                    Email ="rebeca.lozano@email.com",
                    Phone = "8119632587"
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Karla",
                    LastName = "Melendez",
                    SecondLastName = "Rios",
                    Email ="karla.melendez@email.com",
                    Phone = "8117412589"
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
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
            return _dbContext.Users.ToListAsync();
        }

        /// <inheritdoc/>
        public Task<User?> GetUser(string id)
        {
            return _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
