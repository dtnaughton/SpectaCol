using Speckle.Core.Credentials;
using SpectaCol.Commands;
using SpectaCol.Services;
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

    private AccountViewModel _selectedAccount;
    public AccountViewModel SelectedAccount
    {
      get => _selectedAccount;
      set
      {
        _selectedAccount = value;
        OnPropertyChanged(nameof(SelectedAccount));
        LoginAccountCommand.Execute(SelectedAccount);
      }
    }

    public AccountSelectionViewModel(NavigationStore navigationStore, AccountStore accountStore)
    {
      _accounts = new ObservableCollection<AccountViewModel>();

      accountStore.Accounts.ForEach(acc =>
      {
        var accViewModel = new AccountViewModel(acc);
        _accounts.Add(accViewModel);
      });

      LoginAccountCommand = new LoginAccountCommand(new LayoutNavigationService<HomeViewModel>(navigationStore, () => new HomeViewModel(), new NavigationBarViewModel()));
    }
  }
}
