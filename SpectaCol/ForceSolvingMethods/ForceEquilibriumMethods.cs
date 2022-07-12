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
    public static double InternalMomentRatio(SectionShape sectionShape, CrossSectionParameters crossSectionParameters, double neutralAxisAngle, double neutralAxisDepth,
      Coordinate extremeCompressionCoordinate, DesignResults designResults, double concreteFailureStrain, Concrete concreteMaterial, double phiS, double phiC,
      LongitudinalReinforcement longitudinalReinforcemen)
    {
      if (sectionShape == SectionShape.SolidRectangular)
      {
        return InternalMomentRatioRectangularSection(crossSectionParameters, neutralAxisAngle, neutralAxisDepth, extremeCompressionCoordinate,
          designResults, concreteFailureStrain, concreteMaterial, phiS, phiC, longitudinalReinforcemen);
      }

      else
      {
        return InternalMomentRatioCircularSection();
      }

      return 0;
    }

    private static double InternalMomentRatioRectangularSection(CrossSectionParameters crossSectionParameters, double neutralAxisAngle, double neutralAxisDepth, 
      Coordinate extremeCompressionCoordinate, DesignResults designResults, double concreteFailureStrain, Concrete concreteMaterial, double phiS, double phiC, 
      LongitudinalReinforcement longitudinalReinforcement)
    {
      var neutralAxis = new NeutralAxis(neutralAxisDepth, neutralAxisAngle, designResults.Beta, crossSectionParameters.Width, crossSectionParameters.Depth, extremeCompressionCoordinate);

      var axialForceConcrete = CalculateInternalConcreteCompressionForce(neutralAxis.WhitneyCompressionArea, concreteMaterial.CompressiveStrength, designResults.Alpha, phiC);

      var internalMomentX = CalculateMomentFromAxial(axialForceConcrete, neutralAxis.Centroid.X);
      var internalMomentY = CalculateMomentFromAxial(axialForceConcrete, neutralAxis.Centroid.Y);

      foreach (var bar in longitudinalReinforcement.Rebar)
      {
        var effectiveDepth = DistanceBetweenCoordinates(extremeCompressionCoordinate, bar.Coordinate);
        var strain = CalculateBarStrain(bar, concreteFailureStrain, neutralAxis.Depth, extremeCompressionCoordinate);
        var stress = CalculateBarStress(strain, longitudinalReinforcement.ElasticModulus, longitudinalReinforcement.YieldStrength, designResults.Alpha, concreteMaterial.CompressiveStrength);
        var axialForce = CalculateBarAxialForce(stress, longitudinalReinforcement, phiS);
        var momentX = CalculateMomentFromAxial(axialForce, bar.Coordinate.X);
        var momentY = CalculateMomentFromAxial(axialForce, bar.Coordinate.Y);

        internalMomentX += momentX;
        internalMomentY += momentY;
      }

      return internalMomentX / internalMomentY;
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
      return Math.Abs(stress) >  Math.Abs(maxStress);
    }

    public static double CalculateBarStrain(Rebar rebar, double concreteFailureStrain, double neutralAxisDepth, Coordinate extremeCompressionCoordinate)
    {
      var effectiveDepthBar = DistanceBetweenCoordinates(rebar.Coordinate, extremeCompressionCoordinate);

      return (concreteFailureStrain * (neutralAxisDepth - effectiveDepthBar)) / neutralAxisDepth;
    }

    public static double DistanceBetweenCoordinates(Coordinate referencePoint, Coordinate point)
    {
      return Math.Sqrt(Math.Pow(referencePoint.X - point.X, 2) + Math.Pow(referencePoint.Y - point.Y, 2));
    }

    private static double CalculateInternalConcreteCompressionForce(double whitneyStressArea, double concreteStrength, double alpha, double phiC)
    {
      return whitneyStressArea * concreteStrength * alpha * phiC;
    }

    private static double InternalMomentRatioCircularSection()
    {
      throw new NotImplementedException();
    }
  }
}
