using SpectaCol.Commands;
using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpectaCol.ViewModels
{
  public class ColumnTabulatedForcesViewModel : ViewModelBase
  {
    public ColumnTabulatedForcesViewModel(ObjectStore objectStore, NavigationStore navigationStore, SettingsStore settingsStore)
    {
      foreach (var kvp in objectStore.SelectedConcreteColumn.Forces)
      {
        foreach (var result in kvp.Value)
        {
          _frameResultViewModels.Add(new FrameResultViewModel(result, settingsStore, objectStore.SelectedConcreteColumn.ForceUnit, objectStore.SelectedConcreteColumn.LengthUnit));
        }
      }

      CloseDialogCommand = new ToggleDialogVisibilityCommand(navigationStore);

    }
    public ICommand CloseDialogCommand { get; }
    private ObservableCollection<FrameResultViewModel> _frameResultViewModels = new ObservableCollection<FrameResultViewModel>();
    public IEnumerable<FrameResultViewModel> FrameResultViewModels => _frameResultViewModels;
  }
}
