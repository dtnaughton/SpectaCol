using Speckle.Core.Api;
using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Commands
{
  public class LoadBranchesCommand : CommandBase
  {
    private readonly AccountStore _accountStore;
    private readonly int _branchesLimit = 25;

    public LoadBranchesCommand(AccountStore accountStore)
    {
      _accountStore = accountStore;
    }

    public override async void Execute(object? parameter)
    {
      if (_accountStore.SelectedAccount != null && _accountStore.SelectedStream != null)
      {
        var speckleClient = new Client(_accountStore.SelectedAccount);
        _accountStore.Branches = await speckleClient.StreamGetBranches(_accountStore.SelectedStream.id, _branchesLimit);
      }
    }
  }
}
