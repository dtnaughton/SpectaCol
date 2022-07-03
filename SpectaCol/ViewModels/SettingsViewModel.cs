using SpectaCol.Commands;
using SpectaCol.Converters.Units;
using SpectaCol.Extensions;
using SpectaCol.Settings;
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
  public class SettingsViewModel : ViewModelBase
  {
    private readonly SettingsStore _settingsStore;
    private string _selectedUnitType;
    private string _selectedForceUnit;
    private string _selectedLengthUnit;
    private string _selectedStressUnit;

    public ICommand CloseDialogCommand { get; }
    public ICommand SaveCommand { get; }

    public List<string> DesignCodes { get; }
    public List<string> UnitTypes { get; set; }
    public ObservableCollection<string> ForceUnits { get; set; } = new ObservableCollection<string>();
    public ObservableCollection<string> LengthUnits { get; set; } = new ObservableCollection<string>();
    public ObservableCollection<string> StressUnits { get; set; } = new ObservableCollection<string>();
    public string SelectedDesignCode { get; set; }

    public string SelectedUnitType
    {
      get => _selectedUnitType;
      set
      {
        _selectedUnitType = value;
        UpdateUnits(EnumHelpers.GetValueFromDescription<UnitType>(value));
      }
    }
    public string SelectedForceUnit
    {
      get => _selectedForceUnit;
      set
      {
        _selectedForceUnit = value;
        OnPropertyChanged(nameof(SelectedForceUnit));
      }
    }
    public string SelectedLengthUnit
    {
      get => _selectedLengthUnit;
      set
      {
        _selectedLengthUnit = value;
        OnPropertyChanged(nameof(SelectedLengthUnit));
      }
    }
    public string SelectedStressUnit
    {
      get => _selectedStressUnit;
      set
      {
        _selectedStressUnit = value;
        OnPropertyChanged(nameof(SelectedStressUnit));
      }
    }

    public SettingsViewModel(SettingsStore settingsStore)
    {
      _settingsStore = settingsStore;

      UnitTypes = _settingsStore.UnitTypes.Select(unitType => unitType.GetDescription()).ToList();
      SelectedUnitType = _settingsStore.SelectedUnitType.GetDescription();
      DesignCodes = _settingsStore.DesignCodes.Select(designCode => designCode.GetDescription()).ToList();
      SelectedDesignCode = _settingsStore.SelectedDesignCode.GetDescription();

      CloseDialogCommand = new ToggleDialogVisibilityCommand(settingsStore);
      SaveCommand = new ToggleDialogVisibilityCommand(settingsStore);
    }

    private void UpdateUnits(UnitType selectedUnitType)
    {
      ForceUnits.Clear();
      LengthUnits.Clear();
      StressUnits.Clear();

      _settingsStore.ForceUnits
      .Where
      (fu => EnumHelpers.GetAttribute<Attributes.UnitSystem>(fu).UnitType == selectedUnitType)
      .ToList()
      .ForEach(fu => ForceUnits.Add(fu.GetDescription()));

      _settingsStore.LengthUnits
      .Where
      (lu => EnumHelpers.GetAttribute<Attributes.UnitSystem>(lu).UnitType == selectedUnitType)
      .ToList()
      .ForEach(lu => LengthUnits.Add(lu.GetDescription()));

      _settingsStore.StressUnits
     .Where
      (su => EnumHelpers.GetAttribute<Attributes.UnitSystem>(su).UnitType == selectedUnitType)
     .ToList()
     .ForEach(su => StressUnits.Add(su.GetDescription()));

      SelectedForceUnit = ForceUnits.FirstOrDefault();
      SelectedLengthUnit = LengthUnits.FirstOrDefault();
      SelectedStressUnit = StressUnits.FirstOrDefault();
    }

    /// <summary>
    /// Overrides values on settings store and closes dialog
    /// </summary>
    public void SaveSettings()
    {
      var newDesignCode = EnumHelpers.GetValueFromDescription<DesignCode>(SelectedDesignCode);
      if (_settingsStore.SelectedDesignCode != newDesignCode)
        _settingsStore.SelectedDesignCode = newDesignCode;

      var newUnitType = EnumHelpers.GetValueFromDescription<UnitType>(SelectedUnitType);
      if (_settingsStore.SelectedUnitType != newUnitType)
        _settingsStore.SelectedUnitType = newUnitType;

      var newForceUnit = EnumHelpers.GetValueFromDescription<ForceUnit>(SelectedForceUnit);
      var newLengthUnit = EnumHelpers.GetValueFromDescription<LengthUnit>(SelectedLengthUnit);
      var newStressUnit = EnumHelpers.GetValueFromDescription<StressUnit>(SelectedStressUnit);

      if (_settingsStore.SelectedUnits.ForceUnit != newForceUnit ||
          _settingsStore.SelectedUnits.LengthUnit != newLengthUnit ||
          _settingsStore.SelectedUnits.StressUnit != newStressUnit)
      {
        _settingsStore.SelectedUnits = new DisplayUnits(newForceUnit, newLengthUnit, newStressUnit);
      }

      CloseDialogCommand.Execute(null);
    }

    /// <summary>
    /// Results all inputs to values on settings store and closes dialog
    /// </summary>
    public void CloseCommand()
    {
      SelectedDesignCode = _settingsStore.SelectedDesignCode.GetDescription();
      SelectedUnitType = _settingsStore.SelectedUnitType.GetDescription();
      UpdateUnits(_settingsStore.SelectedUnitType);

      CloseDialogCommand.Execute(null);
    }
  }
}
