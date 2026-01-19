using Microsoft.Extensions.DependencyInjection;

namespace WpfAppTest.Presentation.Navigation;

public sealed class NavigationService : INavigationService
{
    private readonly IServiceProvider _serviceProvider;

    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public object? CurrentViewModel { get; private set; }

    public event Action? CurrentViewModelChanged;

    public void NavigateTo<TViewModel>() where TViewModel : class
    {
        CurrentViewModel = _serviceProvider.GetRequiredService<TViewModel>();
        CurrentViewModelChanged?.Invoke();
    }
}
