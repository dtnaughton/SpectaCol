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

      var extremeCompressionCoordinate = new Coordinate(-150, 300);

      var na = new NeutralAxis(150, 30, beta, 300, 600, extremeCompressionCoordinate);

      Assert.Equal(150, na.Depth);
      Assert.Equal(30, na.Angle);
      Assert.Equal(132.375, na.WhitneyDepth);
      Assert.Equal(-150, na.StressBlockSegments[0].Coordinates[0].X, 2);
      Assert.Equal(300, na.StressBlockSegments[0].Coordinates[0].Y, 2);
      Assert.Equal(114.75, na.StressBlockSegments[0].Coordinates[1].X, 2);
      Assert.Equal(300, na.StressBlockSegments[0].Coordinates[1].Y, 2);
      Assert.Equal(-150, na.StressBlockSegments[0].Coordinates[2].X, 2);
      Assert.Equal(147.1465, na.StressBlockSegments[0].Coordinates[2].Y, 2);
      Assert.Equal(20233.9799, na.WhitneyCompressionArea, 1);
      Assert.Equal(-61.7500, na.Centroid.X, 2);
      Assert.Equal(249.0488, na.Centroid.Y, 2);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Triangular_2()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(35);

      var extremeCompressionCoordinate = new Coordinate(-250, -250);

      var na = new NeutralAxis(150, 125, beta, 500, 500, extremeCompressionCoordinate);

      Assert.Equal(132.375, na.WhitneyDepth,2);
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[0].X, 2);
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[0].Y, 2);
      Assert.Equal(-88.4, na.StressBlockSegments[0].Coordinates[1].X, 2);
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[1].Y, 2);
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[2].X, 2);
      Assert.Equal(-19.2112, na.StressBlockSegments[0].Coordinates[2].Y, 2);
      Assert.Equal(18647.7368, na.WhitneyCompressionArea, 1);
      Assert.Equal(-196.1333, na.Centroid.X, 2);
      Assert.Equal(-173.0704, na.Centroid.Y, 2);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Triangular_3()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(35);

      var extremeCompressionCoordinate = new Coordinate(250, -250);

      var na = new NeutralAxis(201, 245, beta, 500, 500, extremeCompressionCoordinate);

      Assert.Equal(177.3825, na.WhitneyDepth, 2);
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[0].X, 2);
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[0].Y, 2);
      Assert.Equal(54.2801, na.StressBlockSegments[0].Coordinates[1].X, 2);
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[1].Y, 2);
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[2].X, 2);
      Assert.Equal(169.7228, na.StressBlockSegments[0].Coordinates[2].Y, 2);
      Assert.Equal(41074.0546, na.WhitneyCompressionArea, 1);
      Assert.Equal(184.7600, na.Centroid.X, 2);
      Assert.Equal(-110.0924, na.Centroid.Y, 2);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Triangular_4()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(35);

      var extremeCompressionCoordinate = new Coordinate(250, 250);

      var na = new NeutralAxis(184, 305, beta, 500, 500, extremeCompressionCoordinate);

      Assert.Equal(162.38, na.WhitneyDepth, 2);
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[0].X, 2);
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[0].Y, 2);
      Assert.Equal(51.7706, na.StressBlockSegments[0].Coordinates[1].X, 2);
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[1].Y, 2);
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[2].X, 2);
      Assert.Equal(-33.1009, na.StressBlockSegments[0].Coordinates[2].Y, 2);
      Assert.Equal(28059.4567, na.WhitneyCompressionArea, 1);
      Assert.Equal(183.9235, na.Centroid.X, 2);
      Assert.Equal(155.6330, na.Centroid.Y, 2);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Trapezoid_1()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(35);

      var extremeCompressionCoordinate = new Coordinate(-150, 300);

      var na = new NeutralAxis(180, 30, beta, 300, 600, extremeCompressionCoordinate);

      Assert.Equal(180, na.Depth);
      Assert.Equal(30, na.Angle);
      Assert.Equal(158.85, na.WhitneyDepth);
      Assert.Equal(29046.4920, na.WhitneyCompressionArea, 1);

      // Triangle coords
      Assert.Equal(-150, na.StressBlockSegments[0].Coordinates[0].X, 2);
      Assert.Equal(289.7809, na.StressBlockSegments[0].Coordinates[0].Y, 2);
      Assert.Equal(-150, na.StressBlockSegments[0].Coordinates[1].X, 2);
      Assert.Equal(116.5758, na.StressBlockSegments[0].Coordinates[1].Y, 2);
      Assert.Equal(150, na.StressBlockSegments[0].Coordinates[2].X, 2);
      Assert.Equal(289.7809, na.StressBlockSegments[0].Coordinates[2].Y, 2);

      // Rectangle coords
      Assert.Equal(-150, na.StressBlockSegments[1].Coordinates[0].X, 2);
      Assert.Equal(300, na.StressBlockSegments[1].Coordinates[0].Y, 2);
      Assert.Equal(-150, na.StressBlockSegments[1].Coordinates[1].X, 2);
      Assert.Equal(289.7809, na.StressBlockSegments[1].Coordinates[1].Y, 2);
      Assert.Equal(150, na.StressBlockSegments[1].Coordinates[2].X, 2);
      Assert.Equal(289.7809, na.StressBlockSegments[1].Coordinates[2].Y, 2);
      Assert.Equal(150, na.StressBlockSegments[1].Coordinates[3].X, 2);
      Assert.Equal(300, na.StressBlockSegments[1].Coordinates[3].Y, 2);

      // Centroid
      Assert.Equal(-44.7227, na.Centroid.X, 2);
      Assert.Equal(238.6788, na.Centroid.Y, 2);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Trapezoid_2()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(30);

      var extremeCompressionCoordinate = new Coordinate(-150, -300);

      var na = new NeutralAxis(200, 103, beta, 300, 600, extremeCompressionCoordinate);

      Assert.Equal(200, na.Depth);
      Assert.Equal(103, na.Angle);
      Assert.Equal(179, na.WhitneyDepth);
      Assert.Equal(68668.7868, na.WhitneyCompressionArea, 1);

      // Triangle coords
      Assert.Equal(-104.8125, na.StressBlockSegments[0].Coordinates[0].X, 2);
      Assert.Equal(-300, na.StressBlockSegments[0].Coordinates[0].Y, 2);
      Assert.Equal(33.7084, na.StressBlockSegments[0].Coordinates[1].X, 2);
      Assert.Equal(-300, na.StressBlockSegments[0].Coordinates[1].Y, 2);
      Assert.Equal(-104.8125, na.StressBlockSegments[0].Coordinates[2].X, 2);
      Assert.Equal(300, na.StressBlockSegments[0].Coordinates[2].Y, 2);

      // Rectangle coords
      Assert.Equal(-150, na.StressBlockSegments[1].Coordinates[0].X, 2);
      Assert.Equal(-300, na.StressBlockSegments[1].Coordinates[0].Y, 2);
      Assert.Equal(-104.8125, na.StressBlockSegments[1].Coordinates[1].X, 2);
      Assert.Equal(-300, na.StressBlockSegments[1].Coordinates[1].Y, 2);
      Assert.Equal(-104.8125, na.StressBlockSegments[1].Coordinates[2].X, 2);
      Assert.Equal(300, na.StressBlockSegments[1].Coordinates[2].Y, 2);
      Assert.Equal(-150, na.StressBlockSegments[1].Coordinates[3].X, 2);
      Assert.Equal(300, na.StressBlockSegments[1].Coordinates[3].Y, 2);

      // Centroid
      Assert.Equal(-85.7903, na.Centroid.X, 2);
      Assert.Equal(-60.5170, na.Centroid.Y, 2);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Trapezoid_3()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(30);

      var extremeCompressionCoordinate = new Coordinate(150, -300);

      var na = new NeutralAxis(320, 213, beta, 300, 600, extremeCompressionCoordinate);

      Assert.Equal(320, na.Depth);
      Assert.Equal(213, na.Angle);
      Assert.Equal(286.4, na.WhitneyDepth);
      Assert.Equal(73224.5124, na.WhitneyCompressionArea, 1);

      // Triangle coords
      Assert.Equal(150, na.StressBlockSegments[0].Coordinates[0].X, 2);
      Assert.Equal(-153.3294, na.StressBlockSegments[0].Coordinates[0].Y, 2);
      Assert.Equal(150, na.StressBlockSegments[0].Coordinates[1].X, 2);
      Assert.Equal(41.4928, na.StressBlockSegments[0].Coordinates[1].Y, 2);
      Assert.Equal(-150, na.StressBlockSegments[0].Coordinates[2].X, 2);
      Assert.Equal(-153.3294, na.StressBlockSegments[0].Coordinates[2].Y, 2);

      // Rectangle coords
      Assert.Equal(150, na.StressBlockSegments[1].Coordinates[0].X, 2);
      Assert.Equal(-300, na.StressBlockSegments[1].Coordinates[0].Y, 2);
      Assert.Equal(150, na.StressBlockSegments[1].Coordinates[1].X, 2);
      Assert.Equal(-153.3294, na.StressBlockSegments[1].Coordinates[1].Y, 2);
      Assert.Equal(-150, na.StressBlockSegments[1].Coordinates[2].X, 2);
      Assert.Equal(-153.3294, na.StressBlockSegments[1].Coordinates[2].Y, 2);
      Assert.Equal(-150, na.StressBlockSegments[1].Coordinates[3].X, 2);
      Assert.Equal(-300, na.StressBlockSegments[1].Coordinates[3].Y, 2);

      // Centroid
      Assert.Equal(19.9546, na.Centroid.X, 2);
      Assert.Equal(-171.4798, na.Centroid.Y, 2);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Trapezoid_4()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(30);

      var extremeCompressionCoordinate = new Coordinate(150, 300);

      var na = new NeutralAxis(275, 286, beta, 300, 600, extremeCompressionCoordinate);

      Assert.Equal(275, na.Depth);
      Assert.Equal(286, na.Angle);
      Assert.Equal(246.125, na.WhitneyDepth);
      Assert.Equal(102012.0498, na.WhitneyCompressionArea, 1);

      // Triangle coords
      Assert.Equal(66.0035, na.StressBlockSegments[0].Coordinates[0].X, 2);
      Assert.Equal(300, na.StressBlockSegments[0].Coordinates[0].Y, 2);
      Assert.Equal(-106.0437, na.StressBlockSegments[0].Coordinates[1].X, 2);
      Assert.Equal(300, na.StressBlockSegments[0].Coordinates[1].Y, 2);
      Assert.Equal(66.0035, na.StressBlockSegments[0].Coordinates[2].X, 2);
      Assert.Equal(-300, na.StressBlockSegments[0].Coordinates[2].Y, 2);

      // Rectangle coords
      Assert.Equal(150, na.StressBlockSegments[1].Coordinates[0].X, 2);
      Assert.Equal(300, na.StressBlockSegments[1].Coordinates[0].Y, 2);
      Assert.Equal(66.0035, na.StressBlockSegments[1].Coordinates[1].X, 2);
      Assert.Equal(300, na.StressBlockSegments[1].Coordinates[1].Y, 2);
      Assert.Equal(66.0035, na.StressBlockSegments[1].Coordinates[2].X, 2);
      Assert.Equal(-300, na.StressBlockSegments[1].Coordinates[2].Y, 2);
      Assert.Equal(150, na.StressBlockSegments[1].Coordinates[3].X, 2);
      Assert.Equal(-300, na.StressBlockSegments[1].Coordinates[3].Y, 2);

      // Centroid
      Assert.Equal(57.7359, na.Centroid.X, 2);
      Assert.Equal(50.5961, na.Centroid.Y, 2);
    }


    [Fact]
    public void Neutral_Axis_Should_Be_Full_Compression_1()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(30);

      var extremeCompressionCoordinate = new Coordinate(-250, 250);

      var na = new NeutralAxis(600, 89, beta, 500, 500, extremeCompressionCoordinate);

      Assert.Equal(600, na.Depth);
      Assert.Equal(89, na.Angle);
      Assert.Equal(537, na.WhitneyDepth);
      Assert.Equal(250000, na.WhitneyCompressionArea, 1);

      // Rectangle coords
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[0].X, 2);
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[0].Y, 2);
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[1].X, 2);
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[1].Y, 2);
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[2].X, 2);
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[2].Y, 2);
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[3].X, 2);
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[3].Y, 2);

      // Centroid
      Assert.Equal(0, na.Centroid.X, 2);
      Assert.Equal(0, na.Centroid.Y, 2);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Rectangle_1()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(30);

      var extremeCompressionCoordinate = new Coordinate(0, 250);

      var na = new NeutralAxis(100, 0, beta, 500, 500, extremeCompressionCoordinate);

      Assert.Equal(100, na.Depth);
      Assert.Equal(0, na.Angle);
      Assert.Equal(89.5, na.WhitneyDepth);
      Assert.Equal(44750.0000, na.WhitneyCompressionArea, 1);

      // Rectangle coords
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[0].X, 2);
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[0].Y, 2);
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[1].X, 2);
      Assert.Equal(160.5, na.StressBlockSegments[0].Coordinates[1].Y, 2);
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[2].X, 2);
      Assert.Equal(160.5, na.StressBlockSegments[0].Coordinates[2].Y, 2);
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[3].X, 2);
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[3].Y, 2);

      // Centroid
      Assert.Equal(0, na.Centroid.X, 2);
      Assert.Equal(205.2500, na.Centroid.Y, 2);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Rectangle_2()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(30);

      var extremeCompressionCoordinate = new Coordinate(-250, 0);

      var na = new NeutralAxis(125, 90, beta, 500, 500, extremeCompressionCoordinate);

      Assert.Equal(125, na.Depth);
      Assert.Equal(90, na.Angle);
      Assert.Equal(111.875, na.WhitneyDepth);
      Assert.Equal(55937.5000, na.WhitneyCompressionArea, 1);

      // Rectangle coords
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[0].X, 2);
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[0].Y, 2);
      Assert.Equal(-138.1250, na.StressBlockSegments[0].Coordinates[1].X, 2);
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[1].Y, 2);
      Assert.Equal(-138.1250, na.StressBlockSegments[0].Coordinates[2].X, 2);
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[2].Y, 2);
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[3].X, 2);
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[3].Y, 2);

      // Centroid
      Assert.Equal(-194.0625, na.Centroid.X, 2);
      Assert.Equal(0, na.Centroid.Y, 2);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Rectangle_3()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(30);

      var extremeCompressionCoordinate = new Coordinate(0, -250);

      var na = new NeutralAxis(100, 180, beta, 500, 500, extremeCompressionCoordinate);

      Assert.Equal(100, na.Depth);
      Assert.Equal(180, na.Angle);
      Assert.Equal(89.5, na.WhitneyDepth);
      Assert.Equal(44750.0000, na.WhitneyCompressionArea, 1);

      // Rectangle coords
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[0].X, 2);
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[0].Y, 2);
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[1].X, 2);
      Assert.Equal(-160.5, na.StressBlockSegments[0].Coordinates[1].Y, 2);
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[2].X, 2);
      Assert.Equal(-160.5, na.StressBlockSegments[0].Coordinates[2].Y, 2);
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[3].X, 2);
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[3].Y, 2);

      // Centroid
      Assert.Equal(0, na.Centroid.X, 2);
      Assert.Equal(-205.2500, na.Centroid.Y, 2);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Rectangle_4()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(30);

      var extremeCompressionCoordinate = new Coordinate(250, 0);

      var na = new NeutralAxis(125, 270, beta, 500, 500, extremeCompressionCoordinate);

      Assert.Equal(125, na.Depth);
      Assert.Equal(270, na.Angle);
      Assert.Equal(111.875, na.WhitneyDepth);
      Assert.Equal(55937.5000, na.WhitneyCompressionArea, 1);

      // Rectangle coords
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[0].X, 2);
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[0].Y, 2);
      Assert.Equal(138.1250, na.StressBlockSegments[0].Coordinates[1].X, 2);
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[1].Y, 2);
      Assert.Equal(138.1250, na.StressBlockSegments[0].Coordinates[2].X, 2);
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[2].Y, 2);
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[3].X, 2);
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[3].Y, 2);

      // Centroid
      Assert.Equal(194.0625, na.Centroid.X, 2);
      Assert.Equal(0, na.Centroid.Y, 2);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Rectangle_5()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(30);

      var extremeCompressionCoordinate = new Coordinate(0, 250);

      var na = new NeutralAxis(100, 360, beta, 500, 500, extremeCompressionCoordinate);

      Assert.Equal(100, na.Depth);
      Assert.Equal(360, na.Angle);
      Assert.Equal(89.5, na.WhitneyDepth);
      Assert.Equal(44750.0000, na.WhitneyCompressionArea, 1);

      // Rectangle coords
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[0].X, 2);
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[0].Y, 2);
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[1].X, 2);
      Assert.Equal(160.5, na.StressBlockSegments[0].Coordinates[1].Y, 2);
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[2].X, 2);
      Assert.Equal(160.5, na.StressBlockSegments[0].Coordinates[2].Y, 2);
      Assert.Equal(-250, na.StressBlockSegments[0].Coordinates[3].X, 2);
      Assert.Equal(250, na.StressBlockSegments[0].Coordinates[3].Y, 2);

      // Centroid
      Assert.Equal(0, na.Centroid.X, 2);
      Assert.Equal(205.2500, na.Centroid.Y, 2);
    }


    [Fact]
    public void Neutral_Axis_Should_Be_Pentagon_1()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(30);

      var extremeCompressionCoordinate = new Coordinate(-150, 300);

      var na = new NeutralAxis(340, 64, beta, 300, 600, extremeCompressionCoordinate);

      Assert.Equal(340, na.Depth);
      Assert.Equal(64, na.Angle);
      Assert.Equal(304.3, na.WhitneyDepth);
      Assert.Equal(113822.3478, na.WhitneyCompressionArea, 1);

      // Triangle coords
      Assert.Equal(-104.0748, na.StressBlockSegments[0].Coordinates[0].X, 2);
      Assert.Equal(220.9305, na.StressBlockSegments[0].Coordinates[0].Y, 2);
      Assert.Equal(150, na.StressBlockSegments[0].Coordinates[1].X, 2);
      Assert.Equal(220.9305, na.StressBlockSegments[0].Coordinates[1].Y, 2);
      Assert.Equal(-104.0748, na.StressBlockSegments[0].Coordinates[2].X, 2);
      Assert.Equal(-300, na.StressBlockSegments[0].Coordinates[2].Y, 2);

      // Primary rectangle coords
      Assert.Equal(-150, na.StressBlockSegments[1].Coordinates[0].X, 2);
      Assert.Equal(300, na.StressBlockSegments[1].Coordinates[0].Y, 2);
      Assert.Equal(-104.0748, na.StressBlockSegments[1].Coordinates[1].X, 2);
      Assert.Equal(300, na.StressBlockSegments[1].Coordinates[1].Y, 2);
      Assert.Equal(-104.0748, na.StressBlockSegments[1].Coordinates[2].X, 2);
      Assert.Equal(-300, na.StressBlockSegments[1].Coordinates[2].Y, 2);
      Assert.Equal(-150, na.StressBlockSegments[1].Coordinates[3].X, 2);
      Assert.Equal(-300, na.StressBlockSegments[1].Coordinates[3].Y, 2);

      // Secondary rectangle coords
      Assert.Equal(-104.0748, na.StressBlockSegments[2].Coordinates[0].X, 2);
      Assert.Equal(300, na.StressBlockSegments[2].Coordinates[0].Y, 2);
      Assert.Equal(150, na.StressBlockSegments[2].Coordinates[1].X, 2);
      Assert.Equal(300, na.StressBlockSegments[2].Coordinates[1].Y, 2);
      Assert.Equal(-104.0748, na.StressBlockSegments[2].Coordinates[2].X, 2);
      Assert.Equal(220.9305, na.StressBlockSegments[2].Coordinates[2].Y, 2);
      Assert.Equal(150, na.StressBlockSegments[2].Coordinates[3].X, 2);
      Assert.Equal(220.9305, na.StressBlockSegments[2].Coordinates[3].Y, 2);

      // Centroid
      Assert.Equal(-37.9711, na.Centroid.X, 2);
      Assert.Equal(73.4652, na.Centroid.Y, 2);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Pentagon_2()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(30);

      var extremeCompressionCoordinate = new Coordinate(-350, -200);

      var na = new NeutralAxis(760, 113, beta, 700, 400, extremeCompressionCoordinate);

      Assert.Equal(760, na.Depth);
      Assert.Equal(113, na.Angle);
      Assert.Equal(680.2, na.WhitneyDepth);
      Assert.Equal(259832.6153, na.WhitneyCompressionArea, 1);

      // Triangle coords
      Assert.Equal(219.1524, na.StressBlockSegments[0].Coordinates[0].X, 2);
      Assert.Equal(-108.2576, na.StressBlockSegments[0].Coordinates[0].Y, 2);
      Assert.Equal(350, na.StressBlockSegments[0].Coordinates[1].X, 2);
      Assert.Equal(-108.2576, na.StressBlockSegments[0].Coordinates[1].Y, 2);
      Assert.Equal(219.1524, na.StressBlockSegments[0].Coordinates[2].X, 2);
      Assert.Equal(200, na.StressBlockSegments[0].Coordinates[2].Y, 2);

      // Primary rectangle coords
      Assert.Equal(-350, na.StressBlockSegments[1].Coordinates[0].X, 2);
      Assert.Equal(-200, na.StressBlockSegments[1].Coordinates[0].Y, 2);
      Assert.Equal(219.1524, na.StressBlockSegments[1].Coordinates[1].X, 2);
      Assert.Equal(-200, na.StressBlockSegments[1].Coordinates[1].Y, 2);
      Assert.Equal(219.1524, na.StressBlockSegments[1].Coordinates[2].X, 2);
      Assert.Equal(200, na.StressBlockSegments[1].Coordinates[2].Y, 2);
      Assert.Equal(-350, na.StressBlockSegments[1].Coordinates[3].X, 2);
      Assert.Equal(200, na.StressBlockSegments[1].Coordinates[3].Y, 2);

      // Secondary rectangle coords
      Assert.Equal(219.1524, na.StressBlockSegments[2].Coordinates[0].X, 2);
      Assert.Equal(-200, na.StressBlockSegments[2].Coordinates[0].Y, 2);
      Assert.Equal(350, na.StressBlockSegments[2].Coordinates[1].X, 2);
      Assert.Equal(-200, na.StressBlockSegments[2].Coordinates[1].Y, 2);
      Assert.Equal(219.1524, na.StressBlockSegments[2].Coordinates[2].X, 2);
      Assert.Equal(-108.2576, na.StressBlockSegments[2].Coordinates[2].Y, 2);
      Assert.Equal(350, na.StressBlockSegments[2].Coordinates[3].X, 2);
      Assert.Equal(-108.2576, na.StressBlockSegments[2].Coordinates[3].Y, 2);

      // Centroid
      Assert.Equal(-23.7806, na.Centroid.X, 2);
      Assert.Equal(-7.5480, na.Centroid.Y, 2);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Pentagon_3()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(30);

      var extremeCompressionCoordinate = new Coordinate(350, -200);

      var na = new NeutralAxis(875, 235, beta, 700, 400, extremeCompressionCoordinate);

      Assert.Equal(875, na.Depth);
      Assert.Equal(235, na.Angle);
      Assert.Equal(783.125, na.WhitneyDepth);
      Assert.Equal(279586.4997, na.WhitneyCompressionArea, 1);

      // Triangle coords
      Assert.Equal(-325.9361, na.StressBlockSegments[0].Coordinates[0].X, 2);
      Assert.Equal(165.6332, na.StressBlockSegments[0].Coordinates[0].Y, 2);
      Assert.Equal(-350, na.StressBlockSegments[0].Coordinates[1].X, 2);
      Assert.Equal(165.6332, na.StressBlockSegments[0].Coordinates[1].Y, 2);
      Assert.Equal(-325.9361, na.StressBlockSegments[0].Coordinates[2].X, 2);
      Assert.Equal(200, na.StressBlockSegments[0].Coordinates[2].Y, 2);

      // Primary rectangle coords
      Assert.Equal(350, na.StressBlockSegments[1].Coordinates[0].X, 2);
      Assert.Equal(-200, na.StressBlockSegments[1].Coordinates[0].Y, 2);
      Assert.Equal(-325.9361, na.StressBlockSegments[1].Coordinates[1].X, 2);
      Assert.Equal(-200, na.StressBlockSegments[1].Coordinates[1].Y, 2);
      Assert.Equal(-325.9361, na.StressBlockSegments[1].Coordinates[2].X, 2);
      Assert.Equal(200, na.StressBlockSegments[1].Coordinates[2].Y, 2);
      Assert.Equal(350, na.StressBlockSegments[1].Coordinates[3].X, 2);
      Assert.Equal(200, na.StressBlockSegments[1].Coordinates[3].Y, 2);

      // Secondary rectangle coords
      Assert.Equal(-325.9361, na.StressBlockSegments[2].Coordinates[0].X, 2);
      Assert.Equal(-200, na.StressBlockSegments[2].Coordinates[0].Y, 2);
      Assert.Equal(-350, na.StressBlockSegments[2].Coordinates[1].X, 2);
      Assert.Equal(-200, na.StressBlockSegments[2].Coordinates[1].Y, 2);
      Assert.Equal(-325.9361, na.StressBlockSegments[2].Coordinates[2].X, 2);
      Assert.Equal(165.6332, na.StressBlockSegments[2].Coordinates[2].Y, 2);
      Assert.Equal(-350, na.StressBlockSegments[2].Coordinates[3].X, 2);
      Assert.Equal(165.6332, na.StressBlockSegments[2].Coordinates[3].Y, 2);

      // Centroid
      Assert.Equal(0.5058, na.Centroid.X, 2);
      Assert.Equal(-0.2789, na.Centroid.Y, 2);
    }

    [Fact]
    public void Neutral_Axis_Should_Be_Pentagon_4()
    {
      var canadianCode = new CSA_A23_3_19();

      var beta = canadianCode.BetaStressBlockValue(30);

      var extremeCompressionCoordinate = new Coordinate(350, 200);

      var na = new NeutralAxis(840, 300, beta, 700, 400, extremeCompressionCoordinate);

      Assert.Equal(840, na.Depth);
      Assert.Equal(300, na.Angle);
      Assert.Equal(751.8, na.WhitneyDepth,2);
      Assert.Equal(276580.5910, na.WhitneyCompressionArea, 1);

      // Triangle coords
      Assert.Equal(-287.1638, na.StressBlockSegments[0].Coordinates[0].X, 2);
      Assert.Equal(-91.1644, na.StressBlockSegments[0].Coordinates[0].Y, 2);
      Assert.Equal(-350.0000, na.StressBlockSegments[0].Coordinates[1].X, 2);
      Assert.Equal(-91.1644, na.StressBlockSegments[0].Coordinates[1].Y, 2);
      Assert.Equal(-287.1638, na.StressBlockSegments[0].Coordinates[2].X, 2);
      Assert.Equal(-200, na.StressBlockSegments[0].Coordinates[2].Y, 2);

      // Primary rectangle coords
      Assert.Equal(350, na.StressBlockSegments[1].Coordinates[0].X, 2);
      Assert.Equal(200, na.StressBlockSegments[1].Coordinates[0].Y, 2);
      Assert.Equal(-287.1638, na.StressBlockSegments[1].Coordinates[1].X, 2);
      Assert.Equal(200, na.StressBlockSegments[1].Coordinates[1].Y, 2);
      Assert.Equal(-287.1638, na.StressBlockSegments[1].Coordinates[2].X, 2);
      Assert.Equal(-200, na.StressBlockSegments[1].Coordinates[2].Y, 2);
      Assert.Equal(350, na.StressBlockSegments[1].Coordinates[3].X, 2);
      Assert.Equal(-200, na.StressBlockSegments[1].Coordinates[3].Y, 2);

      // Secondary rectangle coords
      Assert.Equal(-287.1638, na.StressBlockSegments[2].Coordinates[0].X, 2);
      Assert.Equal(200, na.StressBlockSegments[2].Coordinates[0].Y, 2);
      Assert.Equal(-350, na.StressBlockSegments[2].Coordinates[1].X, 2);
      Assert.Equal(200, na.StressBlockSegments[2].Coordinates[1].Y, 2);
      Assert.Equal(-287.1638, na.StressBlockSegments[2].Coordinates[2].X, 2);
      Assert.Equal(-91.1644, na.StressBlockSegments[2].Coordinates[2].Y, 2);
      Assert.Equal(-350, na.StressBlockSegments[2].Coordinates[3].X, 2);
      Assert.Equal(-91.1644, na.StressBlockSegments[2].Coordinates[3].Y, 2);

      // Centroid
      Assert.Equal(4.0682, na.Centroid.X, 2);
      Assert.Equal(2.0241, na.Centroid.Y, 2);
    }

    [Fact]
    public void Individual_Stress_Block_Segment_Triangle_Valid_Parameters()
    {
      var coordinates = new List<Coordinate>()
      {
        new Coordinate(200, 0),
        new Coordinate(200, 300),
        new Coordinate(0, 0)
      };

      var segment = new StressBlockSegment(coordinates, StressBlockSegmentShape.Triangle);

      var centroid = segment.GetCentroid();

      Assert.Equal(133.3, centroid.X, 1);
      Assert.Equal(100, centroid.Y, 1);
      Assert.Equal(30000, segment.GetArea());
    }

    [Fact]
    public void Individual_Stress_Block_Segment_Triangle_Valid_Parameters_Unordered()
    {
      var coordinates = new List<Coordinate>()
      {
        new Coordinate(150, 300),
        new Coordinate(0, 0),
        new Coordinate(150, 0)
      };

      var segment = new StressBlockSegment(coordinates, StressBlockSegmentShape.Triangle);

      var centroid = segment.GetCentroid();

      Assert.Equal(100, centroid.X, 1);
      Assert.Equal(100, centroid.Y, 1);
      Assert.Equal(22500, segment.GetArea());
    }

    [Fact]
    public void Individual_Stress_Block_Segment_Triangle_Invalid_Number_Of_Coords_Throws_Exception()
    {
      var coordinates = new List<Coordinate>()
      {
        new Coordinate(150, 300),
        new Coordinate(0, 0),
        new Coordinate(150, 0),
        new Coordinate(150, 200)
      };

      Assert.Throws<ArgumentException>(() =>
      {
        new StressBlockSegment(coordinates, StressBlockSegmentShape.Triangle);
      });
    }

    [Fact]
    public void Individual_Stress_Block_Segment_Triangle_Invalid_Number_Of_Distinct_X_Coords_Throws_Exception()
    {
      var coordinates = new List<Coordinate>()
      {
        new Coordinate(150, 300),
        new Coordinate(0, 0),
        new Coordinate(100, 0),
      };

      Assert.Throws<ArgumentException>(() =>
      {
        new StressBlockSegment(coordinates, StressBlockSegmentShape.Triangle);
      });
    }

    [Fact]
    public void Individual_Stress_Block_Segment_Triangle_Invalid_Number_Of_Distinct_Y_Coords_Throws_Exception()
    {
      var coordinates = new List<Coordinate>()
      {
        new Coordinate(150, 300),
        new Coordinate(0, 0),
        new Coordinate(150, 150),
      };

      Assert.Throws<ArgumentException>(() =>
      {
        new StressBlockSegment(coordinates, StressBlockSegmentShape.Triangle);
      });
    }

    [Fact]
    public void Individual_Stress_Block_Segment_Rectangle_Valid_Parameters()
    {
      var coordinates = new List<Coordinate>()
      {
        new Coordinate(200, 0),
        new Coordinate(200, 300),
        new Coordinate(0, 300),
        new Coordinate(0, 0)
      };

      var segment = new StressBlockSegment(coordinates, StressBlockSegmentShape.Rectangle);

      var centroid = segment.GetCentroid();

      Assert.Equal(100, centroid.X, 1);
      Assert.Equal(150, centroid.Y, 1);
      Assert.Equal(60000, segment.GetArea());
    }

    [Fact]
    public void Individual_Stress_Block_Segment_Rectangle_Valid_Parameters_Unordered()
    {
      var coordinates = new List<Coordinate>()
      {
        new Coordinate(150, 300),
        new Coordinate(0, 0),
        new Coordinate(150, 0),
        new Coordinate(0, 300)
      };

      var segment = new StressBlockSegment(coordinates, StressBlockSegmentShape.Rectangle);

      var centroid = segment.GetCentroid();

      Assert.Equal(75, centroid.X, 1);
      Assert.Equal(150, centroid.Y, 1);
      Assert.Equal(45000, segment.GetArea());
    }

    [Fact]
    public void Individual_Stress_Block_Segment_Rectangle_Invalid_Number_Of_Coords_Throws_Exception()
    {
      var coordinates = new List<Coordinate>()
      {
        new Coordinate(150, 300),
        new Coordinate(0, 0),
        new Coordinate(150, 0),
      };

      Assert.Throws<ArgumentException>(() =>
      {
        new StressBlockSegment(coordinates, StressBlockSegmentShape.Rectangle);
      });
    }

    [Fact]
    public void Individual_Stress_Block_Segment_Rectangle_Invalid_Number_Of_Distinct_X_Coords_Throws_Exception()
    {
      var coordinates = new List<Coordinate>()
      {
        new Coordinate(150, 300),
        new Coordinate(0, 0),
        new Coordinate(100, 0),
        new Coordinate(125, 300),
      };

      Assert.Throws<ArgumentException>(() =>
      {
        new StressBlockSegment(coordinates, StressBlockSegmentShape.Triangle);
      });
    }

    [Fact]
    public void Individual_Stress_Block_Segment_Rectangle_Invalid_Number_Of_Distinct_Y_Coords_Throws_Exception()
    {
      var coordinates = new List<Coordinate>()
      {
        new Coordinate(150, 300),
        new Coordinate(0, 0),
        new Coordinate(150, 150),
        new Coordinate(0, 200),
      };

      Assert.Throws<ArgumentException>(() =>
      {
        new StressBlockSegment(coordinates, StressBlockSegmentShape.Triangle);
      });
    }
  }
}

