using Speckle.Core.Api;
using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Commands
{
  public class LoadCommitsCommand : CommandBase
  {
    private readonly AccountStore _accountStore;
    private readonly int _commitsLimit = 25;

    public LoadCommitsCommand(AccountStore accountStore)
    {
      _accountStore = accountStore;
    }

    public override void Execute(object? parameter)
    {
      //if (_accountStore.SelectedAccount != null && _accountStore.SelectedStream != null && _accountStore.SelectedBranch != null)
      //{
      //  var speckleClient = new Client(_accountStore.SelectedAccount);
      //  _accountStore.Branches = await speckleClient.StreamGetBranches(_accountStore.SelectedStream.id, _branchesLimit);
      //}
    }
  }
}
