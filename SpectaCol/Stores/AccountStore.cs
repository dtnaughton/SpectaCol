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
    private List<Branch>? _branches;
    private List<Commit>? _commits;
    public List<Account>? Accounts { get; set; }
    public List<Stream>? Streams { get; set; }
    public List<Branch>? Branches
    {
      get => _branches;
      set
      {
        _branches = value;
        BranchesChanged?.Invoke();
      }
    }
    public List<Commit>? Commits
    {
      get => _commits;
      set
      {
        _commits = value;
        CommitsChanged?.Invoke();
      }
    }
    public Account? SelectedAccount { get; set; }
    public Stream? SelectedStream { get; set; }
    public Branch? SelectedBranch { get; set; }
    public Commit? SelectedCommit { get; set; }
    
    public event Action BranchesChanged;
    public event Action CommitsChanged;

    public void ClearSelectedAccount()
    {
      SelectedAccount = null;
      SelectedStream = null;
      SelectedBranch = null;
      SelectedCommit = null;
      Streams?.Clear();
      Branches?.Clear();
      Commits?.Clear();
    }

  }
}
