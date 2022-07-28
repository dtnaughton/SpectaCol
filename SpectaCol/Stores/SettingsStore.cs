using SpectaCol.Converters.Units;
using SpectaCol.Extensions;
using SpectaCol.Models.DesignCodes;
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
    private DisplayUnits _selectedUnits;
    private IDesignCode _selectedDesignCode;

    public int UnitSettingsToChange { get; set; }
    public List<UnitType> UnitTypes { get; }
    public List<IDesignCode> DesignCodes { get; } = new List<IDesignCode>();

    public List<ForceUnit> ForceUnits { get; } = new List<ForceUnit>();
    public List<LengthUnit> LengthUnits { get; } = new List<LengthUnit>();
    public List<StressUnit> StressUnits { get; } = new List<StressUnit>();
    public bool IsCompressionNegative { get; set; }

    public DisplayUnits SelectedUnits
    {
      get => _selectedUnits;
      set
      {
        _selectedUnits = value;
        DisplayUnitsChanged?.Invoke();
      }
    }

    public IDesignCode SelectedDesignCode
    {
      get => _selectedDesignCode;
      set
      {
        _selectedDesignCode = value;
        DesignCodeChanged?.Invoke();
      }
    }

    public UnitType SelectedUnitType { get; set; }

    public event Action DesignCodeChanged;
    public event Action DisplayUnitsChanged;

    public SettingsStore()
    {
      UnitTypes = Enum.GetValues(typeof(UnitType)).Cast<UnitType>().ToList();

      SetDesignCodes();

      ForceUnits = Enum.GetValues(typeof(ForceUnit)).Cast<ForceUnit>().ToList();
      LengthUnits = Enum.GetValues(typeof(LengthUnit)).Cast<LengthUnit>().ToList();
      StressUnits = Enum.GetValues(typeof(StressUnit)).Cast<StressUnit>().ToList();

      SelectedUnits = new DisplayUnits(ForceUnit.N, LengthUnit.mm, StressUnit.mPa);

      IsCompressionNegative = true;
    }

    private void SetDesignCodes()
    {
      var designCodeTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()).Where(t => typeof(IDesignCode).IsAssignableFrom(t)).ToList();

      DesignCodes.Clear();

      foreach (var type in designCodeTypes)
      {
        if (type != typeof(IDesignCode))
        {
          IDesignCode? code = (IDesignCode?)Activator.CreateInstance(type);

          if (code != null)
          {
            DesignCodes.Add(code);
          }
        }
      }

      if (DesignCodes.Count > 0)
      {
        IDesignCode? defaultCode = DesignCodes.FirstOrDefault(dc => dc.Title == DesignCode.A23319);

        if (defaultCode is not null)
        {
          SelectedDesignCode = defaultCode;
        }
      }

    }

    public void SaveState()
    {
      throw new NotImplementedException();
    }
  }
}
