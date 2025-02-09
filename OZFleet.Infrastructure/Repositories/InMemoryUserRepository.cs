using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OZFleet.Core.Entities;
using OZFleet.Core.Interfaces;

namespace OZFleet.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public Task AddAsync(User user)
        {
            user.Id = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(user);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<User>> GetAllAsync() =>
            Task.FromResult<IEnumerable<User>>(_users);

        public Task<User> GetByIdAsync(int id) =>
            Task.FromResult(_users.FirstOrDefault(u => u.Id == id));

        public Task UpdateAsync(User user)
        {
            var existing = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existing != null)
            {
                existing.Name = user.Name;
                existing.Email = user.Email;
            }
            return Task.CompletedTask;
        }
    }
}
