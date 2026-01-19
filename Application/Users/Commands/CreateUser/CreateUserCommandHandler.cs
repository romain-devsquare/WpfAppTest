using Devsquare.EasyCQRS.Interfaces;
using WpfAppTest.Domain.Users.Model;
using WpfAppTest.Domain.Users.Repositories;

namespace WpfAppTest.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler(IUserRepository userRepository) : ICommandHandler<CreateUserCommand>
{
    public async Task HandleAsync(CreateUserCommand command, CancellationToken cancellationToken = default)
    {
        var user = new User(command.Name, command.Email);

        await userRepository.AddAsync(user, cancellationToken);
    }
}
