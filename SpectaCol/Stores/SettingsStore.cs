using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Stores
{
  public class SettingsStore : IDialogStore
  {
    private bool _isOpen;
    public bool IsOpen
    {
      get => _isOpen;
      set
      {
        _isOpen = value;
        IsOpenChanged?.Invoke();
      }
    }

    public event Action IsOpenChanged;
  }
}
