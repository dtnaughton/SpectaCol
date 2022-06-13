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
  public class SpeckleLoginViewModel : ViewModelBase
  {
    private readonly NavigationStore _navigationStore;
    public ICommand LoginSpeckleCommand { get; }

    public SpeckleLoginViewModel(NavigationStore navigationStore, AccountStore accountStore)
    {
      _navigationStore = navigationStore;
      LoginSpeckleCommand = new LoginSpeckleCommand(new NavigationService<AccountSelectionViewModel>(navigationStore, () => new AccountSelectionViewModel(navigationStore, accountStore)), accountStore);
    }
  }
}
