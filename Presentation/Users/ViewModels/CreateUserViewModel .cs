using Devsquare.EasyCQRS.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfAppTest.Application.Users.Commands.CreateUser;
using WpfAppTest.Presentation.Commands;

namespace WpfAppTest.Presentation.Users.ViewModels;

public class CreateUserViewModel(ICommandDispatcher commandDispatcher) : INotifyPropertyChanged
{
    private string _name;
    private string _email;
    private string _statusMessage;

    public string StatusMessage
    {
        get => _statusMessage;
        set { _statusMessage = value; OnPropertyChanged(); }
    }

    public string Name
    {
        get => _name;
        set { _name = value; OnPropertyChanged(); }
    }

    public string Email
    {
        get => _email;
        set { _email = value; OnPropertyChanged(); }
    }

    public System.Windows.Input.ICommand CreateUserCommand => new RelayCommand(async _ => await CreateUserAsync());

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private async Task CreateUserAsync()
    {
        try
        {
            StatusMessage = string.Empty;

            var request = new CreateUserCommand(Name, Email);
            await commandDispatcher.SendAsync(request);

            StatusMessage = $"User created: {Name} ({Email})";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }
}
