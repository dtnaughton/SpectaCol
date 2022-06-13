using Speckle.Core.Api;
using Speckle.Core.Credentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Stores
{
  public class AccountStore
  {
    public List<Account>? Accounts { get; set; }
    public List<Branch>? Branches { get; set; }
    public List<Commit>? Commits { get; set; }
    public Account? SelectedAccount { get; set; }
    public Branch? SelectedBranch { get; set; }
    public Commit? SelectedCommit { get; set; }

    public void ClearSelectedAccount()
    {
      SelectedAccount = null;
      SelectedBranch = null;
      SelectedCommit = null;
      Branches?.Clear();
      Commits?.Clear();
    }
    
  }
}
