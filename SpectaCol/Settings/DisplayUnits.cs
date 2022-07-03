using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpectaCol.Settings.Units;

namespace SpectaCol.Settings
{
  public class DisplayUnits
  {
    public ForceUnit ForceUnit { get; set; }
    public LengthUnit LengthUnit { get; set; }
    public StressUnit StressUnit { get; set; }
    public DisplayUnits(ForceUnit forceUnit, LengthUnit lengthUnit, StressUnit stressUnit)
    {
      ForceUnit = forceUnit;
      LengthUnit = lengthUnit;
      StressUnit = stressUnit;
    }
  }
}
