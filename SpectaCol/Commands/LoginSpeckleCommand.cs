using Speckle.Core.Credentials;
using SpectaCol.Services;
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
    private readonly INavigationService _navigationService;
    private readonly AccountStore _accountStore;

    public LoginSpeckleCommand(INavigationService navigationService, AccountStore accountStore)
    {
      _navigationService = navigationService;
      _accountStore = accountStore;
    }

    public override void Execute(object? parameter)
    {
      _accountStore.Accounts = AccountManager.GetAccounts().ToList();

      _navigationService.Navigate();
    }
  }
}
