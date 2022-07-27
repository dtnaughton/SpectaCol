using SpectaCol.Converters.Units;
using SpectaCol.Models.Enums;
using SpectaCol.Models.Geometry;
using SpectaCol.Models.Interfaces;
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
    private IConcreteSection _column;
    private SettingsStore _settingsStore;
    private ForceUnit _backendForceUnit = ForceUnit.N;
    private LengthUnit _backendLengthUnit = LengthUnit.mm;
    private StressUnit _backendStressUnit = StressUnit.mPa;
    private event Action _columnParameterChanged;

    public IConcreteSection Column
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
        _columnParameterChanged?.Invoke();
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
        _columnParameterChanged?.Invoke();
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
        _columnParameterChanged?.Invoke();
      }
    }
    public double Cover
    {
      get => DisplayRounding(FrontendLengthConversion(Column.CrossSectionParameters.Cover));
      set
      {
        Column.CrossSectionParameters.Cover =  BackendLengthConversion(value);
        OnPropertyChanged(nameof(Cover));
        _columnParameterChanged?.Invoke();
      }
    }
    public double Length
    {
      get => DisplayRounding(FrontendLengthConversion(Column.Length));
      set
      {
        Column.Length = BackendLengthConversion(value);
        OnPropertyChanged(nameof(Length));
        _columnParameterChanged?.Invoke();
      }
    }
    public double ConcreteStrength
    {
      get => DisplayRounding(FrontendStressConversion(Column.Concrete.CompressiveStrength));
      set
      {
        Column.Concrete.CompressiveStrength = BackendStressConversion(value);
        OnPropertyChanged(nameof(ConcreteStrength));
        _columnParameterChanged?.Invoke();
      }
    }
    public double LongitudinalReinforcementStrength
    {
      get => DisplayRounding(FrontendStressConversion(Column.LongitudinalReinforcement.YieldStrength));
      set
      {
        Column.LongitudinalReinforcement.YieldStrength = BackendStressConversion(value);
        OnPropertyChanged(nameof(LongitudinalReinforcementStrength));
        _columnParameterChanged?.Invoke();
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
        _columnParameterChanged?.Invoke();
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
        _columnParameterChanged?.Invoke();
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
        _columnParameterChanged?.Invoke();
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
        _columnParameterChanged?.Invoke();
      }
    }
    public double LongitudinalReinforcementPercentage
    {
      get => DisplayRounding(Column.LongitudinalReinforcement.ReinforcementPercentage);
    }

    public double MaximumUtilization
    {
      get => DisplayRounding(Column.MaximumUtilization);
    }

    public ForceUnit ForceUnit
    {
      get => Column.ForceUnit;
      set
      {
        Column.ForceUnit = value;
        UpdateForceProperties();
      }
    }


    public LengthUnit LengthUnit
    {
      get => Column.LengthUnit;
      set
      {
        Column.LengthUnit = value;
        UpdateLengthProperties();
      }
    }


    public StressUnit StressUnit
    {
      get => Column.StressUnit;
      set
      {
        Column.StressUnit = value;
        UpdateStressProperties();
      }
    }

    private void UpdateForceProperties()
    {
      //OnPropertyChanged(nameof(CompressionResistance));
    }
    private void UpdateLengthProperties()
    {
      OnPropertyChanged(nameof(Width));
      OnPropertyChanged(nameof(Depth));
      OnPropertyChanged(nameof(Cover));
      OnPropertyChanged(nameof(Length));
    }
    private void UpdateStressProperties()
    {
      OnPropertyChanged(nameof(ConcreteStrength));
      OnPropertyChanged(nameof(LongitudinalReinforcementStrength));
    }

    public void UpdateResults()
    {
      OnPropertyChanged(nameof(MaximumUtilization));
    }

    public ConcreteColumnViewModel(IConcreteSection concreteColumn, SettingsStore settingsStore)
    {
      _column = concreteColumn;
      _settingsStore = settingsStore;

      _columnParameterChanged += OnColumnParameterChanged;
    }

    private void OnColumnParameterChanged()
    {
      UpdateStructuralCapacity();
      UpdateResults();
    }

    private void UpdateStructuralCapacity()
    {
      _settingsStore.SelectedDesignCode.DesignColumns(Column);
    }


    #region Force conversion and rounding
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
    #endregion
  }
}
