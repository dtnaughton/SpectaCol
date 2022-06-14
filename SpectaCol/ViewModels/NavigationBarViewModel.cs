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

    public NavigationBarViewModel(AccountStore accountStore, NavigationStore navigationStore)
    {
      NavigateHomeCommand = new NavigateCommand(new LayoutNavigationService<HomeViewModel>(navigationStore, () => new HomeViewModel(), this, new FooterViewModel(accountStore)));
      LogoutCommand = new LogoutCommand(accountStore, new NavigationService<AccountSelectionViewModel>(navigationStore, () => new AccountSelectionViewModel(navigationStore, accountStore)));
      NavigateStreamsCommand = new NavigateStreamsCommand(accountStore, new LayoutNavigationService<StreamSelectionViewModel>(navigationStore, () => new StreamSelectionViewModel(accountStore), this, new FooterViewModel(accountStore)));
    }
  }
}
