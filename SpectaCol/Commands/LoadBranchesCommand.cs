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

    public LoadBranchesCommand(AccountStore accountStore)
    {
      _accountStore = accountStore;
    }

    public override void Execute(object? parameter)
    {
    }
  }
}
