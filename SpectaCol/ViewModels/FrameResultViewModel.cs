using SpectaCol.Models.Results;
using SpectaCol.Stores;
using SpectaCol.ViewModels.DisplayConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpectaCol.Settings.Units;

namespace SpectaCol.ViewModels
{
  public class FrameResultViewModel : ViewModelBase
  {
    private readonly FrameResult _frameResult;
    private readonly SettingsStore _settingsStore;
    private readonly ForceUnit _backendForceUnit;
    private readonly LengthUnit _backendLengthUnit;
    private const int RoundingValue = 2;
    public int? Index => _frameResult.Index;
    public string LoadCombination => _frameResult.LoadCombination;
    public double Position => _frameResult.Position;
    public double Axial => _frameResult.Axial.FrontendForceConversion(_backendForceUnit, _settingsStore.SelectedUnits.ForceUnit).DisplayRounding(RoundingValue);
    public double MomentX => _frameResult.MomentX.FrontendForceConversion(_backendForceUnit, _settingsStore.SelectedUnits.ForceUnit).
      FrontendLengthConversion(_backendLengthUnit, _settingsStore.SelectedUnits.LengthUnit).DisplayRounding(RoundingValue);
    public double MomentY => _frameResult.MomentY.FrontendForceConversion(_backendForceUnit, _settingsStore.SelectedUnits.ForceUnit).
      FrontendLengthConversion(_backendLengthUnit, _settingsStore.SelectedUnits.LengthUnit).DisplayRounding(RoundingValue);
    public double ShearX => _frameResult.ShearX.FrontendForceConversion(_backendForceUnit, _settingsStore.SelectedUnits.ForceUnit).DisplayRounding(RoundingValue);
    public double ShearY => _frameResult.ShearY.FrontendForceConversion(_backendForceUnit, _settingsStore.SelectedUnits.ForceUnit).DisplayRounding(RoundingValue);
    public double Torsion => _frameResult.Torsion.FrontendForceConversion(_backendForceUnit, _settingsStore.SelectedUnits.ForceUnit).
      FrontendLengthConversion(_backendLengthUnit, _settingsStore.SelectedUnits.LengthUnit).DisplayRounding(RoundingValue);;

    public FrameResultViewModel(FrameResult frameResult, SettingsStore settingsStore, ForceUnit backendForceUnit, LengthUnit backendLengthUnit)
    {
      _frameResult = frameResult;
      _settingsStore = settingsStore;
      _backendForceUnit = backendForceUnit;
      _backendLengthUnit = backendLengthUnit;
    }
  }
}
