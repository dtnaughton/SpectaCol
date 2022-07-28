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
      services.AddSingleton<ObjectStore>();

      services.AddSingleton<INavigationService>(s => CreateSpeckleLoginNavigationService(s));

      services.AddTransient<AccountSelectionViewModel>(s => CreateAccountSelectionViewModel(s));
      services.AddTransient<HomeViewModel>(CreateHomeViewModel);
      services.AddTransient<StreamSelectionViewModel>(s => CreateStreamSelectionViewModel(s));
      services.AddTransient<NavigationBarViewModel>(CreateNavigationBarViewModel);
      services.AddTransient<FooterViewModel>(s => CreateFooterViewModel(s));
      services.AddTransient<SettingsViewModel>(s => CreateSettingsViewModel(s));
      services.AddTransient<SpeckleLoginViewModel>(s => CreateSpeckleLoginViewModel(s));
      services.AddTransient<ConcreteColumnDesignViewModel>(s => CreateConcreteColumnDesignModuleViewModel(s));
      services.AddTransient<TestViewModel>(_ => new TestViewModel());

      services.AddSingleton<MainWindowViewModel>();
      services.AddSingleton<MainWindow>(s => new MainWindow()
      {
        DataContext = s.GetRequiredService<MainWindowViewModel>()
      });

      _serviceProvider = services.BuildServiceProvider();
    }

    private INavigationService CreateSpeckleLoginNavigationService(IServiceProvider serviceProvider)
    {
      return new NavigationService<SpeckleLoginViewModel>(
        serviceProvider.GetRequiredService<NavigationStore>(), 
        () => serviceProvider.GetRequiredService<SpeckleLoginViewModel>());
    }

    private INavigationService CreateAccountSelectionNavigationService(IServiceProvider serviceProvider)
    {
      return new NavigationService<AccountSelectionViewModel>(
        serviceProvider.GetRequiredService<NavigationStore>(), 
        () => serviceProvider.GetRequiredService<AccountSelectionViewModel>());
    }

    private INavigationService CreateHomeViewModelService(IServiceProvider serviceProvider)
    {
      return new LayoutNavigationService<HomeViewModel, ViewModelBase>(
        serviceProvider.GetRequiredService<NavigationStore>(),
        () => serviceProvider.GetRequiredService<HomeViewModel>(),
        () => serviceProvider.GetRequiredService<NavigationBarViewModel>(),
        serviceProvider.GetRequiredService<FooterViewModel>(),
        () => serviceProvider.GetRequiredService<SettingsViewModel>());
    }

    private INavigationService CreateStreamSelectionService(IServiceProvider serviceProvider)
    {
      return new LayoutNavigationService<StreamSelectionViewModel, ViewModelBase>(
        serviceProvider.GetRequiredService<NavigationStore>(),
        () => serviceProvider.GetRequiredService<StreamSelectionViewModel>(),
        () => serviceProvider.GetRequiredService<NavigationBarViewModel>(),
        serviceProvider.GetRequiredService<FooterViewModel>(),
        () => serviceProvider.GetRequiredService<SettingsViewModel>());
    }

    private INavigationService CreateTestDialogNavigationService(IServiceProvider serviceProvider)
    {
      return new DialogNavigationService<TestViewModel>(
        serviceProvider.GetRequiredService<NavigationStore>(),
        () => serviceProvider.GetRequiredService<TestViewModel>());
    }

    private INavigationService CreateDialogNavigationService<T>(IServiceProvider serviceProvider) where T : ViewModelBase
    {
      return new DialogNavigationService<T>(
        serviceProvider.GetRequiredService<NavigationStore>(),
        () => serviceProvider.GetRequiredService<T>());
    }

    private INavigationService CreateConcreteColumnDesignModuleService(IServiceProvider serviceProvider)
    {
         return new LayoutNavigationService<ConcreteColumnDesignViewModel, ViewModelBase>(
        serviceProvider.GetRequiredService<NavigationStore>(),
        () => serviceProvider.GetRequiredService<ConcreteColumnDesignViewModel>(),
        () => serviceProvider.GetRequiredService<NavigationBarViewModel>(),
        serviceProvider.GetRequiredService<FooterViewModel>(),
        () => serviceProvider.GetRequiredService<SettingsViewModel>());
    }

    private AccountSelectionViewModel CreateAccountSelectionViewModel(IServiceProvider serviceProvider)
    {
      return new AccountSelectionViewModel(
        CreateHomeViewModelService(serviceProvider), 
        _serviceProvider.GetRequiredService<AccountStore>());
    }

    private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
    {
      return new NavigationBarViewModel(
        CreateHomeViewModelService(serviceProvider),
        CreateAccountSelectionNavigationService(serviceProvider),
        CreateStreamSelectionService(serviceProvider),
        CreateConcreteColumnDesignModuleService(serviceProvider),
        CreateDialogNavigationService<SettingsViewModel>(serviceProvider),
        serviceProvider.GetRequiredService<AccountStore>(),
        serviceProvider.GetRequiredService<NavigationStore>());
    }

    private FooterViewModel CreateFooterViewModel(IServiceProvider serviceProvider)
    {
      return new FooterViewModel(_serviceProvider.GetRequiredService<AccountStore>());
    }

    private SettingsViewModel CreateSettingsViewModel(IServiceProvider serviceProvider)
    {
      return new SettingsViewModel(serviceProvider.GetRequiredService<SettingsStore>(),
        serviceProvider.GetRequiredService<NavigationStore>());
    }

    private StreamSelectionViewModel CreateStreamSelectionViewModel(IServiceProvider serviceProvider)
    {
      return new StreamSelectionViewModel(serviceProvider.GetRequiredService<AccountStore>(), serviceProvider.GetRequiredService<ObjectStore>(), serviceProvider.GetRequiredService<SettingsStore>());
    }

    private ConcreteColumnDesignViewModel CreateConcreteColumnDesignModuleViewModel(IServiceProvider serviceProvider)
    {
      return new ConcreteColumnDesignViewModel(serviceProvider.GetRequiredService<ObjectStore>(), 
        serviceProvider.GetRequiredService<SettingsStore>(),
        serviceProvider.GetRequiredService<NavigationStore>(),
        CreateTestDialogNavigationService(serviceProvider));
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
