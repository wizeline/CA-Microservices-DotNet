//using CA_Microservices_DotNet.Common.Models;
//using CA_Microservices_DotNet.Domain.Entities;
//using Microsoft.AspNetCore.Authentication.BearerToken;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace CA_Microservices_DotNet.API.Controllers;

//[ApiController]
//[Route("api/[controller]")]
//public class RegisterController : Controller
//{
//    private readonly UserManager<User> _userManager;

//    public RegisterController(UserManager<User> userManager)
//    {
//        _userManager = userManager;
//    }

//    [HttpPost]
//    [AllowAnonymous]
//    public async Task<IActionResult> Register([FromBody] RegisterModel model)
//    {
//        if (ModelState.IsValid)
//        {
//            var user = new User()
//            {
//                Email = model.Email,
//                UserName = model.Email,
//                FirstName = "",
//                SecondLastName = "",
//                Phone = "",
//                LastName = ""
//            };

//            var registerResult = await _userManager.CreateAsync(user, model.Password);

//            return registerResult.Succeeded ? (ActionResult)Created("", "User has been registered") : 
//                BadRequest(new { Errors = registerResult.Errors });
//        }
//        else
//        {
//            return BadRequest(ModelState.ValidationState);
//        }
//    }

//    [HttpPost("login")]
//    public async Task<ActionResult<ClaimsPrincipal>> Login([FromBody] LoginModel model)
//    {
//        if (ModelState.IsValid)
//        {
//            var user = await _userManager.FindByNameAsync(model.Username);
//            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
//            {
//                // Generate JWT using user information (e.g., userId, username)
//                //var token = GenerateJwtToken(user);
//                var claims = GetClaimsPrincipal(user);
//                return Ok(claims);
//                //return Ok(new { token = token });
//            }
//            else
//            {
//                return Unauthorized();
//            }
//        }
//        else
//        {
//            return BadRequest(ModelState.ValidationState);
//        }
//    }


//    private static ClaimsPrincipal GetClaimsPrincipal(User user)
//    {
//        return new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>()
//                {
//                    new (ClaimTypes.NameIdentifier, user.Id),
//                    new (ClaimTypes.Name, user.UserName),
//                    new (ClaimTypes.Email, user.Email)
//                    // Add additional claims as needed
//                }, BearerTokenDefaults.AuthenticationScheme));
//    }

//    //private static string GenerateJwtToken(User user)
//    //{
//    //    // Configure JWT signing credentials
//    //    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("codeacceleratorsmicroservicesdotnet"));
//    //    var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

//    //    // Define token claims (e.g., userId, username, roles)
//    //    var claims = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>()
//    //    {
//    //        new (ClaimTypes.NameIdentifier, user.Id),
//    //        new (ClaimTypes.Name, user.UserName),
//    //        new (ClaimTypes.Email, user.Email)
//    //        // Add additional claims as needed
//    //    }, BearerTokenDefaults.AuthenticationScheme));

//    //    // Configure token lifetime and issuer
//    //    var tokenDescriptor = new SecurityTokenDescriptor
//    //    {
//    //        Subject = claims,
//    //        Expires = DateTime.UtcNow.AddHours(1), // Adjust expiration time as needed
//    //        SigningCredentials = credentials,
//    //        Issuer = "ca-microservices-dotnet" // Set your issuer name
//    //    };

//    //    // Create and serialize JWT token
//    //    var tokenHandler = new JwtSecurityTokenHandler();
//    //    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
//    //    return tokenHandler.WriteToken(securityToken);
//    //}
//}
