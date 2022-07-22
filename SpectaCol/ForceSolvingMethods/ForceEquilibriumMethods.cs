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
    public static Dictionary<double, double> CalculateAxialMomentFailurePlane(double compressionResistanceLimit, double externalMomentX, double externalMomentY,
      SectionShape sectionShape, CrossSectionParameters crossSectionParameters, Coordinate extremeCompressionCoordinate, DesignResults designResults,
      double concreteFailureStrain, Concrete concreteMaterial, double phiS, double phiC, LongitudinalReinforcement longitudinalReinforcement)
    {
      var axialMomentValues = new Dictionary<double, double>();

      for (double externalAxialForce = 0; externalAxialForce <= compressionResistanceLimit; externalAxialForce += 0.04 * compressionResistanceLimit)
      {
        if (externalAxialForce != compressionResistanceLimit)
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

      var oppositedCoordinateToExtreme = Geometry.ReturnOppositeCoordinate(extremeCompressionCoordinate);

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
          if (ValuesConverged(checkedDepths))
          {
            canSolveAxial = false;
          }

          var internalForces = CalculateInternalSectionForces(sectionShape, crossSectionParameters, axisAngle, axisDepth, extremeCompressionCoordinate, designResults, concreteFailureStrain, concreteMaterial, phiS, phiC, longitudinalReinforcement);

          if (internalForces.AxialForce.WithinTolerance(externalAxialForce, tolerance) || !canSolveAxial)
          {
            isDepthCorrect = true;

            // Moment about the x will cause internal moment to be axial x Y lever arm, so internal moment Y
            var internalMomentRatio = GetMomentRatio(internalForces.MomentY, internalForces.MomentX);

            // If angles converge, but cannot solve exactly within tolerance, answer should be sufficient enough
            if (AnglesConverged(checkedAngles))
            {
              return GetInternalMomentResistance(internalForces.MomentX, internalForces.MomentY);
            }

            if (Math.Abs(internalMomentRatio).WithinTolerance(externalMomentRatio, tolerance) && canSolveAxial)
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

      return GetInternalMomentResistance(internalMomentX, internalMomentY);
    }

    private static bool ValuesConverged(Dictionary<double, double> checkedValues)
    {
      var guesses = checkedValues.Count;

      var iterationLimit = 3;

      var exceedsLimit = guesses >= iterationLimit;

      // Checks if the last 3 values are the same (to 0 dp), if so, converged.
      if (exceedsLimit)
      {
        var depthOne = Convert.ToInt32(checkedValues.ElementAt(guesses - 1).Key);
        var depthTwo = Convert.ToInt32(checkedValues.ElementAt(guesses - 2).Key);
        var depthThree = Convert.ToInt32(checkedValues.ElementAt(guesses - 3).Key);

        return exceedsLimit && depthOne == depthTwo && depthTwo == depthThree;
      }

      return false;
    }

    private static bool AnglesConverged(Dictionary<double, double> checkedValues)
    {
      var guesses = checkedValues.Count;

      var iterationLimit = 6;

      var exceedsLimit = guesses >= iterationLimit;

      // Checks if the last 3 values are the same (to 0 dp), if so, converged.
      if (exceedsLimit)
      {
        var depthOne = Convert.ToInt32(checkedValues.ElementAt(guesses - 1).Key);
        var depthTwo = Convert.ToInt32(checkedValues.ElementAt(guesses - 2).Key);
        var depthThree = Convert.ToInt32(checkedValues.ElementAt(guesses - 3).Key);
        var depthFour = Convert.ToInt32(checkedValues.ElementAt(guesses - 4).Key);
        var depthFive = Convert.ToInt32(checkedValues.ElementAt(guesses - 5).Key);
        var depthSix = Convert.ToInt32(checkedValues.ElementAt(guesses - 6).Key);

        return exceedsLimit && depthOne == depthTwo && depthTwo == depthThree && depthThree == depthFour
          && depthFour == depthFive && depthFive == depthSix;
      }

      return false;
    }

    private static double GetMomentRatio(double numerator, double denominator)
    {
      var momentRatio = numerator / denominator;

      // if ratio is less than 0, return inverse as internal moments will not reach very high moment ratio values due to trig setup.
      //if (momentRatio < 0)
      //  return 1 / momentRatio;
      //else
      return momentRatio;
    }

    private static double GetInternalMomentResistance(double internalMomentX, double internalMomentY)
    {
      return Math.Sqrt(Math.Pow(internalMomentX, 2) + Math.Pow(internalMomentY, 2));
    }

    public static bool WithinTolerance(this double value, double targetValue, double tolerancePercentage)
    {
      // If solving for P = 0, tolerance would be 0 therefore never converge on value
      var tolerance = tolerancePercentage * targetValue;

      if (tolerance == 0)
        tolerance = 2500;
      return Math.Abs(targetValue - value) <= tolerance;
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

      var internalMomentX = CalculateMomentFromAxial(axialForceConcrete, neutralAxis.Centroid.X);
      var internalMomentY = CalculateMomentFromAxial(axialForceConcrete, neutralAxis.Centroid.Y);

      var internalAxial = axialForceConcrete;

      foreach (var bar in longitudinalReinforcement.Rebar)
      {
        var effectiveDepth = CalculateBarEffectiveDepth(extremeCompressionCoordinate, bar.Coordinate, neutralAxisAngle);
        var strain = CalculateBarStrain(bar, concreteFailureStrain, neutralAxis.Depth, effectiveDepth, extremeCompressionCoordinate);
        var stress = CalculateBarStress(strain, longitudinalReinforcement.ElasticModulus, longitudinalReinforcement.YieldStrength, designResults.Alpha, concreteMaterial.CompressiveStrength);
        var barAxialForce = CalculateBarAxialForce(stress, longitudinalReinforcement, phiS);
        var momentX = CalculateMomentFromAxial(barAxialForce, bar.Coordinate.X);
        var momentY = CalculateMomentFromAxial(barAxialForce, bar.Coordinate.Y);

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
      var barArea = reinforcement.GetCrossSectionalArea(reinforcement.Diameter);

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
  }
}
