using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Vesuvius_MDT.Controllers;

[ApiController]
public class Security : Controller
{
    private IConfiguration _configuration;
    public Security(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [AllowAnonymous]
    [HttpPost("/security/createToken")]
    public ActionResult<string> createToken(Login login, string username, string password)
    {
        if (login.Username == username && login.Password == password)
        {
            string issuer = _configuration["Jwt:Issuer"] ?? throw new SecurityException("The Issuer key set in appsetting.json is invalid");
            string audience = _configuration["Jwt:Audience"] ?? throw new SecurityException("The audience key set in appsetting.json is invalid");
            var key = Encoding.ASCII.GetBytes
            (_configuration["Jwt:Key"] ?? throw new SecurityException("The key set in appsetting.json is invalid"));
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, login.Username),
                    new Claim(JwtRegisteredClaimNames.Email, login.Username),
                    new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            string? stringToken = tokenHandler.WriteToken(token);
            return Ok(stringToken);
        }
        return StatusCode(StatusCodes.Status401Unauthorized);
    }

    [AllowAnonymous]
    [HttpPost("/security/verifyToken")]
    public bool verifyToken(string token)
    {
        var validationParameters = new TokenValidationParameters()
        {
            IssuerSigningKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? throw new SecurityException("The key set in appsetting.json is invalid"))),
            ValidAudience = _configuration["Jwt:Audience"],
            ValidIssuer = _configuration["Jwt:Issuer"],
            ValidateLifetime = true,
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true
        };
        
        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken validatedToken = null;

        tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

        try
        {
            tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
        }
        catch(SecurityTokenException)
        {
            StatusCode(StatusCodes.Status401Unauthorized);
            return false; 
        }
        catch(Exception e)
        { 
            Console.WriteLine(e.ToString()); //something else happened
            StatusCode(StatusCodes.Status500InternalServerError);
            throw;
        }
        //... manual validations return false if anything untoward is discovered
        return validatedToken != null;
    }
}