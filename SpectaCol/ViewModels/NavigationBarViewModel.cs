using SpectaCol.Commands;
using SpectaCol.Services;
using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpectaCol.ViewModels
{
  public class NavigationBarViewModel : ViewModelBase
  {
    public ICommand NavigateHomeCommand { get; }
    public ICommand LogoutCommand { get; }
    public ICommand NavigateStreamsCommand { get; }
    public ICommand OpenSettings { get; }
    public ICommand NavigateConcreteColumnDesignModule { get; }

    public NavigationBarViewModel(
      INavigationService homeNavigationService, 
      INavigationService accountSelectionNavigationService, 
      INavigationService streamSelectionNavigationService,
      INavigationService concreteColumnNavigationService,
      AccountStore accountStore, 
      SettingsStore settingsStore)
    {
      NavigateHomeCommand = new NavigateCommand(homeNavigationService);
      LogoutCommand = new LogoutCommand(accountStore, accountSelectionNavigationService);
      NavigateStreamsCommand = new NavigateStreamsCommand(accountStore, streamSelectionNavigationService);
      NavigateConcreteColumnDesignModule = new NavigateCommand(concreteColumnNavigationService);
      OpenSettings = new ToggleDialogVisibilityCommand(settingsStore);
    }
  }
}
