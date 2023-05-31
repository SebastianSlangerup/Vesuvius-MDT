using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Vesuvius_MDT.Controllers;

[ApiController]
public class Security : Controller
{
    private IConfiguration _configuration;
    private readonly UnitOfWork _unitOfWork;
    public Security(IConfiguration configuration,DataContext context)
    {
        _unitOfWork = new UnitOfWork(context);
        _configuration = configuration;
    }

    [AllowAnonymous]
    [HttpPost("/security/createToken")]
    public ActionResult<string> createToken(string username, string password)
    {
        var user = _unitOfWork.LoginRepository.Find(user => user.Username == username && user.Password == password).First();
        if (user != null)
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
                    new Claim(JwtRegisteredClaimNames.Sub, username),
                    new Claim(JwtRegisteredClaimNames.Email, username),
                    new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            if (verifyToken(tokenHandler.WriteToken(token)) == true)
            {
                var jwtToken = tokenHandler.WriteToken(token);
                string? stringToken = tokenHandler.WriteToken(token);
                return Ok(stringToken);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);

        }
        return StatusCode(StatusCodes.Status401Unauthorized);
    }

    [AllowAnonymous]
    [HttpPost("/security/GenerateRefreshToken")]
    public ActionResult<string> GenerateRefreshToken(string token,string username, string password)
    {
        if (verifyToken(token) == true)
        {
            return Ok(createToken(username, password));
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
            Console.WriteLine(e.ToString());
            StatusCode(StatusCodes.Status500InternalServerError);
            throw;
        }
        return validatedToken != null;
    }
}