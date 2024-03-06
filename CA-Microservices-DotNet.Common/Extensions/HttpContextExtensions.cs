using System.Security.Claims;

namespace CA_Microservices_DotNet.DTO.Extensions;

public static class HttpContextExtensions
{
    public static string? GetUserId(this ClaimsPrincipal user) =>
        user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
}