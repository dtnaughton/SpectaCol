using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.ViewModels
{
  public class HomeViewModel : ViewModelBase
  {
    private AccountStore _accountStore;

    public string SelectedAccount => $"{_accountStore.SelectedAccount.serverInfo.name} | {_accountStore.SelectedAccount.userInfo.email}";

    public string SelectedBranch => _accountStore.SelectedBranch != null ? $"{_accountStore.SelectedBranch.name}" : "none";
    
    public string SelectedCommit => _accountStore.SelectedCommit != null ? $"{_accountStore.SelectedCommit.id}" : "none";

    public HomeViewModel(AccountStore accountStore)
    {
      _accountStore = accountStore;
    }
  }
}
