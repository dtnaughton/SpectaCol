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

      var initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();

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

      services.AddTransient<AccountSelectionViewModel>(s => CreateAccountSelectionViewModel(s));
      services.AddTransient<HomeViewModel>(CreateHomeViewModel);
      services.AddTransient<StreamSelectionViewModel>(s => CreateStreamSelectionViewModel(s));
      services.AddTransient<NavigationBarViewModel>(CreateNavigationBarViewmodel);
      services.AddTransient<FooterViewModel>(s => CreateFooterViewModel(s));
      services.AddTransient<SettingsViewModel>(s => CreateSettingsViewModel(s));
      services.AddTransient<SpeckleLoginViewModel>(s => CreateSpeckleLoginViewModel(s));

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
      return new NavigationService<SpeckleLoginViewModel>(navigationStore, () => serviceProvider.GetRequiredService<SpeckleLoginViewModel>());
    }

    private INavigationService CreateAccountSelectionNavigationService(IServiceProvider serviceProvider)
    {
      var navigationStore = serviceProvider.GetRequiredService<NavigationStore>();
      var accountStore = serviceProvider.GetRequiredService<AccountStore>();
      var settingsStore = serviceProvider.GetRequiredService<SettingsStore>();
      return new NavigationService<AccountSelectionViewModel>(navigationStore, () => CreateAccountSelectionViewModel(serviceProvider));
    }

    private INavigationService CreateHomeViewModelService(IServiceProvider serviceProvider)
    {
      var navigationStore = serviceProvider.GetRequiredService<NavigationStore>();
      var settingsStore = serviceProvider.GetRequiredService<SettingsStore>();

      var homeService = serviceProvider.GetRequiredService<HomeViewModel>();
      var footerService = serviceProvider.GetRequiredService<FooterViewModel>();
      var navigationService = serviceProvider.GetRequiredService<NavigationBarViewModel>();
      var settingService = serviceProvider.GetRequiredService<SettingsViewModel>();

      return new LayoutNavigationService<HomeViewModel, ViewModelBase>(
        navigationStore,
        () => homeService,
        navigationService,
        footerService,
        () => settingService,
        settingsStore
        );
    }

    private INavigationService CreateStreamSelectionService(IServiceProvider serviceProvider)
    {
      var navigationStore = serviceProvider.GetRequiredService<NavigationStore>();
      var settingsStore = serviceProvider.GetRequiredService<SettingsStore>();

      return new LayoutNavigationService<StreamSelectionViewModel, ViewModelBase>(
        navigationStore,
        () => serviceProvider.GetRequiredService<StreamSelectionViewModel>(),
        serviceProvider.GetRequiredService<NavigationBarViewModel>(),
        serviceProvider.GetRequiredService<FooterViewModel>(),
        () => serviceProvider.GetRequiredService<SettingsViewModel>(),
        settingsStore
        );
    }

    private AccountSelectionViewModel CreateAccountSelectionViewModel(IServiceProvider serviceProvider)
    {
      return new AccountSelectionViewModel(CreateHomeViewModelService(serviceProvider), _serviceProvider.GetRequiredService<AccountStore>());
    }

    private NavigationBarViewModel CreateNavigationBarViewmodel(IServiceProvider serviceProvider)
    {
      var accountStore = serviceProvider.GetRequiredService<AccountStore>();
      var settingsStore = serviceProvider.GetRequiredService<SettingsStore>();

      return new NavigationBarViewModel(
        CreateHomeViewModelService(serviceProvider),
        CreateAccountSelectionNavigationService(serviceProvider),
        CreateStreamSelectionService(serviceProvider),
        accountStore,
        settingsStore);
    }

    private FooterViewModel CreateFooterViewModel(IServiceProvider serviceProvider)
    {
      return new FooterViewModel(_serviceProvider.GetRequiredService<AccountStore>());
    }

    private SettingsViewModel CreateSettingsViewModel(IServiceProvider serviceProvider)
    {
      return new SettingsViewModel(serviceProvider.GetRequiredService<SettingsStore>());
    }

    private StreamSelectionViewModel CreateStreamSelectionViewModel(IServiceProvider serviceProvider)
    {
      return new StreamSelectionViewModel(serviceProvider.GetRequiredService<AccountStore>());
    }

    private SpeckleLoginViewModel CreateSpeckleLoginViewModel(IServiceProvider serviceProvider)
    {
      return new SpeckleLoginViewModel(CreateAccountSelectionNavigationService(serviceProvider), serviceProvider.GetRequiredService<AccountStore>());
    }

    private HomeViewModel CreateHomeViewModel(IServiceProvider serviceProvider)
    {
      return new HomeViewModel();
    }
  }
}
