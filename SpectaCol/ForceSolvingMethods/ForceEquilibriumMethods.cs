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
    public static double InternalMomentRatio(SectionShape sectionShape)
    {
      if (sectionShape == SectionShape.SolidRectangular)
      {
        //return InternalMomentRatioRectangularSection();
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




      return 0;
    }

    private static double InternalMomentRatioCircularSection()
    {
      throw new NotImplementedException();
    }
  }
}
