using cache_test.Models;
using cache_test.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace cache_test.GraphQL
{
    public class UserQuery
    {

        private readonly string users_key = "users";

        private IUserRepository _userRepository;
        private IMemoryCache _memoryCache;

        public UserQuery(IUserRepository userRepository, IMemoryCache memoryCache)
        {
            _userRepository = userRepository;
            _memoryCache = memoryCache;
        }

        public List<User> getAll() 
        {
            List<User> cache_users;
            if(!_memoryCache.TryGetValue(users_key, out cache_users))
            {
                cache_users = new List<User>();
                // cache_users = _userRepository.getAll();
                foreach(User u in _userRepository.getAll())
                    cache_users.Add(u);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(300))
                    .SetPriority(CacheItemPriority.Normal);

                _memoryCache.Set(users_key, cache_users, cacheEntryOptions);
            }

            return cache_users;
        }

    }

}
