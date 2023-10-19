using cache_test.Models;

namespace cache_test.Repositories
{
    public interface IUserRepository
    {
        public List<User> getAll();
        public User create(User u);

    }
}
