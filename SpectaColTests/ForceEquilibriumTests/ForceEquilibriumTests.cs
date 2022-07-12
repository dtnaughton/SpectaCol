using SpectaCol.ForceSolvingMethods;
using SpectaCol.Models.DesignCodes;
using SpectaCol.Models.Enums;
using SpectaCol.Models.Geometry;
using SpectaCol.Models.Materials;
using SpectaCol.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpectaColTests.ForceEquilibriumTests
{
  public class ForceEquilibriumTests
  {
    [Fact]
    public void Calculate_Rebar_Effective_Depth_Positive()
    {
      var point = new Coordinate(100, 125);

      var referencePoint = new Coordinate(300, 300);

      var effectiveDepth = ForceEquilibriumMethods.DistanceBetweenCoordinates(referencePoint, point);

      Assert.Equal(265.75, effectiveDepth, 2);
    }

    [Fact]
    public void Calculate_Rebar_Effective_Depth_Negative()
    {
      var point = new Coordinate(100, 125);

      var referencePoint = new Coordinate(-300, -300);

      var effectiveDepth = ForceEquilibriumMethods.DistanceBetweenCoordinates(referencePoint, point);

      Assert.Equal(583.63, effectiveDepth, 2);
    }

    [Fact]
    public void Calculate_Rebar_Strain_Negative()
    {
      var rebar = new Rebar(new Coordinate(100, 100));

      var extremeCompressionPoint = new Coordinate(400, 450);

      var barStrain = ForceEquilibriumMethods.CalculateBarStrain(rebar, 0.0035, 100, extremeCompressionPoint);

      Assert.Equal(-0.0126, barStrain, 4);
    }

    [Fact]
    public void Calculate_Rebar_Strain_Positive()
    {
      var rebar = new Rebar(new Coordinate(100, 100));

      var extremeCompressionPoint = new Coordinate(50, 50);

      var barStrain = ForceEquilibriumMethods.CalculateBarStrain(rebar, 0.0035, 200, extremeCompressionPoint);

      Assert.Equal(0.00226, barStrain, 5);
    }

    [Fact]
    public void Calculate_Rebar_Positive_Stress()
    {
      var barStrain = 0.0015;
      var alpha = 0.805;
      var concreteStrength = 30;
      var barStress = ForceEquilibriumMethods.CalculateBarStress(barStrain, 200000, 400, alpha, concreteStrength);

      Assert.Equal(275.85, barStress);
    }

    [Fact]
    public void Calculate_Rebar_Negative_Stress()
    {
      var barStrain = -0.0015;
      var alpha = 0.805;
      var concreteStrength = 30;
      var barStress = ForceEquilibriumMethods.CalculateBarStress(barStrain, 200000, 400, alpha, concreteStrength);

      Assert.Equal(-300, barStress);
    }

    [Fact]
    public void Calculate_Rebar_Positive_Stress_Max()
    {
      var barStrain = 0.015;
      var alpha = 0.805;
      var concreteStrength = 30;
      var barStress = ForceEquilibriumMethods.CalculateBarStress(barStrain, 200000, 400, alpha, concreteStrength);

      Assert.Equal(375.85, barStress);
    }

    [Fact]
    public void Calculate_Rebar_Negative_Stress_Min()
    {
      var barStrain = -0.015;
      var alpha = 0.805;
      var concreteStrength = 30;
      var barStress = ForceEquilibriumMethods.CalculateBarStress(barStrain, 200000, 400, alpha, concreteStrength);

      Assert.Equal(-400, barStress);
    }

    [Fact]
    public void Calculate_Bar_Axial_Force_Positive()
    {
      var barStress = 200;
      var reinforcement = new LongitudinalReinforcement(new CrossSectionParameters());
      var phiS = 0.85;
      reinforcement.Diameter = ReinforcementDiameter.M30;

      var barAxialForce = ForceEquilibriumMethods.CalculateBarAxialForce(barStress, reinforcement, phiS);

      Assert.Equal(119000, barAxialForce);
    }

    [Fact]
    public void Calculate_Bar_Axial_Force_Negative()
    {
      var barStress = -215;
      var reinforcement = new LongitudinalReinforcement(new CrossSectionParameters());
      reinforcement.Diameter = ReinforcementDiameter.M30;
      var phiS = 0.85;

      var barAxialForce = ForceEquilibriumMethods.CalculateBarAxialForce(barStress, reinforcement, phiS);

      Assert.Equal(-127925, barAxialForce);
    }

    [Fact]
    public void Internal_Moment_Ratio_Check()
    {
      var crossSectionParameters = new CrossSectionParameters(450, 500, 30);
      var neutralAxisAngle = 37.3;
      var extremeCompressionCoordinate = new Coordinate(-225, 250);
      var neutralAxisDepth = 194;
      var designCode = new CSA_A23_3_19();
      var concreteMaterial = new Concrete();
      var alpha = designCode.AlphaStressBlockValue(concreteMaterial.CompressiveStrength);
      var beta = designCode.BetaStressBlockValue(concreteMaterial.CompressiveStrength);
      var designResults = new DesignResults() { Alpha = alpha, Beta = beta };
      var concreteFailureStrain = designCode.ConcreteFailureStrain;
      var longitudinalReinforcement = new LongitudinalReinforcement(4, 5, 1, ReinforcementConfiguration.Rectangular, 400, ReinforcementDiameter.M25, crossSectionParameters, ReinforcementDiameter.M10);

      var internalMomentRatio = ForceEquilibriumMethods.InternalMomentRatio(SectionShape.SolidRectangular, crossSectionParameters, neutralAxisAngle, neutralAxisDepth,
        extremeCompressionCoordinate, designResults, concreteFailureStrain, concreteMaterial, designCode.PhiS, designCode.PhiC, longitudinalReinforcement);

      Assert.Equal(0.6998, internalMomentRatio, 4);
    }
  }
}
