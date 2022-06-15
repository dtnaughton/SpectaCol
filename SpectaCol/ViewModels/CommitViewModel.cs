using Speckle.Core.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.ViewModels
{
  public class CommitViewModel : ViewModelBase
  {
    private readonly Commit _commit;

    public string Id => _commit.id;
    public string Author => _commit.authorName;
    public string CreationDetails => $"Sent {ViewModelUtilities.UpdatedTimeAgo(_commit.createdAt)} from {_commit.sourceApplication}";

    public CommitViewModel(Commit commit)
    {
      _commit = commit;
    }
  }
}
