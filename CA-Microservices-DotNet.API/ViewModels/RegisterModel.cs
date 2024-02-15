using System.ComponentModel.DataAnnotations;

namespace CA_Microservices_DotNet.API.ViewModels;

public class RegisterModel
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
