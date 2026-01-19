using WpfAppTest.Domain.Users.Model;

namespace WpfAppTest.Domain.Users.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user, CancellationToken cancellationToken = default);

    Task<IList<User>> GetAllAsync(CancellationToken cancellationToken = default);
}
