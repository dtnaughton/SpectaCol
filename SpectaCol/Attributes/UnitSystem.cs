using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpectaCol.Settings.Units;

namespace SpectaCol.Attributes
{
  [AttributeUsage(AttributeTargets.All)]
  public class UnitSystem : Attribute
  {
    public UnitType UnitType { get; set; }

    public UnitSystem(UnitType unitType)
    {
      UnitType = unitType;
    }
  }
}
