using SpectaCol.Commands;
using SpectaCol.Converters.Units;
using SpectaCol.Extensions;
using SpectaCol.Models.Geometry;
using SpectaCol.Models.Materials;
using SpectaCol.Models.Sections;
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
    private ObservableCollection<ConcreteColumnViewModel> _concreteColumnViewModels = new ObservableCollection<ConcreteColumnViewModel>();
    public IEnumerable<ConcreteColumnViewModel> ConcreteColumnViewModels => _concreteColumnViewModels;


    public ConcreteColumnDesignViewModel(ObjectStore objectStore, SettingsStore settingsStore)
    {
      objectStore.ConcreteColumns?.ForEach(column =>
      {
        var columnViewModel = new ConcreteColumnViewModel(column);
        _concreteColumnViewModels.Add(columnViewModel);
      });

      _settingsStore = settingsStore;

      ConvertColumnDisplayUnits();
      _settingsStore.DisplayUnitsChanged += OnDisplayUnitsChanged;
    }

    private void OnDisplayUnitsChanged()
    {
      ConvertColumnDisplayUnits();
    }

    private void ConvertColumnDisplayUnits()
    {
      foreach (var column in _concreteColumnViewModels)
      {
        var forceScaleFactor = UnitConverter.UnitScaleFactor(column.ForceUnit, _settingsStore.SelectedUnits.ForceUnit);
        var lengthScaleFactor = UnitConverter.UnitScaleFactor(column.LengthUnit, _settingsStore.SelectedUnits.LengthUnit);
        var stressScaleFactor = UnitConverter.UnitScaleFactor(column.StressUnit, _settingsStore.SelectedUnits.StressUnit);

        column.Width *= lengthScaleFactor;
        column.Depth *= lengthScaleFactor;
        column.Cover *= lengthScaleFactor;
        column.Length *= lengthScaleFactor;
        column.ConcreteStrength *= stressScaleFactor;
        column.LongitudinalReinforcementStrength *= stressScaleFactor;

        column.ForceUnit = _settingsStore.SelectedUnits.ForceUnit;
        column.LengthUnit = _settingsStore.SelectedUnits.LengthUnit;
        column.StressUnit = _settingsStore.SelectedUnits.StressUnit;
      }
    }

    public override void Dispose()
    {
      _settingsStore.DisplayUnitsChanged -= OnDisplayUnitsChanged;
      base.Dispose();
    }
  }
}
