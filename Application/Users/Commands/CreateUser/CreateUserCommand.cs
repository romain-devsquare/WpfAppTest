using Devsquare.EasyCQRS.Interfaces;

namespace WpfAppTest.Application.Users.Commands.CreateUser;

public record CreateUserCommand(string Name, string Email) : ICommand;
