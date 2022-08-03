using SpectaCol.Converters.Units;
using SpectaCol.Models.Enums;
using SpectaCol.Models.Geometry;
using SpectaCol.Models.Interfaces;
using SpectaCol.Models.Materials;
using SpectaCol.Models.Sections;
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
  public class ConcreteColumnViewModel : ViewModelBase
  {
    private IConcreteSection _column;
    private SettingsStore _settingsStore;
    private ForceUnit _backendForceUnit = ForceUnit.N;
    private LengthUnit _backendLengthUnit = LengthUnit.mm;
    private StressUnit _backendStressUnit = StressUnit.mPa;
    private event Action _columnParameterChanged;
    private int roundingFigure = 3;

    public IConcreteSection Column
    {
      get => _column;
    }

    public string ApplicationId => Column.ApplicationId;
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
      get => Column.CrossSectionParameters.Width.FrontendLengthConversion(_backendLengthUnit, _settingsStore.SelectedUnits.LengthUnit).DisplayRounding(roundingFigure);
      set
      {
        Column.CrossSectionParameters.Width = value.BackendLengthConversion(_settingsStore.SelectedUnits.LengthUnit, _backendLengthUnit);
        OnPropertyChanged(nameof(Width));
        OnPropertyChanged(nameof(LongitudinalReinforcementPercentage));
        _columnParameterChanged?.Invoke();
      }
    }
    public double Depth
    {
      get => Column.CrossSectionParameters.Depth.FrontendLengthConversion(_backendLengthUnit, _settingsStore.SelectedUnits.LengthUnit).DisplayRounding(roundingFigure);
      set
      {
        Column.CrossSectionParameters.Depth = value.BackendLengthConversion(_settingsStore.SelectedUnits.LengthUnit, _backendLengthUnit);
        OnPropertyChanged(nameof(Depth));
        OnPropertyChanged(nameof(LongitudinalReinforcementPercentage));
        _columnParameterChanged?.Invoke();
      }
    }
    public double Cover
    {
      get => Column.CrossSectionParameters.Cover.FrontendLengthConversion(_backendLengthUnit, _settingsStore.SelectedUnits.LengthUnit).DisplayRounding(roundingFigure);
      set
      {
        Column.CrossSectionParameters.Cover = value.BackendLengthConversion(_settingsStore.SelectedUnits.LengthUnit, _backendLengthUnit);
        OnPropertyChanged(nameof(Cover));
        _columnParameterChanged?.Invoke();
      }
    }
    public double Length
    {
      get => Column.Length.FrontendLengthConversion(_backendLengthUnit, _settingsStore.SelectedUnits.LengthUnit).DisplayRounding(roundingFigure);
      set
      {
        Column.Length = value.BackendLengthConversion(_settingsStore.SelectedUnits.LengthUnit, _backendLengthUnit);
        OnPropertyChanged(nameof(Length));
        _columnParameterChanged?.Invoke();
      }
    }
    public double ConcreteStrength
    {
      //get => DisplayRounding(FrontendStressConversion(Column.Concrete.CompressiveStrength));
      get => Column.Concrete.CompressiveStrength.FrontendStressConversion(_backendStressUnit, _settingsStore.SelectedUnits.StressUnit).DisplayRounding(roundingFigure);
      set
      {
        Column.Concrete.CompressiveStrength = value.BackendStressConversion(_settingsStore.SelectedUnits.StressUnit, _backendStressUnit);
        OnPropertyChanged(nameof(ConcreteStrength));
        _columnParameterChanged?.Invoke();
      }
    }
    public double LongitudinalReinforcementStrength
    {
      get => Column.LongitudinalReinforcement.YieldStrength.FrontendStressConversion(_backendStressUnit, _settingsStore.SelectedUnits.StressUnit).DisplayRounding(roundingFigure);
      set
      {
        Column.LongitudinalReinforcement.YieldStrength = value.BackendStressConversion(_settingsStore.SelectedUnits.StressUnit, _backendStressUnit);
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
      get => Column.LongitudinalReinforcement.ReinforcementPercentage.DisplayRounding(roundingFigure);
    }

    public double MaximumUtilization
    {
      get => Column.MaximumUtilization.DisplayRounding(roundingFigure);
    }

    private ForceUnit _forceUnit;
    public ForceUnit ForceUnit
    {
      get => _forceUnit;
      set
      {
        _forceUnit = value;
        UpdateForceProperties();
      }
    }

    private LengthUnit _lengthUnit;
    public LengthUnit LengthUnit
    {
      get => _lengthUnit;
      set
      {
        _lengthUnit = value;
        UpdateLengthProperties();
      }
    }

    private StressUnit _stressUnit;
    public StressUnit StressUnit
    {
      get => _stressUnit;
      set
      {
        _stressUnit = value;
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
      ForceUnit = concreteColumn.ForceUnit;
      LengthUnit = concreteColumn.LengthUnit;
      StressUnit = concreteColumn.StressUnit;
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
  }
}
