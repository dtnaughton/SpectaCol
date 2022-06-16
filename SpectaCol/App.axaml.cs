using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using SpectaCol.Stores;
using SpectaCol.ViewModels;
using SpectaCol.Views;

namespace SpectaCol
{
  public partial class App : Application
  {
    public override void Initialize()
    {
      AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {

      var navigationStore = new NavigationStore();
      var accountStore = new AccountStore();
      var settingsStore = new SettingsStore();
      navigationStore.CurrentViewModel = new SpeckleLoginViewModel(navigationStore, accountStore, settingsStore);

      if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
      {
        desktop.MainWindow = new MainWindow
        {
          DataContext = new MainWindowViewModel(navigationStore),
        };
      }

      base.OnFrameworkInitializationCompleted();
    }
  }
}
