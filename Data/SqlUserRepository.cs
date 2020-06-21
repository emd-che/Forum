using System.Collections.Generic;
using System.Linq;
using Forum.Model;

namespace Forum.Data
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly ForumContext _context;

        public SqlUserRepository(ForumContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}