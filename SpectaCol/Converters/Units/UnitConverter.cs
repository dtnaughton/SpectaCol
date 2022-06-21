using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpectaCol.Settings.Units;

namespace SpectaCol.Converters.Units
{
  public class UnitConverter : IUnitConverter
  {
    public double GetLengthScaleFactor(LengthUnit currentLengthUnit, LengthUnit updatedLengthUnit)
    {
      double currentValue;
      double updatedValue;

      switch (currentLengthUnit)
      {
        case LengthUnit.m:
          currentValue = 1000;
          break;
        case LengthUnit.cm:
          currentValue = 10;
          break;
        case LengthUnit.mm:
          currentValue = 1;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {updatedLengthUnit} unit type.");
      }

      switch (updatedLengthUnit)
      {
        case LengthUnit.m:
          updatedValue = 1000;
          break;
        case LengthUnit.cm:
          updatedValue = 100;
          break;
        case LengthUnit.mm:
          updatedValue = 1;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {updatedLengthUnit} unit type.");
      }

      return currentValue / updatedValue;
    }

    public double GetForceScaleFactor(ForceUnit currentForceUnit, ForceUnit updatedForceUnit)
    {
      double currentValue;
      double updatedValue;

      switch (currentForceUnit)
      {
        case ForceUnit.kN:
          currentValue = 1000;
          break;
        case ForceUnit.N:
          currentValue = 1;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {updatedForceUnit} unit type.");
      }


      switch (updatedForceUnit)
      {
        case ForceUnit.kN:
          updatedValue = 1000;
          break;
        case ForceUnit.N:
          updatedValue = 1;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {updatedForceUnit} unit type.");
      }

      return currentValue / updatedValue;
    }
  }
}
