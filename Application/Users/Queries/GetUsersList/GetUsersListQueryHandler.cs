using Devsquare.EasyCQRS.Interfaces;
using WpfAppTest.Domain.Users.Model;
using WpfAppTest.Domain.Users.Repositories;

namespace WpfAppTest.Application.Users.Queries.GetUsersList;

public class GetUsersListQueryHandler(IUserRepository userRepository) : IQueryHandler<GetUsersListQuery, IEnumerable<User>>
{
    public async Task<IEnumerable<User>> HandleAsync(GetUsersListQuery query, CancellationToken cancellationToken = default)
    {
        return await userRepository.GetAllAsync(cancellationToken);
    }
}
