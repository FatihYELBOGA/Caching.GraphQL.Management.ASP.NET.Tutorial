using cache_test.Models;

namespace cache_test.Repositories
{
    public class UserRepository : IUserRepository
    {

        private static readonly List<User> users = new()
        {
            new User() { 
                Id = 1,
                FirstName = "Fatih",
                LastName = "YELBOĞA",
                Age = 20,
            },
            new User() {
                Id = 1,
                FirstName = "Enes",
                LastName = "DEMİREL",
                Age = 25,
            },
            new User() {
                Id = 1,
                FirstName = "Osman",
                LastName = "ALTUNAY",
                Age = 30,
            },
            new User() {
                Id = 1,
                FirstName = "Emin",
                LastName = "KILINÇLI",
                Age = 40,
            }
        };

        public List<User> getAll()
        {
            return users;
        }

        public User create(User u)
        {
            users.Add(u);
            return u;
        }

    }
}
