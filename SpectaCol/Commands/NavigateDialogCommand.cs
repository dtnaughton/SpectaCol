using SpectaCol.Services;
using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Commands
{
  public class NavigateDialogCommand : CommandBase
  {
    private readonly INavigationService _navigationService;
    private readonly NavigationStore _navigationStore;

    public NavigateDialogCommand(INavigationService navigationService, NavigationStore navigationStore)
    {
      _navigationService = navigationService;
      _navigationStore = navigationStore;
    }

    public override void Execute(object? parameter)
    {
      _navigationService.Navigate();
      _navigationStore.IsDialogOpen = !_navigationStore.IsDialogOpen;
    }
  }
}
