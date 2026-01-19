using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfAppTest.Presentation.Commands;
using WpfAppTest.Presentation.Navigation;
using WpfAppTest.Presentation.Users.ViewModels;

namespace WpfAppTest.Presentation.Menu.ViewModels;

public class MainMenuViewModel : INotifyPropertyChanged
{
    private readonly INavigationService _navigationService;

    public object? CurrentViewModel => _navigationService.CurrentViewModel;

    public ICommand ShowCreateUserCommand { get; }
    public ICommand ShowUsersListCommand { get; }

    public MainMenuViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        _navigationService.CurrentViewModelChanged += OnCurrentViewModelChanged;

        ShowCreateUserCommand = new RelayCommand(_ => ShowCreate());
        ShowUsersListCommand = new RelayCommand(_ => ShowList());

        _ = ShowList();
    }

    private Task ShowCreate()
    {
        _navigationService.NavigateTo<CreateUserViewModel>();
        return Task.CompletedTask;
    }

    private Task ShowList()
    {
        _navigationService.NavigateTo<ListUsersViewModel>();
        return Task.CompletedTask;
    }

    private void OnCurrentViewModelChanged() => OnPropertyChanged(nameof(CurrentViewModel));

    public event PropertyChangedEventHandler? PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
