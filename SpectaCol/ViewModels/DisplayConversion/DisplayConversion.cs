using SpectaCol.Converters.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpectaCol.Settings.Units;

namespace SpectaCol.ViewModels.DisplayConversion
{
  public static class DisplayConversion
  {
    public static double DisplayRounding(this double value, int significantFigures)
    {
      return Math.Round(value, significantFigures);
    }

    // Change to -> this double value, add second parameter for selected unit and backend unit
    public static double BackendForceConversion(this double value, ForceUnit selectedForceUnit, ForceUnit backendForceUnit)
    {
      return value * UnitConverter.UnitScaleFactor(selectedForceUnit, backendForceUnit);
    }

    public static double BackendLengthConversion(this double value, LengthUnit selectedLengthUnit, LengthUnit backendLengthUnit)
    {
      return value * UnitConverter.UnitScaleFactor(selectedLengthUnit, backendLengthUnit);
    }

    public static double BackendStressConversion(this double value, StressUnit selectedStressUnit, StressUnit backendStressUnit)
    {
      return value * UnitConverter.UnitScaleFactor(selectedStressUnit, backendStressUnit);
    }

    public static double FrontendForceConversion(this double value, ForceUnit backendForceUnit, ForceUnit selectedForceUnit)
    {
      return value * UnitConverter.UnitScaleFactor(backendForceUnit, selectedForceUnit);
    }

    public static double FrontendLengthConversion(this double value, LengthUnit backendLengthUnit, LengthUnit selectedLengthUnit)
    {
      return value * UnitConverter.UnitScaleFactor(backendLengthUnit, selectedLengthUnit);
    }

    public static double FrontendStressConversion(this double value, StressUnit backendStressUnit, StressUnit selectedStressUnit)
    {
      return value * UnitConverter.UnitScaleFactor(backendStressUnit, selectedStressUnit);
    }
  }
}
