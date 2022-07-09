using SpectaCol.Models.DesignCodes;
using SpectaCol.Models.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpectaColTests.ForceEquilibriumTests
{
  public class NeutralAxisTests
  {
    [Fact]
    public void Neutral_Axis_Should_Be_Triangular_1()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(35);

      var na = new NeutralAxis(150, 30, beta, 300, 600);

      Assert.Equal(150, na.Depth);
      Assert.Equal(30, na.Angle);
      Assert.Equal(132.375, na.WhitneyDepth);
      Assert.Equal(StressBlockShape.Triangle, na.StressBlockShape);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Triangular_2()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(35);

      var na = new NeutralAxis(150, 125, beta, 500, 500);

      Assert.Equal(StressBlockShape.Triangle, na.StressBlockShape);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Trapezoid_1()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(35);

      var na = new NeutralAxis(180, 30, beta, 300, 600);

      Assert.Equal(180, na.Depth);
      Assert.Equal(30, na.Angle);
      Assert.Equal(158.85, na.WhitneyDepth);
      Assert.Equal(StressBlockShape.Trapezoid, na.StressBlockShape);
      Assert.Equal(29046.4920, na.WhitneyCompressionArea, 1);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Trapezoid_2()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(30);

      var na = new NeutralAxis(200, 78, beta, 300, 600);

      Assert.Equal(179, na.WhitneyDepth);
      Assert.Equal(StressBlockShape.Trapezoid, na.StressBlockShape);
      Assert.Equal(71539.1988, na.WhitneyCompressionArea, 1);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Trapezoid_3()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(30);

      var na = new NeutralAxis(323.77318, 75, beta, 300, 600);

      Assert.Equal(289.8, na.WhitneyDepth, 1);
      Assert.Equal(StressBlockShape.Trapezoid, na.StressBlockShape);
      Assert.Equal(131768.6, na.WhitneyCompressionArea, 0);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Rectangle_1()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(30);

      var na = new NeutralAxis(600, 89, beta, 500, 500);

      Assert.Equal(StressBlockShape.Rectangle, na.StressBlockShape);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Trapezoid_4()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(30);

      var na = new NeutralAxis(600, 180, beta, 500, 500);

      Assert.Equal(StressBlockShape.Trapezoid, na.StressBlockShape);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Rectangle_2()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(30);

      var na = new NeutralAxis(730, 341, beta, 500, 500);

      Assert.Equal(StressBlockShape.Rectangle, na.StressBlockShape);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Rectangle_3()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(30);

      var na = new NeutralAxis(720, 250, beta, 500, 500);

      Assert.Equal(StressBlockShape.Rectangle, na.StressBlockShape);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Pentagon_1()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(30);

      var na = new NeutralAxis(340, 64, beta, 300, 600);

      Assert.Equal(304.3, na.WhitneyDepth, 1);
      Assert.Equal(StressBlockShape.Pentagon, na.StressBlockShape);
    }

  }
}
