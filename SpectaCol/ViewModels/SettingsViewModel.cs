using SpectaCol.Commands;
using SpectaCol.Extensions;
using SpectaCol.Settings;
using SpectaCol.Stores;
using System;
using System.Collections.Generic;
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
    private bool _initialized;
    public ICommand CloseDialogCommand { get; }
    public ICommand SaveCommand { get; }
    public string SelectedLengthUnit { get; set; }
    public string SelectedForceUnit { get; set; }
    public string SelectedDesignCode { get; set; }
    public List<string>? LengthUnits { get; }
    public List<string> ForceUnits { get; }
    public List<string> DesignCodes { get; }

    public SettingsViewModel(SettingsStore settingsStore)
    {
      _settingsStore = settingsStore;
      LengthUnits = settingsStore.LengthUnits.Select(lengthUnit => lengthUnit.GetDescription()).ToList();
      ForceUnits = settingsStore.ForceUnits.Select(forceUnit => forceUnit.GetDescription()).ToList();
      DesignCodes = settingsStore.DesignCodes.Select(designCode => designCode.GetDescription()).ToList();

      if (!InitialSettingsSelected())
      {
        InitializeInitialSelections();
      }

      CloseDialogCommand = new ToggleDialogVisibilityCommand(settingsStore);
      SaveCommand = new ToggleDialogVisibilityCommand(settingsStore);
    }

    public void SaveSettings()
    {
      _settingsStore.SelectedLengthUnit = EnumHelpers.GetValueFromDescription<LengthUnit>(SelectedLengthUnit);
      _settingsStore.SelectedForceUnit = EnumHelpers.GetValueFromDescription<ForceUnit>(SelectedForceUnit);
      _settingsStore.SelectedDesignCode = EnumHelpers.GetValueFromDescription<DesignCode>(SelectedDesignCode);

      CloseDialogCommand.Execute(null);
    }

    private bool InitialSettingsSelected()
    {
      return !(String.IsNullOrEmpty(SelectedLengthUnit) && String.IsNullOrEmpty(SelectedForceUnit) && String.IsNullOrEmpty(SelectedDesignCode));
    }

    private void InitializeInitialSelections()
    {
      SelectedLengthUnit = LengthUnits != null && LengthUnits.Any() ? LengthUnits.FirstOrDefault() : "";
      SelectedForceUnit = ForceUnits != null && ForceUnits.Any() ? ForceUnits.FirstOrDefault() : "";
      SelectedDesignCode = DesignCodes != null && DesignCodes.Any() ? DesignCodes.FirstOrDefault() : "";
    }
  }
}
