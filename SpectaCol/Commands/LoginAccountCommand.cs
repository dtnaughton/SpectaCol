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
  public class LoginAccountCommand: CommandBase
  {
    private readonly LayoutNavigationService<HomeViewModel> _navigationService;

    public LoginAccountCommand(LayoutNavigationService<HomeViewModel> navigationService)
    {
      _navigationService = navigationService;
    }

    public override void Execute(object? parameter)
    {
      _navigationService.Navigate();
    }
  }
}
