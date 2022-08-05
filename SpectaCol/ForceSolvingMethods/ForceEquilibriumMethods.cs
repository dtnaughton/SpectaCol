using SpectaCol.Models.Enums;
using SpectaCol.Models.Geometry;
using SpectaCol.Models.Materials;
using SpectaCol.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.ForceSolvingMethods
{
  public static class ForceEquilibriumMethods
  {
    public static double GetMaximumUtilization(Dictionary<AxialMomentPlane, List<FrameResult>> axialMomentPlanes)
    {
      var maximumUtilization = 0.0;

      foreach (var plane in axialMomentPlanes)
      {
        foreach (var frameResult in plane.Value)
        {
          if (frameResult.Utilization > maximumUtilization)
            maximumUtilization = frameResult.Utilization;
        }
      }

      return maximumUtilization;
    }
    
    // Method doesn't currently handle tension
    public static double CalculateUtilization(AxialMomentPlane axialMomentPlane, double compressionResistance, double axialForce, double momentX, double momentY)
    {
      var appliedMoment = GetResultantMoment(momentX, momentY);

      if (Math.Round(appliedMoment, MidpointRounding.AwayFromZero) == 0)
        return Math.Abs(axialForce / compressionResistance);

      var foundLowerLimit = false;

      var momentResistance = 0.0;

      for (int i = 0; i < axialMomentPlane.Points.Count; i++)
      {
        var axialValue = axialMomentPlane.Points.ElementAt(i).Key;
        foundLowerLimit = axialValue > axialForce;

        if (foundLowerLimit)
        {
          var lowerLimit = axialMomentPlane.Points.ElementAt(i - 1);
          var upperLimit = axialMomentPlane.Points.ElementAt(i);

          momentResistance = ForceEquilibriumMethods.InterpolateMomentValues(axialForce, lowerLimit, upperLimit);
          break;
        }
      }

      // If moment exceeds maximum value of NvM chart, moment resistance will be 0 and return max utilization.
      if (momentResistance == 0)
      {
        return 9999;
      }

      else
      {
        return Math.Max(Math.Abs(axialForce/compressionResistance), Math.Abs(appliedMoment/momentResistance));
      }
    }

    public static double InterpolateMomentValues(double desiredValue, KeyValuePair<double,double> firstPoint, KeyValuePair<double,double> secondPoint)
    {
      return firstPoint.Value + ((secondPoint.Value - firstPoint.Value) / (secondPoint.Key - firstPoint.Key)) * (desiredValue - firstPoint.Key);
    }

    public static Dictionary<double, double> CalculateAxialMomentFailurePlane(double compressionResistanceLimit, double externalMomentX, double externalMomentY,
      SectionShape sectionShape, CrossSectionParameters crossSectionParameters, Coordinate extremeCompressionCoordinate, DesignResults designResults,
      double concreteFailureStrain, Concrete concreteMaterial, double phiS, double phiC, LongitudinalReinforcement longitudinalReinforcement)
    {
      var axialMomentValues = new Dictionary<double, double>();

      var iterations = 25;

      for (int i = 0; i <= iterations; i++)
      {
        var externalAxialForce = compressionResistanceLimit * ((double)i / (double)iterations);

        if (i != iterations)
        {
          var momentResistance = FindNeutralAxisForAxialForce(externalAxialForce, externalMomentX, externalMomentY, sectionShape, crossSectionParameters,
                                                              extremeCompressionCoordinate, designResults, concreteFailureStrain, concreteMaterial, phiS,
                                                              phiC, longitudinalReinforcement);
          axialMomentValues.Add(externalAxialForce, momentResistance);
        }

        else
        {
          axialMomentValues.Add(compressionResistanceLimit, 0);
        }

      }

      return axialMomentValues;
    }

    public static double FindNeutralAxisForAxialForce(double externalAxialForce, double externalMomentX, double externalMomentY, SectionShape sectionShape, CrossSectionParameters crossSectionParameters,
      Coordinate extremeCompressionCoordinate, DesignResults designResults, double concreteFailureStrain,
      Concrete concreteMaterial, double phiS, double phiC,
      LongitudinalReinforcement longitudinalReinforcement)
    {
      var externalMomentRatio = GetMomentRatio(externalMomentX, externalMomentY);

      var isAngleCorrect = false;

      var checkedAngles = new Dictionary<double, double>();
      var checkedDepths = new Dictionary<double, double>();

      var tolerance = 0.002;
      var minimumAxialTolerance = 2500;
      var minimumMomentRatioTolerance = 0.001;

      double internalMomentX = 0;
      double internalMomentY = 0;

      while (!isAngleCorrect)
      {
        var isDepthCorrect = false;

        // Add check if angle (or angle very close to it) has already been checked?
        var axisAngle = GuessNeutralAxisAngle(checkedAngles, externalMomentRatio, extremeCompressionCoordinate.AngleLimit.Upper, extremeCompressionCoordinate.AngleLimit.Lower);

        var maximumAxisDepth = Geometry.MaximumNeutralAxisDepth(extremeCompressionCoordinate, longitudinalReinforcement.Rebar, axisAngle, concreteFailureStrain, longitudinalReinforcement.YieldStrength / longitudinalReinforcement.ElasticModulus);

        var canSolveAxial = true;

        while (!isDepthCorrect)
        {
          var axisDepth = GuessNeutralAxisDepth(checkedDepths, externalAxialForce, maximumAxisDepth);

          // If depths converge on a value without reaching axial force tolerance, angle must be incorrect so break loop
          if (ValuesConverged(checkedDepths, 5))
          {
            canSolveAxial = false;
          }

          var internalForces = CalculateInternalSectionForces(sectionShape, crossSectionParameters, axisAngle, axisDepth, extremeCompressionCoordinate, designResults, concreteFailureStrain, concreteMaterial, phiS, phiC, longitudinalReinforcement);

          if (internalForces.AxialForce.WithinTolerance(externalAxialForce, tolerance, minimumAxialTolerance) || !canSolveAxial)
          {
            // Moment about the x will cause internal moment to be axial x Y lever arm, so internal moment Y
            var internalMomentRatio = GetMomentRatio(internalForces.MomentX, internalForces.MomentY);

            // If angles converge, but cannot solve exactly within tolerance, answer should be sufficient enough
            if (ValuesConverged(checkedAngles, 10))
            {
              return GetResultantMoment(internalForces.MomentX, internalForces.MomentY);
            }

            if (Math.Abs(internalMomentRatio).WithinTolerance(externalMomentRatio, tolerance, minimumMomentRatioTolerance) && canSolveAxial)
            {
              isAngleCorrect = true;
              internalMomentX = internalForces.MomentX;
              internalMomentY = internalForces.MomentY;
            }

            checkedAngles.Add(axisAngle, internalMomentRatio);
            checkedDepths.Clear();

            // Axial force is correct but moment ratio (therefore angle) incorrect, so break loop on this angle guess.
            break;
          }

          else
          {
            checkedDepths.Add(axisDepth, internalForces.AxialForce);
          }
        }
      }

      if (internalMomentX == 0 && internalMomentY == 0)
      {
        throw new ArithmeticException("Unable to solve for internal moments");
      }

      return GetResultantMoment(internalMomentX, internalMomentY);
    }

    public static Coordinate FindExtremeCompressionCoordinate(CrossSectionParameters crossSectionParameters, double externalMomentX, double externalMomentY)
    {
      // Rounding to account for E- numbers from analysis results
      externalMomentX = Math.Round(externalMomentX, MidpointRounding.AwayFromZero);
      externalMomentY = Math.Round(externalMomentY, MidpointRounding.AwayFromZero);

      if (externalMomentX == 0 && externalMomentY > 0)
      {
        return new Coordinate(crossSectionParameters.Width / 2, 0);
      }

      else if (externalMomentX == 0 && externalMomentY < 0)
      {
        return new Coordinate(-crossSectionParameters.Width / 2, 0);
      }

      else if (externalMomentX > 0 && externalMomentY == 0)
      {
        return new Coordinate(0, crossSectionParameters.Depth / 2);
      }

      else if (externalMomentX < 0 && externalMomentY == 0)
      {
        return new Coordinate(0, -crossSectionParameters.Depth / 2);
      }

      else if (externalMomentX > 0 && externalMomentY > 0)
      {
        return new Coordinate(crossSectionParameters.Width/2, crossSectionParameters.Depth/2);
      }

      else if (externalMomentX > 0 && externalMomentY < 0)
      {
        return new Coordinate(crossSectionParameters.Width / 2, -crossSectionParameters.Depth / 2);
      }

      else if (externalMomentX < 0 && externalMomentY > 0)
      {
        return new Coordinate(-crossSectionParameters.Width / 2, crossSectionParameters.Depth / 2);
      }

      else if (externalMomentX < 0 && externalMomentY < 0)
      {
        return new Coordinate(-crossSectionParameters.Width / 2, -crossSectionParameters.Depth / 2);
      }

      // Edge case both moments are 0 so we can provide moment about any axis and it won't affect utilization
      else
      {
        return new Coordinate(0, crossSectionParameters.Depth / 2);
      }
    }

    public static bool ValuesConverged(Dictionary<double, double> checkedValues, int iterationLimit)
    {
      var guesses = checkedValues.Count;

      var exceedsLimit = guesses >= iterationLimit;

      // Checks if the last 3 values are the same (to 0 dp), if so, converged.
      if (exceedsLimit)
      {
        var valuesToCompare = new List<int>();

        for (int i = 1; i <= iterationLimit; i++)
        {
          valuesToCompare.Add(Convert.ToInt32(checkedValues.ElementAt(guesses - i).Key));
        }

        var allValuesEqual = false;

        for (int i = 0; i < valuesToCompare.Count - 1; i++)
        {
          allValuesEqual = valuesToCompare[i] == valuesToCompare[i + 1];
        }

        return allValuesEqual;
      }

      return false;
    }

    private static double GetMomentRatio(double numerator, double denominator)
    {
      numerator = Math.Round(numerator, MidpointRounding.AwayFromZero);
      denominator = Math.Round(denominator, MidpointRounding.AwayFromZero);

      return numerator == 0 || denominator == 0 ? 0 : numerator / denominator;
    }

    public static double GetMomentAngle(double momentX, double momentY)
    {
      var roundedMomentX = Math.Round(momentX, MidpointRounding.AwayFromZero);
      var roundedMomentY = Math.Round(momentY, MidpointRounding.AwayFromZero);

      if (roundedMomentX == 0 && roundedMomentY == 0)
        return 0;

      else if (roundedMomentX == 0 && roundedMomentY != 0)
        return 90;

      else if (roundedMomentX != 0 && roundedMomentY == 0)
        return 0;

      else
      {
        var angle = Math.Atan(momentY / momentX) * 180 / Math.PI;
        return Math.Round(angle, MidpointRounding.AwayFromZero);
      }
    }

    private static double GetResultantMoment(double momentX, double momentY)
    {
      return Math.Sqrt(Math.Pow(momentX, 2) + Math.Pow(momentY, 2));
    }

    public static bool WithinTolerance(this double value, double targetValue, double tolerancePercentage, double minimumTolerance = 0)
    {
      // If solving for P = 0, tolerance would be 0 therefore never converge on value
      var tolerance = tolerancePercentage * targetValue;

      if (tolerance == 0 || tolerance < minimumTolerance)
        tolerance = minimumTolerance;

      var difference = Math.Abs(targetValue - value);
      return difference <= tolerance;
    }

    public static double GuessNeutralAxisDepth(Dictionary<double, double> previousGuesses, double targetValue, double maxAllowable, double minAllowable = 0)
    {
      if (maxAllowable < 0)
      {
        throw new ArgumentException("Maximum allowable value should be greater than 0");
      }

      //targetValue = Math.Abs(targetValue);

      var upperLimits = new List<double>();
      var lowerLimits = new List<double>();

      foreach (var pg in previousGuesses)
      {
        if (pg.Value - targetValue >= 0)
          upperLimits.Add(pg.Key);
        else
          lowerLimits.Add(pg.Key);
      }

      var upperLimit = upperLimits.Count != 0 ? upperLimits.Min() : maxAllowable;
      var lowerLimit = lowerLimits.Count != 0 ? lowerLimits.Max() : minAllowable;

      return (upperLimit + lowerLimit) / 2;
    }

    public static double GuessNeutralAxisAngle(Dictionary<double, double> previousGuesses, double targetValue, double maxAllowable, double minAllowable = 0)
    {
      if (maxAllowable < 0)
      {
        throw new ArgumentException("Maximum allowable value should be greater than 0");
      }

      //targetValue = Math.Abs(targetValue);

      var upperLimits = new List<double>();
      var lowerLimits = new List<double>();

      foreach (var pg in previousGuesses)
      {
        if (pg.Value - targetValue < 0)
          upperLimits.Add(pg.Key);
        else
          lowerLimits.Add(pg.Key);
      }

      var upperLimit = upperLimits.Count != 0 ? upperLimits.Min() : maxAllowable;
      var lowerLimit = lowerLimits.Count != 0 ? lowerLimits.Max() : minAllowable;

      return (upperLimit + lowerLimit) / 2;
    }

    public static InternalSectionForce CalculateInternalSectionForces(SectionShape sectionShape, CrossSectionParameters crossSectionParameters, double neutralAxisAngle, double neutralAxisDepth,
      Coordinate extremeCompressionCoordinate, DesignResults designResults, double concreteFailureStrain, Concrete concreteMaterial, double phiS, double phiC,
      LongitudinalReinforcement longitudinalReinforcement)
    {
      if (sectionShape == SectionShape.SolidRectangular)
      {
        return CalculateInternalSectionForcesRectangular(crossSectionParameters, neutralAxisAngle, neutralAxisDepth, extremeCompressionCoordinate,
          designResults, concreteFailureStrain, concreteMaterial, phiS, phiC, longitudinalReinforcement);
      }

      else
      {
        return CalculateInternalSectionForcesCircular();
      }
    }

    private static InternalSectionForce CalculateInternalSectionForcesRectangular(CrossSectionParameters crossSectionParameters, double neutralAxisAngle, double neutralAxisDepth,
      Coordinate extremeCompressionCoordinate, DesignResults designResults, double concreteFailureStrain, Concrete concreteMaterial, double phiS, double phiC,
      LongitudinalReinforcement longitudinalReinforcement)
    {
      var neutralAxis = new NeutralAxis(neutralAxisDepth, neutralAxisAngle, designResults.Beta, crossSectionParameters.Width, crossSectionParameters.Depth, extremeCompressionCoordinate);

      var axialForceConcrete = CalculateInternalConcreteCompressionForce(neutralAxis.WhitneyCompressionArea, concreteMaterial.CompressiveStrength, designResults.Alpha, phiC);

      var internalMomentX = CalculateMomentFromAxial(axialForceConcrete, neutralAxis.Centroid.Y);
      var internalMomentY = CalculateMomentFromAxial(axialForceConcrete, neutralAxis.Centroid.X);

      var internalAxial = axialForceConcrete;

      foreach (var bar in longitudinalReinforcement.Rebar)
      {
        var effectiveDepth = CalculateBarEffectiveDepth(extremeCompressionCoordinate, bar.Coordinate, neutralAxisAngle);
        var strain = CalculateBarStrain(bar, concreteFailureStrain, neutralAxis.Depth, effectiveDepth, extremeCompressionCoordinate);
        var stress = CalculateBarStress(strain, longitudinalReinforcement.ElasticModulus, longitudinalReinforcement.YieldStrength, designResults.Alpha, concreteMaterial.CompressiveStrength);
        var barAxialForce = CalculateBarAxialForce(stress, longitudinalReinforcement, phiS);
        var momentX = CalculateMomentFromAxial(barAxialForce, bar.Coordinate.Y);
        var momentY = CalculateMomentFromAxial(barAxialForce, bar.Coordinate.X);

        internalAxial += barAxialForce;
        internalMomentX += momentX;
        internalMomentY += momentY;
      }

      return new InternalSectionForce(internalAxial, internalMomentX, internalMomentY);
    }

    public static double CalculateMomentFromAxial(double axialForce, double leverArm)
    {
      return axialForce * leverArm;
    }

    public static double CalculateBarAxialForce(double barStress, LongitudinalReinforcement reinforcement, double phiS)
    {
      var barArea = ForceEquilibriumMethods.GetCrossSectionalArea(reinforcement.Diameter);

      return barArea * barStress * phiS;
    }

    public static double CalculateBarStress(double barStrain, double elasticModulus, double maxBarStress, double alpha, double concreteStrength)
    {
      var barStress = barStrain * elasticModulus;

      var exceedsMax = ExceedsMaxAllowableStress(maxBarStress, barStress);

      if (InCompression(barStress))
      {
        if (exceedsMax)
        {
          barStress = maxBarStress;
        }

        barStress -= alpha * concreteStrength;
      }

      // Bar in tension
      else
      {
        if (exceedsMax)
        {
          barStress = -maxBarStress;
        }
      }

      return barStress;
    }

    private static bool InCompression(double stress)
    {
      return stress > 0;
    }

    private static bool ExceedsMaxAllowableStress(double maxStress, double stress)
    {
      return Math.Abs(stress) > Math.Abs(maxStress);
    }

    public static double CalculateBarStrain(Rebar rebar, double concreteFailureStrain, double neutralAxisDepth, double effectiveDepthBar, Coordinate extremeCompressionCoordinate)
    {
      return (concreteFailureStrain * (neutralAxisDepth - effectiveDepthBar)) / neutralAxisDepth;
    }

    public static double CalculateBarEffectiveDepth(Coordinate extremeCompressionCoordinate, Coordinate barCoordinate, double neutralAxisAngleDeg)
    {
      return Geometry.PerpendicularDistanceBetweenPointAndLine(extremeCompressionCoordinate, barCoordinate, neutralAxisAngleDeg);
    }

    private static double CalculateInternalConcreteCompressionForce(double whitneyStressArea, double concreteStrength, double alpha, double phiC)
    {
      return whitneyStressArea * concreteStrength * alpha * phiC;
    }

    private static InternalSectionForce CalculateInternalSectionForcesCircular()
    {
      throw new NotImplementedException();
    }

    public static double GetCrossSectionalArea(ReinforcementDiameter diameter)
    {
      return diameter switch
      {
        // Canadian bars
        ReinforcementDiameter.M10 => 100,
        ReinforcementDiameter.M15 => 200,
        ReinforcementDiameter.M20 => 300,
        ReinforcementDiameter.M25 => 500,
        ReinforcementDiameter.M30 => 700,
        ReinforcementDiameter.M35 => 1000,
        ReinforcementDiameter.M45 => 1500,
        ReinforcementDiameter.M55 => 2500,
        _ => throw new NotImplementedException(),
      };
    }

    public static double GetBarDiameter(ReinforcementDiameter diameter)
    {
      return diameter switch
      {
        // Canadian bars
        ReinforcementDiameter.M10 => 11.3,
        ReinforcementDiameter.M15 => 16,
        ReinforcementDiameter.M20 => 19.5,
        ReinforcementDiameter.M25 => 25.2,
        ReinforcementDiameter.M30 => 29.9,
        ReinforcementDiameter.M35 => 35.7,
        ReinforcementDiameter.M45 => 43.7,
        ReinforcementDiameter.M55 => 56.4,
        _ => throw new NotImplementedException(),
      };
    }
  }
}
