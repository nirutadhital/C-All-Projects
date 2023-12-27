using jwtDb.Models;

namespace jwtDb.Repository
{
    public interface IRepository
    {
        public Task<User> register(User user);
        public Task<User> login(string Username);
    }
}
