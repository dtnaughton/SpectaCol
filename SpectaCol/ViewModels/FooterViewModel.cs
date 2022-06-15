using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.ViewModels
{
  public class FooterViewModel : ViewModelBase
  {
    private AccountStore _accountStore;

    public string SelectedStream => _accountStore.SelectedStream != null ? $"{_accountStore.SelectedStream.name}" : "none";

    public string SelectedAccount => _accountStore.SelectedAccount != null ? 
      $"{_accountStore.SelectedAccount.serverInfo.name} | {_accountStore.SelectedAccount.userInfo.email}" : "none";

    public string SelectedBranch => _accountStore.SelectedBranch != null ? $"{_accountStore.SelectedBranch.name}" : "none";

    public string SelectedCommit => _accountStore.SelectedCommit != null ? $"{_accountStore.SelectedCommit.id}" : "none";

    public FooterViewModel(AccountStore accountStore)
    {
      _accountStore = accountStore;
      _accountStore.SelectedTargetChanged += OnSelectedTargetChanged;
    }

    private void OnSelectedTargetChanged()
    {
      OnPropertyChanged(nameof(SelectedAccount));
      OnPropertyChanged(nameof(SelectedStream));
      OnPropertyChanged(nameof(SelectedBranch));
      OnPropertyChanged(nameof(SelectedCommit));
    }

    public override void Dispose()
    {
      _accountStore.SelectedTargetChanged -= OnSelectedTargetChanged;
      base.Dispose();
    }
  }
}
