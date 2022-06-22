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

    private Account? _selectedAccount;
    private Stream? _selectedStream;
    private Branch? _selectedBranch;
    private Commit? _selectedCommit;
    public Account? SelectedAccount
    {
      get => _selectedAccount;
      set
      {
        _selectedAccount = value;
      }
    }
    public Stream? SelectedStream
    {
      get => _selectedStream;
      set
      {
        _selectedStream = value;
      }
    }
    public Branch? SelectedBranch
    {
      get => _selectedBranch;
      set
      {
        _selectedBranch = value;
      }
    }
    public Commit? SelectedCommit
    {
      get => _selectedCommit;
      set
      {
        _selectedCommit = value;
      }
    }

    public event Action BranchesChanged;
    public event Action CommitsChanged;
    public event Action SelectedTargetChanged;

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

    public void InvokeSelectedTargetChanged()
    {
      SelectedTargetChanged?.Invoke();
    }

  }
}
