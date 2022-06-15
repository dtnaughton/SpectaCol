using Speckle.Core.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.ViewModels
{
  public class BranchViewModel : ViewModelBase
  {
    private Branch _branch;
    public string BranchName => _branch.name;
    public string BranchId => _branch.id;

    public BranchViewModel(Branch branch)
    {
      _branch = branch;
    }
  }
}
