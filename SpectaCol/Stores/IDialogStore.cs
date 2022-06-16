using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Stores
{
  public interface IDialogStore
  {
    event Action IsOpenChanged;
    bool IsOpen { get; set; }
  }
}
