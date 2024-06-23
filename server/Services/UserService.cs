using CreditApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace CreditApp.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {
        private List<User> _users = new List<User>
        {
            new User { Username = "admin", Password = "admin1234"}
        };

        public User Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);
            if (user == null)
                return null;

            return user;
        }
    }
}
