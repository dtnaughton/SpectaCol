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
    public ICommand LoginSpeckleCommand { get; }

    public SpeckleLoginViewModel(INavigationService accountSelectionNavigationService, AccountStore accountStore)
    {
      LoginSpeckleCommand = new LoginSpeckleCommand(accountSelectionNavigationService, accountStore);
    }
  }
}
