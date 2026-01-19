using Devsquare.EasyCQRS.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WpfAppTest.Domain.Users.Repositories;
using WpfAppTest.Infrastructure.Users.Repositories;
using WpfAppTest.Presentation.Menu.ViewModels;
using WpfAppTest.Presentation.Menu.Views;
using WpfAppTest.Presentation.Navigation;
using WpfAppTest.Presentation.Users.ViewModels;
using WpfAppTest.Presentation.Users.Views;

namespace WpfAppTest;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : System.Windows.Application
{
    private IHost _appHost;

    public App()
    {
        InitializeComponent();
        _appHost = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                // Domain / Infra
                services.AddSingleton<IUserRepository, InMemoryUserRepository>();

                services.AddEasyCQRS(Application.AssemblyReference.Assembly);

                // Navigation
                services.AddSingleton<INavigationService, NavigationService>();

                // ViewModels
                services.AddTransient<CreateUserViewModel>();
                services.AddTransient<ListUsersViewModel>();
                services.AddTransient<MainMenuViewModel>();

                // Views
                services.AddTransient<CreateUserView>();
                services.AddTransient<ListUsersView>();
                services.AddTransient<MainMenuView>();
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await _appHost.StartAsync();

        var mainWindow = _appHost.Services.GetRequiredService<MainMenuView>();
        mainWindow.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await _appHost.StopAsync();
        _appHost.Dispose();
        base.OnExit(e);
    }
}
