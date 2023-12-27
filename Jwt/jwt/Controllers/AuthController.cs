using JWTDemo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        //IConfiguration is injected because it is used to access configuration data from appsettings.json
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        { 
            _configuration = configuration;

        }

        [HttpPost("register")]
        public ActionResult<User> Register (UserDto request)
        {
            string passwordHash=BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.Username = request.Username;
            user.PasswordHash = passwordHash;
            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<User> Login(UserDto request)
        {
            //user le register gareko username ra login garna ko lagi request gareko username different xa vane
            if (user.Username != request.Username)
            {
                return BadRequest("User not Found");
            }
            //user le register gareko password ra login garna ko lagi request gareko password different xa vane
            if(!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("Wrong Password");
            }
            //if correct username and password xa vane
            string token = CreateToken(user);
            return Ok(token);
        }
        //this method generate token for the given user
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };
            //Retrieve the secret key used for signing the token from configuration 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));


            //Create signing credentials using the symmetric key and HMACSHA512 signature algorithm
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            //first of all we need to
            //give one token in appsettings.json
            //file and the other secret token is created when the api run and user logged in

            //Create a new JWT with specified claims, expiration time, and signing credentials
            var token =new JwtSecurityToken(
                claims:claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials:creds
                );
            //used to serialize the JWT (JwtSecurityToken)
            //into a string representation using WriteToken()
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;

        }
    }
}
