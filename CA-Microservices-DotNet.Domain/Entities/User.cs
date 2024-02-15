﻿using Microsoft.AspNetCore.Identity;

namespace CA_Microservices_DotNet.Domain.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string SecondLastName { get; set; } = default!;

    public string Phone { get; set; } = default!;
}
