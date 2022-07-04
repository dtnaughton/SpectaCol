using SpectaCol.Converters.Units;
using SpectaCol.Models.Enums;
using SpectaCol.Models.Geometry;
using SpectaCol.Models.Materials;
using SpectaCol.Models.Sections;
using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpectaCol.Settings.Units;

namespace SpectaCol.ViewModels
{
  public class ConcreteColumnViewModel : ViewModelBase
  {
    private ConcreteColumn _column;
    private SettingsStore _settingsStore;
    private ForceUnit _backendForceUnit = ForceUnit.N;
    private LengthUnit _backendLengthUnit = LengthUnit.mm;
    private StressUnit _backendStressUnit = StressUnit.mPa;

    public ConcreteColumn Column
    {
      get => _column;
    }

    public bool IsSelected { get; set; }
    public SectionShape SectionShape
    {
      get => Column.Shape;
      set
      {
        Column.Shape = value;
        OnPropertyChanged(nameof(SectionShape));
      }
    }
    public double Width
    {
      get => DisplayRounding(FrontendLengthConversion(Column.CrossSectionParameters.Width));
      set
      {
        Column.CrossSectionParameters.Width = BackendLengthConversion(value);
        OnPropertyChanged(nameof(Width));
        OnPropertyChanged(nameof(LongitudinalReinforcementPercentage));
      }
    }
    public double Depth
    {
      get => DisplayRounding(FrontendLengthConversion(Column.CrossSectionParameters.Depth));
      set
      {
        Column.CrossSectionParameters.Depth = BackendLengthConversion(value);
        OnPropertyChanged(nameof(Depth));
        OnPropertyChanged(nameof(LongitudinalReinforcementPercentage));
      }
    }
    public double Cover
    {
      get => DisplayRounding(FrontendLengthConversion(Column.CrossSectionParameters.Cover));
      set
      {
        Column.CrossSectionParameters.Cover =  BackendLengthConversion(value);
        OnPropertyChanged(nameof(Cover));
      }
    }
    public double Length
    {
      get => DisplayRounding(FrontendLengthConversion(Column.Length));
      set
      {
        Column.Length = BackendLengthConversion(value);
        OnPropertyChanged(nameof(Length));
      }
    }
    public double ConcreteStrength
    {
      get => DisplayRounding(FrontendStressConversion(Column.Material.CompressiveStrength));
      set
      {
        Column.Material.CompressiveStrength = BackendStressConversion(value);
        OnPropertyChanged(nameof(ConcreteStrength));
      }
    }
    public double LongitudinalReinforcementStrength
    {
      get => DisplayRounding(FrontendStressConversion(Column.LongitudinalReinforcement.YieldStrength));
      set
      {
        Column.LongitudinalReinforcement.YieldStrength = BackendStressConversion(value);
        OnPropertyChanged(nameof(LongitudinalReinforcementStrength));
      }
    }
    public int QuantityLayers
    {
      get => Column.LongitudinalReinforcement.QuantityLayers;
      set
      {
        Column.LongitudinalReinforcement.QuantityLayers = value;
        OnPropertyChanged(nameof(QuantityLayers));
        OnPropertyChanged(nameof(LongitudinalReinforcementPercentage));
      }
    }
    public int QuantityX
    {
      get => Column.LongitudinalReinforcement.QuantityX;
      set
      {
        Column.LongitudinalReinforcement.QuantityX = value;
        OnPropertyChanged(nameof(QuantityX));
        OnPropertyChanged(nameof(LongitudinalReinforcementPercentage));
      }
    }
    public int QuantityY
    {
      get => Column.LongitudinalReinforcement.QuantityY;
      set
      {
        Column.LongitudinalReinforcement.QuantityY = value;
        OnPropertyChanged(nameof(QuantityY));
        OnPropertyChanged(nameof(LongitudinalReinforcementPercentage));
      }
    }
    public ReinforcementDiameter LongitudinalBarDiameter
    {
      get => Column.LongitudinalReinforcement.Diameter;
      set
      {
        Column.LongitudinalReinforcement.Diameter = value;
        OnPropertyChanged(nameof(LongitudinalBarDiameter));
        OnPropertyChanged(nameof(LongitudinalReinforcementPercentage));
      }
    }
    public double LongitudinalReinforcementPercentage
    {
      get => DisplayRounding(Column.LongitudinalReinforcement.ReinforcementPercentage);
    }
    public ForceUnit ForceUnit
    {
      get => Column.ForceUnit;
      set
      {
        Column.ForceUnit = value;
        UpdateForceUnits();
      }
    }


    public LengthUnit LengthUnit
    {
      get => Column.LengthUnit;
      set
      {
        Column.LengthUnit = value;
        UpdateLengthUnits();
      }
    }


    public StressUnit StressUnit
    {
      get => Column.StressUnit;
      set
      {
        Column.StressUnit = value;
        UpdateStressUnits();
      }
    }

    private void UpdateForceUnits()
    {
      // To be implemented
    }
    private void UpdateLengthUnits()
    {
      OnPropertyChanged(nameof(Width));
      OnPropertyChanged(nameof(Depth));
      OnPropertyChanged(nameof(Cover));
      OnPropertyChanged(nameof(Length));
    }
    private void UpdateStressUnits()
    {
      OnPropertyChanged(nameof(ConcreteStrength));
      OnPropertyChanged(nameof(LongitudinalReinforcementStrength));
    }

    public ConcreteColumnViewModel(ConcreteColumn concreteColumn, SettingsStore settingsStore)
    {
      _column = concreteColumn;
      _settingsStore = settingsStore;
    }

    private double DisplayRounding(double value)
    {
      return Math.Round(value, 3);
    }

    private double BackendForceConversion(double value)
    {
      return value * UnitConverter.UnitScaleFactor(_settingsStore.SelectedUnits.ForceUnit, _backendForceUnit);
    }

    private double BackendLengthConversion(double value)
    {
      return value * UnitConverter.UnitScaleFactor(_settingsStore.SelectedUnits.LengthUnit, _backendLengthUnit);
    }

    private double BackendStressConversion(double value)
    {
      return value * UnitConverter.UnitScaleFactor(_settingsStore.SelectedUnits.StressUnit, _backendStressUnit);
    }

    private double FrontendForceConversion(double value)
    {
      return value * UnitConverter.UnitScaleFactor(_backendForceUnit, _settingsStore.SelectedUnits.ForceUnit);
    }

    private double FrontendLengthConversion(double value)
    {
      return value * UnitConverter.UnitScaleFactor(_backendLengthUnit, _settingsStore.SelectedUnits.LengthUnit);
    }

    private double FrontendStressConversion(double value)
    {
      return value * UnitConverter.UnitScaleFactor(_backendStressUnit, _settingsStore.SelectedUnits.StressUnit);
    }
  }
}
