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
    private AccountStore _accountStore;
    public IEnumerable<AccountViewModel> Accounts => _accounts;
    public ICommand LoginAccountCommand { get; }

    private AccountViewModel? _selectedAccount;
    public AccountViewModel? SelectedAccount
    {
      get => _selectedAccount;
      set
      {
        _selectedAccount = value;
        OnPropertyChanged(nameof(SelectedAccount));
        _accountStore.SelectedAccount = _accountStore.Accounts?.Where(account => account.id == _selectedAccount?.Id).FirstOrDefault();
        LoginAccountCommand.Execute(null);
      }
    }

    public AccountSelectionViewModel(NavigationStore navigationStore, AccountStore accountStore, SettingsStore settingsStore)
    {
      _accounts = new ObservableCollection<AccountViewModel>();
      _accountStore = accountStore;

      accountStore.Accounts?.ForEach(acc =>
      {
        var accViewModel = new AccountViewModel(acc);
        _accounts.Add(accViewModel);
      });

      LoginAccountCommand = new NavigateCommand(new LayoutNavigationService<HomeViewModel, ViewModelBase>(navigationStore, () => new HomeViewModel(), new NavigationBarViewModel(accountStore, navigationStore, settingsStore), new FooterViewModel(accountStore), () => new SettingsViewModel(settingsStore), settingsStore));
    }
  }
}
