using API_AuthExcercise.API.Models;

namespace API_AuthExcercise.API.Services
{
    public class UserService
    {
        private List<User> _users;

        public UserService()
        {
            _users = new List<User>
                {
                    new User() { Username = "ex@yahoo.com", Password = "Test123" },
                    new User() { Username = "hello@gmail.com", Password = "Hellohello" }
                };
        }
    }
}
