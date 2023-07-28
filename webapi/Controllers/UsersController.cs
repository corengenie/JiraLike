using Dal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using webapi.RequestModels;
using Dal;
using webapi.Enums;
using Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{

    private readonly ILogger<UsersController> _logger;
    private readonly ApplicationDbContext _context;

    public UsersController(ILogger<UsersController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpOptions]
    public IActionResult PreflightRoute()
    {
        return NoContent();
    }

    [HttpPost]
    public IActionResult Login([FromBody] UserLoginRequest request)
    {
        if (request.Login is null || request.Password is null)
        {
            return BadRequest(new { errorText = "Username or password is null." });
        }
        var identity = GetIdentity(request.Login, request.Password);
        if (identity == default)
        {
            return BadRequest(new { errorText = "Invalid username or password." });
        }

        var now = DateTime.UtcNow;
        var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        var response = new
        {
            access_token = encodedJwt,
            login = identity.Name,
            username = identity.Claims.First(c => c.Type == "username").Value
        };

        return new JsonResult(response);
    }

    private ClaimsIdentity? GetIdentity(string username, string password)
    {
        User? user = _context.Users.FirstOrDefault(x => x.Login == username && x.Password == password);
        if (user != null)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, ((UserRole)user.Role).ToString()),
                    new Claim("username", user.Name)
                };
            var claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }

        return null;
    }
}
