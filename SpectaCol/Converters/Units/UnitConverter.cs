using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpectaCol.Settings.Units;

namespace SpectaCol.Converters.Units
{
  public static class UnitConverter
  {
    public static bool IsMetric(this UnitType unitType)
    {
      return unitType == UnitType.Metric;
    }

    #region Length Conversion
    public static double UnitScaleFactor(LengthUnit currentUnit, LengthUnit nextUnit)
    {
      double currentValue;
      double updatedValue;

      switch (currentUnit)
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
        case LengthUnit.Inches:
          currentValue = 25.4;
          break;
        case LengthUnit.Feet:
          currentValue = 304.8;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {currentUnit} unit type.");
      }

      switch (nextUnit)
      {
        case LengthUnit.m:
          updatedValue = 1000;
          break;
        case LengthUnit.cm:
          updatedValue = 10;
          break;
        case LengthUnit.mm:
          updatedValue = 1;
          break;
        case LengthUnit.Inches:
          updatedValue = 25.4;
          break;
        case LengthUnit.Feet:
          updatedValue = 304.8;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {nextUnit} unit type.");
      }

      return currentValue / updatedValue;
    }
    #endregion

    #region Force Conversion
    public static double UnitScaleFactor(ForceUnit currentUnit, ForceUnit nextUnit)
    {
      double currentValue;
      double updatedValue;

      switch (currentUnit)
      {
        case ForceUnit.kN:
          currentValue = 1000;
          break;
        case ForceUnit.N:
          currentValue = 1;
          break;
        case ForceUnit.Pounds:
          currentValue = 1 / 0.2248089431;
          break;
        case ForceUnit.Kips:
          currentValue = 1 / 0.0002248089431;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {currentUnit} unit type.");
      }

      switch (nextUnit)
      {
        case ForceUnit.kN:
          updatedValue = 1000;
          break;
        case ForceUnit.N:
          updatedValue = 1;
          break;
        case ForceUnit.Pounds:
          updatedValue = 1 / 0.2248089431;
          break;
        case ForceUnit.Kips:
          updatedValue = 1 / 0.0002248089431;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {nextUnit} unit type.");
      }

      return currentValue / updatedValue;
    }
    #endregion

    #region Stress Conversion
    public static double UnitScaleFactor(StressUnit currentUnit, StressUnit nextUnit)
    {
      double currentValue;
      double updatedValue;

      switch (currentUnit)
      {
        case StressUnit.kPa:
          currentValue = 0.001;
          break;
        case StressUnit.mPa:
          currentValue = 1;
          break;
        case StressUnit.Ksi:
          currentValue = 1 / 0.1450377377;
          break;
        case StressUnit.Psi:
          currentValue = 1 / 145.03773773;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {currentUnit} unit type.");
      }

      switch (nextUnit)
      {
        case StressUnit.kPa:
          updatedValue = 0.001;
          break;
        case StressUnit.mPa:
          updatedValue = 1;
          break;
        case StressUnit.Ksi:
          updatedValue = 1 / 0.1450377377;
          break;
        case StressUnit.Psi:
          updatedValue = 1 / 145.03773773;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {nextUnit} unit type.");
      }

      return currentValue / updatedValue;
    }
    #endregion
  }
}
