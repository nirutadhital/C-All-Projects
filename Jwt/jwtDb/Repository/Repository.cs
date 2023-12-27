using jwtDb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlTypes;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace jwtDb.Repository
{
    public class Repository : IRepository
        
    {
        User user=new User();
        private readonly DataContext _dataContext;
        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<User> login(string Username)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(x => x.Username == Username);
        }

        public async Task<User> register(User user)
        {
            //string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            var result = _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
            //throw new NotImplementedException();
        }
    }
}
