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

    public NavigationBarViewModel(AccountStore accountStore, NavigationStore navigationStore, SettingsStore settingsStore)
    {
      NavigateHomeCommand = new NavigateCommand(new LayoutNavigationService<HomeViewModel, ViewModelBase>(navigationStore, () => new HomeViewModel(), this, new FooterViewModel(accountStore), () => new SettingsViewModel(settingsStore), settingsStore));
      LogoutCommand = new LogoutCommand(accountStore, new NavigationService<AccountSelectionViewModel>(navigationStore, () => new AccountSelectionViewModel(navigationStore, accountStore, settingsStore)));
      NavigateStreamsCommand = new NavigateStreamsCommand(accountStore, new LayoutNavigationService<StreamSelectionViewModel, ViewModelBase>(navigationStore, () => new StreamSelectionViewModel(accountStore), this, new FooterViewModel(accountStore), () => new SettingsViewModel(settingsStore), settingsStore));
      OpenSettings = new ToggleDialogVisibilityCommand(settingsStore);
    }
  }
}
