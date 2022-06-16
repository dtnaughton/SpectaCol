using SpectaCol.Commands;
using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpectaCol.ViewModels
{
  public class SettingsViewModel : ViewModelBase
  {
    public ICommand CloseDialogCommand { get; }

    public SettingsViewModel(IDialogStore dialogStore)
    {
      CloseDialogCommand = new ToggleDialogVisibilityCommand(dialogStore);
    }
  }
}
