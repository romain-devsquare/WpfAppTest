using Devsquare.EasyCQRS.Interfaces;
using WpfAppTest.Domain.Users.Model;

namespace WpfAppTest.Application.Users.Queries.GetUsersList;

public record GetUsersListQuery() : IQuery<IEnumerable<User>>;
