using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_Microservices_DotNet.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string SecondLastName { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string Phone { get; set; } = default!;
    }
}
