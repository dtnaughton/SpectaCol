using Speckle.Core.Credentials;
using SpectaCol.Commands;
using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpectaCol.ViewModels
{
  public class AccountSelectionViewModel : ViewModelBase
  {
    private ObservableCollection<AccountViewModel> _accounts;
    public IEnumerable<AccountViewModel> Accounts => _accounts;
    public ICommand LoginAccountCommand { get; }

    public AccountSelectionViewModel(NavigationStore navigationStore, List<AccountViewModel> accounts)
    {
      _accounts = new ObservableCollection<AccountViewModel>();

      accounts.ForEach(account => _accounts.Add(account));

      LoginAccountCommand = new LoginAccountCommand(navigationStore);
    }
  }
}
