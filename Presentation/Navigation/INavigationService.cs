namespace WpfAppTest.Presentation.Navigation;

public interface INavigationService
{
    object? CurrentViewModel { get; }
    event Action? CurrentViewModelChanged;
    void NavigateTo<TViewModel>() where TViewModel : class;
}
