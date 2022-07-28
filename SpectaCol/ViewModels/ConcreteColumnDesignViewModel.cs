using SpectaCol.Commands;
using SpectaCol.Converters.Units;
using SpectaCol.Extensions;
using SpectaCol.Models.Geometry;
using SpectaCol.Models.Materials;
using SpectaCol.Models.Sections;
using SpectaCol.Services;
using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static SpectaCol.Settings.Units;

namespace SpectaCol.ViewModels
{
  public class ConcreteColumnDesignViewModel : ViewModelBase
  {
    private readonly SettingsStore _settingsStore;
    private readonly ObjectStore _objectStore;
    private ObservableCollection<ConcreteColumnViewModel> _concreteColumnViewModels = new ObservableCollection<ConcreteColumnViewModel>();
    public IEnumerable<ConcreteColumnViewModel> ConcreteColumnViewModels => _concreteColumnViewModels;
    public ICommand OpenColumnForcesCommand { get; }

    public ConcreteColumnDesignViewModel(ObjectStore objectStore, SettingsStore settingsStore, NavigationStore navigationStore, INavigationService navigationService)
    {
      _objectStore = objectStore;

      _objectStore.ConcreteColumns?.ForEach(column =>
      {
        var columnViewModel = new ConcreteColumnViewModel(column, settingsStore);
        _concreteColumnViewModels.Add(columnViewModel);
      });

      _settingsStore = settingsStore;

      ConvertColumnDisplayUnits();
      _settingsStore.DisplayUnitsChanged += OnDisplayUnitsChanged;
      _settingsStore.DesignCodeChanged += OnDesignCodeChanged;

      OpenColumnForcesCommand = new NavigateDialogCommand(navigationService, navigationStore);
    }

    private void OnDesignCodeChanged()
    {
      _settingsStore.SelectedDesignCode.DesignColumns(_objectStore.ConcreteColumns);

      foreach (var columnViewModel in _concreteColumnViewModels)
      {
        columnViewModel.UpdateResults();
      }
    }

    private void OnDisplayUnitsChanged()
    {
      ConvertColumnDisplayUnits();
    }

    private void ConvertColumnDisplayUnits()
    {
      foreach (var columnViewModel in _concreteColumnViewModels)
      {
        columnViewModel.ForceUnit = _settingsStore.SelectedUnits.ForceUnit;
        columnViewModel.LengthUnit = _settingsStore.SelectedUnits.LengthUnit;
        columnViewModel.StressUnit = _settingsStore.SelectedUnits.StressUnit;
      }
    }

    public override void Dispose()
    {
      _settingsStore.DisplayUnitsChanged -= OnDisplayUnitsChanged;
      _settingsStore.DesignCodeChanged -= OnDesignCodeChanged;
      base.Dispose();
    }
  }
}
