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
    public void Get_Moment_Angle_X_Only()
    {
      var theta = ForceEquilibriumMethods.GetMomentAngle(100, 0);
      Assert.Equal(0, theta);
    }

    [Fact]
    public void Get_Moment_Angle_Y_Only()
    {
      var theta = ForceEquilibriumMethods.GetMomentAngle(0, 100);
      Assert.Equal(90, theta);
    }

    [Fact]
    public void Get_Moment_Angle()
    {
      var theta = ForceEquilibriumMethods.GetMomentAngle(100, 100);
      Assert.Equal(45, theta);
    }

    [Fact]
    public void Find_Extreme_Compression_Point_PositiveX_PositiveY()
    {
      var crossSection = new CrossSectionParameters(400, 400, 40);
      var compressionCoord = ForceEquilibriumMethods.FindExtremeCompressionCoordinate(crossSection, 100, 100);

      Assert.Equal(crossSection.Width / 2, compressionCoord.X);
      Assert.Equal(crossSection.Depth / 2, compressionCoord.Y);
    }

    [Fact]
    public void Find_Extreme_Compression_Point_PositiveX_NegativeY()
    {
      var crossSection = new CrossSectionParameters(400, 400, 40);
      var compressionCoord = ForceEquilibriumMethods.FindExtremeCompressionCoordinate(crossSection, 100, -100);

      Assert.Equal(crossSection.Width / 2, compressionCoord.X);
      Assert.Equal(-crossSection.Depth / 2, compressionCoord.Y);
    }

    [Fact]
    public void Find_Extreme_Compression_Point_NegativeX_PositiveY()
    {
      var crossSection = new CrossSectionParameters(400, 400, 40);
      var compressionCoord = ForceEquilibriumMethods.FindExtremeCompressionCoordinate(crossSection, -100, 100);

      Assert.Equal(-crossSection.Width / 2, compressionCoord.X);
      Assert.Equal(crossSection.Depth / 2, compressionCoord.Y);
    }

    [Fact]
    public void Find_Extreme_Compression_Point_NegativeX_NegativeY()
    {
      var crossSection = new CrossSectionParameters(400, 400, 40);
      var compressionCoord = ForceEquilibriumMethods.FindExtremeCompressionCoordinate(crossSection, -100, -100);

      Assert.Equal(-crossSection.Width / 2, compressionCoord.X);
      Assert.Equal(-crossSection.Depth / 2, compressionCoord.Y);
    }

    [Fact]
    public void Find_Extreme_Compression_Point_ZeroX_PositiveY()
    {
      var crossSection = new CrossSectionParameters(400, 400, 40);
      var compressionCoord = ForceEquilibriumMethods.FindExtremeCompressionCoordinate(crossSection, 0, 100);

      Assert.Equal(crossSection.Width/2, compressionCoord.X);
      Assert.Equal(0, compressionCoord.Y);
    }

    [Fact]
    public void Find_Extreme_Compression_Point_ZeroX_NegativeY()
    {
      var crossSection = new CrossSectionParameters(400, 400, 40);
      var compressionCoord = ForceEquilibriumMethods.FindExtremeCompressionCoordinate(crossSection, 0, -100);

      Assert.Equal(-crossSection.Width / 2, compressionCoord.X);
      Assert.Equal(0, compressionCoord.Y);
    }

    [Fact]
    public void Find_Extreme_Compression_Point_PositiveX_ZeroY()
    {
      var crossSection = new CrossSectionParameters(400, 400, 40);
      var compressionCoord = ForceEquilibriumMethods.FindExtremeCompressionCoordinate(crossSection, 100, 0);

      Assert.Equal(0, compressionCoord.X);
      Assert.Equal(crossSection.Depth/2, compressionCoord.Y);
    }

    [Fact]
    public void Find_Extreme_Compression_Point_NegativeX_ZeroY()
    {
      var crossSection = new CrossSectionParameters(400, 400, 40);
      var compressionCoord = ForceEquilibriumMethods.FindExtremeCompressionCoordinate(crossSection, -100, 0);

      Assert.Equal(0, compressionCoord.X);
      Assert.Equal(-crossSection.Depth / 2, compressionCoord.Y);
    }

    [Fact]
    public void Find_Extreme_Compression_Point_ZeroX_ZeroY()
    {
      var crossSection = new CrossSectionParameters(400, 400, 40);
      var compressionCoord = ForceEquilibriumMethods.FindExtremeCompressionCoordinate(crossSection, 0, 0);

      Assert.Equal(0, compressionCoord.X);
      Assert.Equal(0, compressionCoord.Y);
    }

    [Fact]
    public void Calculate_Rebar_Effective_Depth_Positive()
    {
      var point = new Coordinate(100, 125);

      var referencePoint = new Coordinate(300, 300);

      var effectiveDepth = Geometry.DistanceBetweenCoordinates(referencePoint, point);

      Assert.Equal(265.75, effectiveDepth, 2);
    }

    [Fact]
    public void Calculate_Rebar_Effective_Depth_Negative()
    {
      var point = new Coordinate(100, 125);

      var referencePoint = new Coordinate(-300, -300);

      var effectiveDepth = Geometry.DistanceBetweenCoordinates(referencePoint, point);

      Assert.Equal(583.63, effectiveDepth, 2);
    }

    [Fact]
    public void Calculate_Rebar_Strain_Negative()
    {
      var rebar = new Rebar(new Coordinate(171.1, -196.1));

      var extremeCompressionPoint = new Coordinate(-225, 250);

      var barStrain = ForceEquilibriumMethods.CalculateBarStrain(rebar, 0.0035, 194, 594.8927, extremeCompressionPoint);

      Assert.Equal(-0.007233, barStrain, 4);
    }

    [Fact]
    public void Calculate_Rebar_Strain_Positive()
    {
      var rebar = new Rebar(new Coordinate(-171.1, 196.1));

      var extremeCompressionPoint = new Coordinate(-225, 250);

      var barStrain = ForceEquilibriumMethods.CalculateBarStrain(rebar, 0.0035, 194, 75.5388, extremeCompressionPoint);

      Assert.Equal(0.002137, barStrain, 5);
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
    public void Calculate_Bar_Effective_Depth_0_to_90()
    {
      var extremeCompression = new Coordinate(225, 250);
      var barCoordinate = new Coordinate(-171.1000, -196.1000);

      var effectiveDepth = ForceEquilibriumMethods.CalculateBarEffectiveDepth(extremeCompression, barCoordinate, 37.3);

      Assert.Equal(594.8927, effectiveDepth, 2);
    }

    [Fact]
    public void Calculate_Bar_Effective_Depth_90_to_180()
    {
      var extremeCompression = new Coordinate(225, -250);
      var barCoordinate = new Coordinate(171.1, 98.0500);

      var effectiveDepth = ForceEquilibriumMethods.CalculateBarEffectiveDepth(extremeCompression, barCoordinate, 106.4);

      Assert.Equal(149.9760, effectiveDepth, 2);
    }

    [Fact]
    public void Calculate_Bar_Effective_Depth_180_to_270()
    {
      var extremeCompression = new Coordinate(-225, -250);
      var barCoordinate = new Coordinate(-171.1000, 98.0500);

      var effectiveDepth = ForceEquilibriumMethods.CalculateBarEffectiveDepth(extremeCompression, barCoordinate, 269);

      Assert.Equal(59.9661, effectiveDepth, 2);
    }

    [Fact]
    public void Calculate_Bar_Effective_Depth_270_to_360()
    {
      var extremeCompression = new Coordinate(-225, 250);
      var barCoordinate = new Coordinate(171.1000, -196.1000);

      var effectiveDepth = ForceEquilibriumMethods.CalculateBarEffectiveDepth(extremeCompression, barCoordinate, 315);

      Assert.Equal(595.5253, effectiveDepth, 2);
    }

    [Fact]
    public void Within_Tolerance_Should_Be_True()
    {
      var number = 398569.23;

      Assert.True(number.WithinTolerance(400000, 0.02));
    }

    [Fact]
    public void Within_Tolerance_Should_Be_False()
    {
      var number = 409000.213;

      Assert.False(number.WithinTolerance(400000, 0.02));
    }

    [Fact]
    public void Calculate_Neutral_Axis_For_Specified_Axial()
    {
      var crossSection = new CrossSectionParameters(400, 400, 40);
      var extremeCompressionPoint = new Coordinate(200, 200);
      var designCode = new CSA_A23_3_19();
      var material = new Concrete();
      material.SetDefaultParameters();
      var designResults = new DesignResults()
      {
        Alpha = designCode.AlphaStressBlockValue(material.CompressiveStrength),
        Beta = designCode.BetaStressBlockValue(material.CompressiveStrength)
      };
      var longReinf = new LongitudinalReinforcement(2, 2, 1, ReinforcementConfiguration.Rectangular, 400, 200000, ReinforcementDiameter.M20, crossSection, ReinforcementDiameter.M10);

      var internalMomentCapacity = ForceEquilibriumMethods.FindNeutralAxisForAxialForce(406106.8, 100000000, 100000000, SectionShape.SolidRectangular, crossSection, extremeCompressionPoint, designResults, designCode.ConcreteFailureStrain,
        material, designCode.PhiS, designCode.PhiC, longReinf);

      var withinTolernace = internalMomentCapacity.WithinTolerance(124000000, 0.02);

      Assert.True(withinTolernace);
    }

    // Note - results compared in excel plot to S-Concrete
    [Fact]
    public void Calculate_Axial_Moment_Failure_Plane_1()
    {
      var crossSection = new CrossSectionParameters(400, 400, 40);
      var extremeCompressionPoint = new Coordinate(200, 200);
      var axialForce = 2875000;
      var momentX = 200000000;
      var momentY = 100000000;
      var designCode = new CSA_A23_3_19();
      var material = new Concrete();
      material.SetDefaultParameters();
      var designResults = new DesignResults()
      {
        Alpha = designCode.AlphaStressBlockValue(material.CompressiveStrength),
        Beta = designCode.BetaStressBlockValue(material.CompressiveStrength)
      };
      var longReinf = new LongitudinalReinforcement(2, 2, 1, ReinforcementConfiguration.Rectangular, 400, 200000, ReinforcementDiameter.M20, crossSection, ReinforcementDiameter.M10);

      var axialMomentResults = ForceEquilibriumMethods.CalculateAxialMomentFailurePlane(axialForce, momentX, momentY, SectionShape.SolidRectangular, crossSection, extremeCompressionPoint, designResults,
        designCode.ConcreteFailureStrain, material, designCode.PhiS, designCode.PhiC, longReinf);
    }

    // Note - results compared in excel plot to S-Concrete
    [Fact]
    public void Calculate_Axial_Moment_Failure_Plane_2()
    {
      var crossSection = new CrossSectionParameters(300, 900, 30);
      var extremeCompressionPoint = new Coordinate(150, 450);
      var axialForce = 6375000;
      var momentX = 250000000;
      var momentY = 35000000;
      var designCode = new CSA_A23_3_19();
      var material = new Concrete();
      material.CompressiveStrength = 35;
      var designResults = new DesignResults()
      {
        Alpha = designCode.AlphaStressBlockValue(material.CompressiveStrength),
        Beta = designCode.BetaStressBlockValue(material.CompressiveStrength)
      };
      var longReinf = new LongitudinalReinforcement(3, 7, 1, ReinforcementConfiguration.Rectangular, 400, 200000, ReinforcementDiameter.M20, crossSection, ReinforcementDiameter.M10);

      var axialMomentResults = ForceEquilibriumMethods.CalculateAxialMomentFailurePlane(axialForce, momentX, momentY, SectionShape.SolidRectangular, crossSection, extremeCompressionPoint, designResults,
        designCode.ConcreteFailureStrain, material, designCode.PhiS, designCode.PhiC, longReinf);
    }

    //// Note - results compared in excel plot to S-Concrete
    [Fact]
    public void Calculate_Axial_Moment_Failure_Plane_3()
    {
      var crossSection = new CrossSectionParameters(1000, 500, 30);
      var extremeCompressionPoint = new Coordinate(-500, 250);
      var axialForce = 13203450;
      var momentX = -34000000;
      var momentY = 234000000;
      var designCode = new CSA_A23_3_19();
      var material = new Concrete();
      material.CompressiveStrength = 40;
      var designResults = new DesignResults()
      {
        Alpha = designCode.AlphaStressBlockValue(material.CompressiveStrength),
        Beta = designCode.BetaStressBlockValue(material.CompressiveStrength)
      };
      var longReinf = new LongitudinalReinforcement(7, 5, 2, ReinforcementConfiguration.Rectangular, 400, 200000, ReinforcementDiameter.M20, crossSection, ReinforcementDiameter.M10);

      var axialMomentResults = ForceEquilibriumMethods.CalculateAxialMomentFailurePlane(axialForce, momentX, momentY, SectionShape.SolidRectangular, crossSection, extremeCompressionPoint, designResults,
        designCode.ConcreteFailureStrain, material, designCode.PhiS, designCode.PhiC, longReinf);
    }

    //// Note - results compared in excel plot to S-Concrete
    [Fact]
    public void Calculate_Axial_Moment_Failure_Plane_4()
    {
      var crossSection = new CrossSectionParameters(650, 450, 30);
      var extremeCompressionPoint = new Coordinate(crossSection.Width/2, -crossSection.Depth/2);
      var axialForce = 8300000;
      var momentX = -56000000;
      var momentY = 254000000;
      var designCode = new CSA_A23_3_19();
      var material = new Concrete();
      material.CompressiveStrength = 35;
      var designResults = new DesignResults()
      {
        Alpha = designCode.AlphaStressBlockValue(material.CompressiveStrength),
        Beta = designCode.BetaStressBlockValue(material.CompressiveStrength)
      };
      var longReinf = new LongitudinalReinforcement(7, 5, 2, ReinforcementConfiguration.Rectangular, 400, 200000, ReinforcementDiameter.M20, crossSection, ReinforcementDiameter.M10);

      var axialMomentResults = ForceEquilibriumMethods.CalculateAxialMomentFailurePlane(axialForce, momentX, momentY, SectionShape.SolidRectangular, crossSection, extremeCompressionPoint, designResults,
        designCode.ConcreteFailureStrain, material, designCode.PhiS, designCode.PhiC, longReinf);
    }

    //// Note - results compared in excel plot to S-Concrete
    [Fact]
    public void Calculate_Axial_Moment_Failure_Plane_5()
    {
      var crossSection = new CrossSectionParameters(300, 1200, 30);
      var extremeCompressionPoint = new Coordinate(-crossSection.Width / 2, -crossSection.Depth / 2);
      var axialForce = 9330000;
      var momentX = -100000000;
      var momentY = -350000000;
      var designCode = new CSA_A23_3_19();
      var material = new Concrete();
      material.CompressiveStrength = 35;
      var designResults = new DesignResults()
      {
        Alpha = designCode.AlphaStressBlockValue(material.CompressiveStrength),
        Beta = designCode.BetaStressBlockValue(material.CompressiveStrength)
      };
      var longReinf = new LongitudinalReinforcement(3, 6, 2, ReinforcementConfiguration.Rectangular, 400, 200000, ReinforcementDiameter.M25, crossSection, ReinforcementDiameter.M10);

      var axialMomentResults = ForceEquilibriumMethods.CalculateAxialMomentFailurePlane(axialForce, momentX, momentY, SectionShape.SolidRectangular, crossSection, extremeCompressionPoint, designResults,
        designCode.ConcreteFailureStrain, material, designCode.PhiS, designCode.PhiC, longReinf);
    }

    //// Note - results compared in excel plot to S-Concrete
    [Fact]
    public void Calculate_Axial_Moment_Failure_Plane_About_X_Only()
    {
      var crossSection = new CrossSectionParameters(400, 400, 40);
      var extremeCompressionPoint = new Coordinate(0, crossSection.Depth / 2);
      var axialForce = 3500000;
      var momentX = 200000000;
      var momentY = 0;
      var designCode = new CSA_A23_3_19();
      var material = new Concrete();
      material.CompressiveStrength = 35;
      var designResults = new DesignResults()
      {
        Alpha = designCode.AlphaStressBlockValue(material.CompressiveStrength),
        Beta = designCode.BetaStressBlockValue(material.CompressiveStrength)
      };
      var longReinf = new LongitudinalReinforcement(2, 2, 1, ReinforcementConfiguration.Rectangular, 400, 200000, ReinforcementDiameter.M25, crossSection, ReinforcementDiameter.M10);

      var axialMomentResults = ForceEquilibriumMethods.CalculateAxialMomentFailurePlane(axialForce, momentX, momentY, SectionShape.SolidRectangular, crossSection, extremeCompressionPoint, designResults,
        designCode.ConcreteFailureStrain, material, designCode.PhiS, designCode.PhiC, longReinf);
    }

    //// Note - results compared in excel plot to S-Concrete
    [Fact]
    public void Calculate_Axial_Moment_Failure_Plane_About_Y_Only()
    {
      var crossSection = new CrossSectionParameters(400, 400, 40);
      var extremeCompressionPoint = new Coordinate(-crossSection.Width/2, 0);
      var axialForce = 3820000;
      var momentX = 0;
      var momentY = -110000000;
      var designCode = new CSA_A23_3_19();
      var material = new Concrete();
      material.CompressiveStrength = 35;
      var designResults = new DesignResults()
      {
        Alpha = designCode.AlphaStressBlockValue(material.CompressiveStrength),
        Beta = designCode.BetaStressBlockValue(material.CompressiveStrength)
      };
      var longReinf = new LongitudinalReinforcement(2, 3, 1, ReinforcementConfiguration.Rectangular, 400, 200000, ReinforcementDiameter.M25, crossSection, ReinforcementDiameter.M10);

      var axialMomentResults = ForceEquilibriumMethods.CalculateAxialMomentFailurePlane(axialForce, momentX, momentY, SectionShape.SolidRectangular, crossSection, extremeCompressionPoint, designResults,
        designCode.ConcreteFailureStrain, material, designCode.PhiS, designCode.PhiC, longReinf);
    }

    [Fact]
    public void Internal_Section_Forces_Check_1()
    {
      var crossSectionParameters = new CrossSectionParameters(450, 500, 30);
      var neutralAxisAngle = 37.3;
      var extremeCompressionCoordinate = new Coordinate(225, 250);
      var neutralAxisDepth = 194;
      var designCode = new CSA_A23_3_19();
      var concreteMaterial = new Concrete();
      concreteMaterial.SetDefaultParameters();
      var alpha = designCode.AlphaStressBlockValue(concreteMaterial.CompressiveStrength);
      var beta = designCode.BetaStressBlockValue(concreteMaterial.CompressiveStrength);
      var designResults = new DesignResults() { Alpha = alpha, Beta = beta };
      var concreteFailureStrain = designCode.ConcreteFailureStrain;
      var longitudinalReinforcement = new LongitudinalReinforcement(4, 5, 1, ReinforcementConfiguration.Rectangular, 400, 200000, ReinforcementDiameter.M25, crossSectionParameters, ReinforcementDiameter.M10);

      var internalSectionForces = ForceEquilibriumMethods.CalculateInternalSectionForces(SectionShape.SolidRectangular, crossSectionParameters, neutralAxisAngle, neutralAxisDepth,
        extremeCompressionCoordinate, designResults, concreteFailureStrain, concreteMaterial, designCode.PhiS, designCode.PhiC, longitudinalReinforcement);

      Assert.Equal(-816450.316813881, internalSectionForces.AxialForce, 0);
      Assert.Equal(1.4336, internalSectionForces.MomentX / internalSectionForces.MomentY, 4);
    }

   // [Fact]
   // public void Internal_Section_Forces_Check_2()
   // {
   //   var crossSectionParameters = new CrossSectionParameters(300, 900, 30);
   //   var neutralAxisAngle = 311.5;
   //   var extremeCompressionCoordinate = new Coordinate(-150, 450);
   //   var neutralAxisDepth = 240;
   //   var designCode = new CSA_A23_3_19();
   //   var concreteMaterial = new Concrete();
   //   concreteMaterial.CompressiveStrength = 35;
   //   var alpha = designCode.AlphaStressBlockValue(concreteMaterial.CompressiveStrength);
   //   var beta = designCode.BetaStressBlockValue(concreteMaterial.CompressiveStrength);
   //   var designResults = new DesignResults() { Alpha = alpha, Beta = beta };
   //   var concreteFailureStrain = designCode.ConcreteFailureStrain;
   //   var longitudinalReinforcement = new LongitudinalReinforcement(3, 7, 1, ReinforcementConfiguration.Rectangular, 400, 200000, ReinforcementDiameter.M20, crossSectionParameters, ReinforcementDiameter.M10);

   //   var internalSectionForces = ForceEquilibriumMethods.CalculateInternalSectionForces(SectionShape.SolidRectangular, crossSectionParameters, neutralAxisAngle, neutralAxisDepth,
   //     extremeCompressionCoordinate, designResults, concreteFailureStrain, concreteMaterial, designCode.PhiS, designCode.PhiC, longitudinalReinforcement);

   //   Assert.Equal(-9398.59342, internalSectionForces.AxialForce, 0);
   //   Assert.Equal(-0.14, internalSectionForces.MomentX / internalSectionForces.MomentY, 2);
   //}

    [Fact]
    public void Finds_Average_Higher_And_Lower_For_NA_Depth_Populated_Values()
    {
      var fakeGuesses = new Dictionary<double, double>();
      var maxAllowable = 400;
      var targetValue = 400;

      fakeGuesses.Add(200, 200);
      fakeGuesses.Add(300, 300);
      fakeGuesses.Add(350, 420);
      fakeGuesses.Add(325, 405);
      fakeGuesses.Add(312.5, 350);

      var nextGuess = ForceEquilibriumMethods.GuessNeutralAxisDepth(fakeGuesses, targetValue, maxAllowable);

      Assert.Equal(318.75, nextGuess);
    }

    [Fact]
    public void Finds_Average_Higher_And_Lower_For_NA_Depth_Unpopulated_Values()
    {
      var fakeGuesses = new Dictionary<double, double>();
      var maxAllowable = 400;
      var targetValue = 400;

      var nextGuess = ForceEquilibriumMethods.GuessNeutralAxisDepth(fakeGuesses, targetValue, maxAllowable);

      Assert.Equal(200, nextGuess);
    }

    [Fact]
    public void Finds_Average_Higher_And_Lower_For_NA_Depth_Onesided_Values()
    {
      var fakeGuesses = new Dictionary<double, double>();
      var maxAllowable = 400;
      var targetValue = 400;

      fakeGuesses.Add(200, 200);
      fakeGuesses.Add(300, 300);
      fakeGuesses.Add(350, 310);

      var nextGuess = ForceEquilibriumMethods.GuessNeutralAxisDepth(fakeGuesses, targetValue, maxAllowable);

      Assert.Equal(375, nextGuess);
    }

    [Fact]
    public void Guess_Neutral_Axis_Value_Returns_Argument_Exception()
    {
      Assert.Throws<ArgumentException>(() =>
      {
        var nextGuess = ForceEquilibriumMethods.GuessNeutralAxisDepth(new Dictionary<double, double>(), 400, - 500);
      });

    }

    [Fact]
    public void First_Neutral_Axis_Guess()
    {
      var previousGuesses = new Dictionary<double, double>();

      var naDepth = ForceEquilibriumMethods.GuessNeutralAxisDepth(previousGuesses, 200, 450);

      Assert.Equal(225, naDepth);
    }

    [Fact]
    public void Second_Neutral_Axis_Guess()
    {
      var previousGuesses = new Dictionary<double, double>();
      previousGuesses.Add(225, 100);
      var naDepth = ForceEquilibriumMethods.GuessNeutralAxisDepth(previousGuesses, 200, 450);

      Assert.Equal(337.5, naDepth);
    }

    [Fact]
    public void Values_Should_Converge()
    {
      var mockedGuesses = new Dictionary<double, double>();
      mockedGuesses.Add(320.401, 320.401);
      mockedGuesses.Add(320.432425, 320.432425);
      mockedGuesses.Add(320.41234, 320.41234);

      var valuesConverged = ForceEquilibriumMethods.ValuesConverged(mockedGuesses, 3);

      Assert.True(valuesConverged);
    }

    [Fact]
    public void Values_Should_Not_Converge_Not_Enough_Guesses()
    {
      var mockedGuesses = new Dictionary<double, double>();
      mockedGuesses.Add(320.401, 320.401);
      mockedGuesses.Add(320.432425, 320.432425);
      mockedGuesses.Add(320.41234, 320.41234);

      var valuesConverged = ForceEquilibriumMethods.ValuesConverged(mockedGuesses, 4);

      Assert.False(valuesConverged);
    }

    [Fact]
    public void Values_Should_Not_Converge()
    {
      var mockedGuesses = new Dictionary<double, double>();
      mockedGuesses.Add(320.401, 320.401);
      mockedGuesses.Add(323.432425, 320.432425);
      mockedGuesses.Add(325.41234, 320.41234);

      var valuesConverged = ForceEquilibriumMethods.ValuesConverged(mockedGuesses, 4);

      Assert.False(valuesConverged);
    }
  }
}
