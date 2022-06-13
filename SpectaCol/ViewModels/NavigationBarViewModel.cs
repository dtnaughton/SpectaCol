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

    public NavigationBarViewModel(AccountStore accountStore, NavigationStore navigationStore)
    {
      LogoutCommand = new LogoutCommand(accountStore, new NavigationService<AccountSelectionViewModel>(navigationStore, () => new AccountSelectionViewModel(navigationStore, accountStore)));
    }
  }
}
