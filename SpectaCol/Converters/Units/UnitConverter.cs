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
    public static double MetricToImperialScaleFactor(MetricLengthUnit metricUnit, ImperialLengthUnit imperialUnit)
    {
      double currentValue;
      double updatedValue;

      switch (metricUnit)
      {
        case MetricLengthUnit.m:
          currentValue = 1000;
          break;
        case MetricLengthUnit.cm:
          currentValue = 10;
          break;
        case MetricLengthUnit.mm:
          currentValue = 1;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {metricUnit} unit type.");
      }

      switch (imperialUnit)
      {
        case ImperialLengthUnit.Inches:
          updatedValue = 25.4;
          break;
        case ImperialLengthUnit.Feet:
          updatedValue = 304.8;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {imperialUnit} unit type.");
      }

      return currentValue / updatedValue;
    }

    public static double ImperialToMetricScaleFactor(ImperialLengthUnit imperialUnit, MetricLengthUnit metricUnit)
    {
      double currentValue;
      double updatedValue;

      switch (imperialUnit)
      {
        case ImperialLengthUnit.Inches:
          currentValue = 1;
          break;
        case ImperialLengthUnit.Feet:
          currentValue = 12;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {imperialUnit} unit type.");
      }

      switch (metricUnit)
      {
        case MetricLengthUnit.m:
          updatedValue = 1/0.0254;
          break;
        case MetricLengthUnit.cm:
          updatedValue = 1/2.54;
          break;
        case MetricLengthUnit.mm:
          updatedValue = 1/25.4;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {metricUnit} unit type.");
      }
      return currentValue / updatedValue;
    }

    public static double MetricScaleFactor(MetricLengthUnit currentLengthUnit, MetricLengthUnit updatedLengthUnit)
    {
      double currentValue;
      double updatedValue;

      switch (currentLengthUnit)
      {
        case MetricLengthUnit.m:
          currentValue = 1000;
          break;
        case MetricLengthUnit.cm:
          currentValue = 10;
          break;
        case MetricLengthUnit.mm:
          currentValue = 1;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {currentLengthUnit} unit type.");
      }

      switch (updatedLengthUnit)
      {
        case MetricLengthUnit.m:
          updatedValue = 1000;
          break;
        case MetricLengthUnit.cm:
          updatedValue = 10;
          break;
        case MetricLengthUnit.mm:
          updatedValue = 1;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {updatedLengthUnit} unit type.");
      }

      return currentValue / updatedValue;
    }

    public static double ImperialScaleFactor(ImperialLengthUnit currentLengthUnit, ImperialLengthUnit updatedLengthUnit)
    {
      double currentValue;
      double updatedValue;

      switch (currentLengthUnit)
      {
        case ImperialLengthUnit.Inches:
          currentValue = 1;
          break;
        case ImperialLengthUnit.Feet:
          currentValue = 12;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {currentLengthUnit} unit type.");
      }

      switch (updatedLengthUnit)
      {
        case ImperialLengthUnit.Inches:
          updatedValue = 1;
          break;
        case ImperialLengthUnit.Feet:
          updatedValue = 12;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {currentLengthUnit} unit type.");
      }

      return currentValue / updatedValue;
    }
    #endregion

    #region Force Conversion

    public static double MetricToImperialScaleFactor(MetricForceUnit metricUnit, ImperialForceUnit imperialUnit)
    {
      double currentValue;
      double updatedValue;

      switch (metricUnit)
      {
        case MetricForceUnit.kN:
          currentValue = 1000;
          break;
        case MetricForceUnit.N:
          currentValue = 1;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {metricUnit} unit type.");
      }

      switch (imperialUnit)
      {
        case ImperialForceUnit.Pounds:
          updatedValue = 1/ 0.2248089431;
          break;
        case ImperialForceUnit.Kips:
          updatedValue = 1/ 0.0002248089431;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {imperialUnit} unit type.");
      }

      return currentValue / updatedValue;
    }

    public static double ImperialToMetricScaleFactor(ImperialForceUnit imperialUnit, MetricForceUnit metricUnit)
    {
      double currentValue;
      double updatedValue;

      switch (imperialUnit)
      {
        case ImperialForceUnit.Pounds:
          currentValue = 1;
          break;
        case ImperialForceUnit.Kips:
          currentValue = 1000;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {imperialUnit} unit type.");
      }

      switch (metricUnit)
      {
        case MetricForceUnit.kN:
          updatedValue = 1/ 0.0044482216153;
          break;
        case MetricForceUnit.N:
          updatedValue = 1/ 4.4482216153;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {metricUnit} unit type.");
      }
      return currentValue / updatedValue;
    }

    public static double MetricScaleFactor(MetricForceUnit currentForceUnit, MetricForceUnit updatedForceUnit)
    {
      double currentValue;
      double updatedValue;

      switch (currentForceUnit)
      {
        case MetricForceUnit.kN:
          currentValue = 1000;
          break;
        case MetricForceUnit.N:
          currentValue = 1;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {currentForceUnit} unit type.");
      }

      switch (updatedForceUnit)
      {
        case MetricForceUnit.kN:
          updatedValue = 1000;
          break;
        case MetricForceUnit.N:
          updatedValue = 1;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {updatedForceUnit} unit type.");
      }

      return currentValue / updatedValue;
    }

    public static double ImperialScaleFactor(ImperialForceUnit currentForceUnit, ImperialForceUnit updatedForceUnit)
    {
      double currentValue;
      double updatedValue;

      switch (currentForceUnit)
      {
        case ImperialForceUnit.Kips:
          currentValue = 1000;
          break;
        case ImperialForceUnit.Pounds:
          currentValue = 1;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {currentForceUnit} unit type.");
      }

      switch (updatedForceUnit)
      {
        case ImperialForceUnit.Kips:
          updatedValue = 1000;
          break;
        case ImperialForceUnit.Pounds:
          updatedValue = 1;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {currentForceUnit} unit type.");
      }

      return currentValue / updatedValue;
    }
    #endregion

    #region Stress Conversion

    public static double MetricToImperialScaleFactor(MetricStressUnit metricUnit, ImperialStressUnit imperialUnit)
    {
      double currentValue;
      double updatedValue;

      switch (metricUnit)
      {
        case MetricStressUnit.kPa:
          currentValue = 0.001;
          break;
        case MetricStressUnit.mPa:
          currentValue = 1;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {metricUnit} unit type.");
      }

      switch (imperialUnit)
      {
        case ImperialStressUnit.Ksi:
          updatedValue = 1/0.1450377377;
          break;
        case ImperialStressUnit.Psi:
          updatedValue = 1/145.03773773;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {imperialUnit} unit type.");
      }

      return currentValue / updatedValue;
    }

    public static double ImperialToMetricScaleFactor(ImperialStressUnit imperialUnit, MetricStressUnit metricUnit)
    {
      double currentValue;
      double updatedValue;

      switch (imperialUnit)
      {
        case ImperialStressUnit.Ksi:
          currentValue = 1000;
          break;
        case ImperialStressUnit.Psi:
          currentValue = 1;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {imperialUnit} unit type.");
      }

      switch (metricUnit)
      {
        case MetricStressUnit.kPa:
          updatedValue = 1 / 6.8947572932;
          break;
        case MetricStressUnit.mPa:
          updatedValue = 1 / 0.0068947573;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {metricUnit} unit type.");
      }
      return currentValue / updatedValue;
    }

    public static double MetricScaleFactor(MetricStressUnit currentForceUnit, MetricStressUnit updatedForceUnit)
    {
      double currentValue;
      double updatedValue;

      switch (currentForceUnit)
      {
        case MetricStressUnit.kPa:
          currentValue = 0.001;
          break;
        case MetricStressUnit.mPa:
          currentValue = 1;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {currentForceUnit} unit type.");
      }

      switch (updatedForceUnit)
      {
        case MetricStressUnit.kPa:
          updatedValue = 0.001;
          break;
        case MetricStressUnit.mPa:
          updatedValue = 1;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {updatedForceUnit} unit type.");
      }

      return currentValue / updatedValue;
    }

    public static double ImperialScaleFactor(ImperialStressUnit currentForceUnit, ImperialStressUnit updatedForceUnit)
    {
      double currentValue;
      double updatedValue;

      switch (currentForceUnit)
      {
        case ImperialStressUnit.Ksi:
          currentValue = 1000;
          break;
        case ImperialStressUnit.Psi:
          currentValue = 1;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {currentForceUnit} unit type.");
      }

      switch (updatedForceUnit)
      {
        case ImperialStressUnit.Ksi:
          updatedValue = 1000;
          break;
        case ImperialStressUnit.Psi:
          updatedValue = 1;
          break;
        default:
          throw new NotImplementedException($"Unable to convert {currentForceUnit} unit type.");
      }

      return currentValue / updatedValue;
    }
    #endregion
  }
}
