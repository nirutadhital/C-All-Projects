﻿using JWTDemo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();

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
            if (user.Username != request.Username)
            {
                return BadRequest("Use not Found");
            }
            if(!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("Wrong Password");
            }
            return Ok(user);
        }
    }
}
