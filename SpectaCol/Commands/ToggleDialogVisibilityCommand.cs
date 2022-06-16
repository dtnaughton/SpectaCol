using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Commands
{
  public class ToggleDialogVisibilityCommand : CommandBase
  {
    private readonly IDialogStore _dialogStore;

    public ToggleDialogVisibilityCommand(IDialogStore dialogStore)
    {
      _dialogStore = dialogStore;
    }

    public override void Execute(object? parameter)
    {
      _dialogStore.IsOpen = !_dialogStore.IsOpen;
    }
  }
}
