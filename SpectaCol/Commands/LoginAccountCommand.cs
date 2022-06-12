using SpectaCol.Stores;
using SpectaCol.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Commands
{
  public class LoginAccountCommand : CommandBase
  {
    private readonly NavigationStore _navigationStore;
    public LoginAccountCommand(NavigationStore navigationStore)
    {
      _navigationStore = navigationStore;
    }
    public override void Execute(object? parameter)
    {
      _navigationStore.CurrentViewModel = new HomeViewModel();
    }
  }
}
