using Speckle.Core.Credentials;
using SpectaCol.Stores;
using SpectaCol.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Commands
{
  public class LoginSpeckleCommand : CommandBase
  {
    private readonly NavigationStore _navigationStore;

    public LoginSpeckleCommand(NavigationStore navigationStore)
    {
      _navigationStore = navigationStore;
    }

    public override void Execute(object? parameter)
    {
      var loadedSpeckleAccounts = AccountManager.GetAccounts();

      var accountViewModels = new List<AccountViewModel>();

      foreach (var acc in loadedSpeckleAccounts)
      {
        var accountViewModel = new AccountViewModel(acc);
        accountViewModels.Add(accountViewModel);
      }

      _navigationStore.CurrentViewModel = new AccountSelectionViewModel(_navigationStore, accountViewModels);
    }
  }
}
