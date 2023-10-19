using cache_test.Models;
using cache_test.Repositories;

namespace cache_test.GraphQL
{
    public class UserMutation
    {

        private IUserRepository _userRepository;

        public UserMutation(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User create(User u)
        {
            return _userRepository.create(u);
        }

    }

}
