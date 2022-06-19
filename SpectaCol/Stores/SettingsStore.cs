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

    public List<LengthUnit> LengthUnits { get; }
    public LengthUnit SelectedLengthUnit { get; set; }
    public List<ForceUnit> ForceUnits { get; }
    public ForceUnit SelectedForceUnit { get; set; }
    public List<DesignCode> DesignCodes { get; }
    public DesignCode SelectedDesignCode { get; set; }

    public SettingsStore()
    {
      LengthUnits = Enum.GetValues(typeof(LengthUnit)).Cast<LengthUnit>().ToList();
      ForceUnits = Enum.GetValues(typeof(ForceUnit)).Cast<ForceUnit>().ToList();
      DesignCodes = Enum.GetValues(typeof(DesignCode)).Cast<DesignCode>().ToList();
    }

    public void SaveState()
    {
      throw new NotImplementedException();
    }
  }
}
