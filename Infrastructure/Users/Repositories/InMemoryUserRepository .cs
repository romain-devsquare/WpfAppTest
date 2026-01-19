using WpfAppTest.Domain.Users.Model;
using WpfAppTest.Domain.Users.Repositories;

namespace WpfAppTest.Infrastructure.Users.Repositories;

public class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users = new();

    public Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        _users.Add(user);
        return Task.CompletedTask;
    }

    public Task<IList<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult((IList<User>)[.. _users]);
    }
}
