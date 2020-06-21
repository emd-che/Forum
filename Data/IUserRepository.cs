using System.Collections.Generic;
using Forum.Model;

namespace Forum.Data
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
    }
}