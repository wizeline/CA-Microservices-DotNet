﻿
namespace CA_Microservices_DotNet.Common.Models;

public class LoginModel
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}