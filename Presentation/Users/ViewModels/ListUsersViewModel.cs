using Devsquare.EasyCQRS.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WpfAppTest.Application.Users.Queries.GetUsersList;
using WpfAppTest.Domain.Users.Model;

namespace WpfAppTest.Presentation.Users.ViewModels;

public class ListUsersViewModel : INotifyPropertyChanged
{
    private IQueryDispatcher _queryDispatcher;

    public ObservableCollection<User> Users { get; private set; } = new ObservableCollection<User>();

    public event PropertyChangedEventHandler? PropertyChanged;

    public ListUsersViewModel(IQueryDispatcher queryDispatcher)
    {
        _queryDispatcher = queryDispatcher;
        _ = LoadUsers();
    }

    private async Task LoadUsers()
    {
        var command = new GetUsersListQuery();
        var result = await _queryDispatcher.SendAsync(command);

        foreach (var user in result)
        {
            Users.Add(user);
        }
    }
}
