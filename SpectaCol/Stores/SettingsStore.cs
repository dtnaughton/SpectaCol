using SpectaCol.Converters.Units;
using SpectaCol.Extensions;
using SpectaCol.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpectaCol.Settings.Units;

namespace SpectaCol.Stores
{
  public class SettingsStore : IDialogStore
  {
    private bool _isOpen;
    private DesignCode _selectedDesignCode;
    private DisplayUnits _selectedUnits;

    public int UnitSettingsToChange { get; set; }
    public List<UnitType> UnitTypes { get; }
    public List<DesignCode> DesignCodes { get; }

    public List<ForceUnit> ForceUnits { get; } = new List<ForceUnit>();
    public List<LengthUnit> LengthUnits { get; } = new List<LengthUnit>();
    public List<StressUnit> StressUnits { get; } = new List<StressUnit>();

    public DisplayUnits SelectedUnits
    {
      get => _selectedUnits;
      set
      {
        _selectedUnits = value;
        DisplayUnitsChanged?.Invoke();
      }
    }

    public DesignCode SelectedDesignCode
    {
      get => _selectedDesignCode;
      set
      {
        _selectedDesignCode = value;
        DesignCodeChanged?.Invoke();
      }
    }
    public UnitType SelectedUnitType { get; set; }
    public bool IsOpen
    {
      get => _isOpen;
      set
      {
        _isOpen = value;
        IsOpenChanged?.Invoke();
      }
    }

    public event Action IsOpenChanged;
    public event Action DesignCodeChanged;
    public event Action DisplayUnitsChanged;

    public SettingsStore()
    {
      UnitTypes = Enum.GetValues(typeof(UnitType)).Cast<UnitType>().ToList();
      DesignCodes = Enum.GetValues(typeof(DesignCode)).Cast<DesignCode>().ToList();

      ForceUnits = Enum.GetValues(typeof(ForceUnit)).Cast<ForceUnit>().ToList();
      LengthUnits = Enum.GetValues(typeof(LengthUnit)).Cast<LengthUnit>().ToList();
      StressUnits = Enum.GetValues(typeof(StressUnit)).Cast<StressUnit>().ToList();

      //SelectedUnits = new DisplayUnits(
      //  ForceUnits
      //  .Where
      //    (fu => EnumHelpers.GetAttribute<Attributes.UnitSystem>(fu).UnitType == SelectedUnitType)
      //  .ToList()
      //  .FirstOrDefault(),
      //  LengthUnits
      //  .Where
      //    (lu => EnumHelpers.GetAttribute<Attributes.UnitSystem>(lu).UnitType == SelectedUnitType)
      //  .ToList()
      //  .FirstOrDefault(),
      //  StressUnits
      //  .Where
      //    (su => EnumHelpers.GetAttribute<Attributes.UnitSystem>(su).UnitType == SelectedUnitType)
      //  .ToList()
      //  .FirstOrDefault());

      SelectedUnits = new DisplayUnits(ForceUnit.N, LengthUnit.mm, StressUnit.mPa);
    }

    public void SaveState()
    {
      throw new NotImplementedException();
    }
  }
}
