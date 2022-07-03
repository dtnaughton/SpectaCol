using SpectaCol.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Settings
{
  public class Units
  {
    public enum UnitType
    {
      Metric,
      Imperial
    }

    public enum ForceUnit
    {
      [UnitSystem(UnitType.Metric)]
      kN,
      [UnitSystem(UnitType.Metric)]
      N,
      [UnitSystem(UnitType.Imperial)]
      Kips,
      [UnitSystem(UnitType.Imperial)]
      Pounds
    }

    public enum LengthUnit
    {
      [UnitSystem(UnitType.Metric)]
      m,
      [UnitSystem(UnitType.Metric)]
      cm,
      [UnitSystem(UnitType.Metric)]
      mm,
      [UnitSystem(UnitType.Imperial)]
      Feet,
      [UnitSystem(UnitType.Imperial)]
      Inches
    }

    public enum StressUnit
    {
      [UnitSystem(UnitType.Metric)]
      mPa,
      [UnitSystem(UnitType.Metric)]
      kPa,
      [UnitSystem(UnitType.Imperial)]
      Psi,
      [UnitSystem(UnitType.Imperial)]
      Ksi
    }

    public enum MetricForceUnit
    {
      kN,
      N
    }

    public enum MetricLengthUnit
    {
      m,
      cm,
      mm
    }

    public enum MetricStressUnit
    {
      [UnitSystem(UnitType.Metric)]
      mPa,
      [UnitSystem(UnitType.Metric)]
      kPa,
      [UnitSystem(UnitType.Imperial)]
      Psi,
      [UnitSystem(UnitType.Imperial)]
      Ksi
    }

    public enum ImperialForceUnit
    {
      Kips,
      Pounds
    }

    public enum ImperialLengthUnit
    {
      Feet,
      Inches
    }

    public enum ImperialStressUnit
    {
      Psi,
      Ksi
    }
  }
}
