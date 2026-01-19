using System.Windows;
using WpfAppTest.Presentation.Menu.ViewModels;

namespace WpfAppTest.Presentation.Menu.Views;

/// <summary>
/// Interaction logic for MainMenuView.xaml
/// </summary>
public partial class MainMenuView : Window
{
    public MainMenuView(MainMenuViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
}
