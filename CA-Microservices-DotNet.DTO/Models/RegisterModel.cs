﻿
namespace CA_Microservices_DotNet.Common.Models;

public class RegisterModel
{
    public required string Email { get; set; }

    public required string Password { get; set; }
}
