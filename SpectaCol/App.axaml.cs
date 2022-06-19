using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using SpectaCol.Services;
using SpectaCol.Stores;
using SpectaCol.ViewModels;
using SpectaCol.Views;
using System;

namespace SpectaCol
{
  public partial class App : Application
  {
    private ServiceProvider _serviceProvider;

    public override void Initialize()
    {
      AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
      RegisterServices();

      var initialNavigationService = CreateSpeckleLoginNavigationService(_serviceProvider);

      initialNavigationService.Navigate();

      if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
      {
        desktop.MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
      }

      base.OnFrameworkInitializationCompleted();
    }

    private void RegisterServices()
    {
      var services = new ServiceCollection();

      services.AddSingleton<NavigationStore>();
      services.AddSingleton<AccountStore>();
      services.AddSingleton<SettingsStore>();

      services.AddSingleton<INavigationService>(s => CreateSpeckleLoginNavigationService(s));

      services.AddSingleton<MainWindowViewModel>();
      services.AddSingleton<MainWindow>(s => new MainWindow()
      {
        DataContext = s.GetRequiredService<MainWindowViewModel>()
      });

      _serviceProvider = services.BuildServiceProvider();
    }

    private INavigationService CreateSpeckleLoginNavigationService(IServiceProvider serviceProvider)
    {
      var navigationStore = serviceProvider.GetRequiredService<NavigationStore>();
      var accountStore = serviceProvider.GetRequiredService<AccountStore>();
      var settingsStore = serviceProvider.GetRequiredService<SettingsStore>();
      return new NavigationService<SpeckleLoginViewModel>(navigationStore, () => new SpeckleLoginViewModel(navigationStore, accountStore, settingsStore));
    }
  }
}
