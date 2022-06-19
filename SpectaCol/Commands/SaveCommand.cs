using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Commands
{
  public class SaveCommand : CommandBase
  {
    private readonly IDialogStore _dialogStore;

    public event Action DialogStateSaved;

    public SaveCommand(IDialogStore dialogStore)
    {
      _dialogStore = dialogStore;
    }

    public override void Execute(object? parameter)
    {
      DialogStateSaved?.Invoke();

      _dialogStore.IsOpen = false;
    }
  }
}
