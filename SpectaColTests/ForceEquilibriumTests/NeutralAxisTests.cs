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
    //[Fact]
    //public void Neutral_Axis_Should_Be_Triangular_1()
    //{
    //  var canadianCode = new CSA_A23_3_19();

    //  var beta = canadianCode.BetaStressBlockValue(35);

    //  var na = new NeutralAxis(150, 30, beta, 300, 600);

    //  Assert.Equal(150, na.Depth);
    //  Assert.Equal(30, na.Angle);
    //  Assert.Equal(132.375, na.WhitneyDepth);
    //  Assert.Equal(StressBlockShape.Triangle, na.StressBlockShape);
    //  Assert.Equal(20233.9799, na.WhitneyCompressionArea, 1);
    //}

    //[Fact]
    //public void Neutral_Axis_Should_Be_Triangular_2()
    //{
    //  var canadianCode = new CSA_A23_3_19();

    //  var beta = canadianCode.BetaStressBlockValue(35);

    //  var na = new NeutralAxis(150, 125, beta, 500, 500);

    //  Assert.Equal(StressBlockShape.Triangle, na.StressBlockShape);
    //  Assert.Equal(18647.7368, na.WhitneyCompressionArea, 1);
    //}

    //[Fact]
    //public void Neutral_Axis_Should_Be_Trapezoid_1()
    //{
    //  var canadianCode = new CSA_A23_3_19();

    //  var beta = canadianCode.BetaStressBlockValue(35);

    //  var na = new NeutralAxis(180, 30, beta, 300, 600);

    //  Assert.Equal(180, na.Depth);
    //  Assert.Equal(30, na.Angle);
    //  Assert.Equal(158.85, na.WhitneyDepth);
    //  Assert.Equal(StressBlockShape.Trapezoid, na.StressBlockShape);
    //  Assert.Equal(29046.4920, na.WhitneyCompressionArea, 1);
    //}

    //[Fact]
    //public void Neutral_Axis_Should_Be_Trapezoid_2()
    //{
    //  var canadianCode = new CSA_A23_3_19();

    //  var beta = canadianCode.BetaStressBlockValue(30);

    //  var na = new NeutralAxis(200, 78, beta, 300, 600);

    //  Assert.Equal(179, na.WhitneyDepth);
    //  Assert.Equal(StressBlockShape.Trapezoid, na.StressBlockShape);
    //  Assert.Equal(71539.1988, na.WhitneyCompressionArea, 1);
    //}

    //[Fact]
    //public void Neutral_Axis_Should_Be_Trapezoid_3()
    //{
    //  var canadianCode = new CSA_A23_3_19();

    //  var beta = canadianCode.BetaStressBlockValue(30);

    //  var na = new NeutralAxis(323.77318, 75, beta, 300, 600);

    //  Assert.Equal(289.8, na.WhitneyDepth, 1);
    //  Assert.Equal(StressBlockShape.Trapezoid, na.StressBlockShape);
    //  Assert.Equal(131768.6, na.WhitneyCompressionArea, 0);
    //}

    //[Fact]
    //public void Neutral_Axis_Should_Be_Rectangle_1()
    //{
    //  var canadianCode = new CSA_A23_3_19();

    //  var beta = canadianCode.BetaStressBlockValue(30);

    //  var na = new NeutralAxis(600, 89, beta, 500, 500);

    //  Assert.Equal(StressBlockShape.Rectangle, na.StressBlockShape);
    //  Assert.Equal(250000, na.WhitneyCompressionArea);
    //}

    //[Fact]
    //public void Neutral_Axis_Should_Be_Rectangle_2()
    //{
    //  var canadianCode = new CSA_A23_3_19();

    //  var beta = canadianCode.BetaStressBlockValue(30);

    //  var na = new NeutralAxis(730, 341, beta, 500, 500);

    //  Assert.Equal(StressBlockShape.Rectangle, na.StressBlockShape);
    //  Assert.Equal(250000, na.WhitneyCompressionArea);
    //}

    //[Fact]
    //public void Neutral_Axis_Should_Be_Rectangle_3()
    //{
    //  var canadianCode = new CSA_A23_3_19();

    //  var beta = canadianCode.BetaStressBlockValue(30);

    //  var na = new NeutralAxis(720, 250, beta, 500, 500);

    //  Assert.Equal(StressBlockShape.Rectangle, na.StressBlockShape);
    //  Assert.Equal(250000, na.WhitneyCompressionArea);
    //}

    //[Fact]
    //public void Neutral_Axis_Should_Be_Rectangle_4()
    //{
    //  var canadianCode = new CSA_A23_3_19();

    //  var beta = canadianCode.BetaStressBlockValue(30);

    //  var na = new NeutralAxis(600, 180, beta, 500, 500);

    //  Assert.Equal(StressBlockShape.Rectangle, na.StressBlockShape);
    //  Assert.Equal(250000, na.WhitneyCompressionArea);
    //}

    //[Fact]
    //public void Neutral_Axis_Should_Be_Rectangle_5()
    //{
    //  var canadianCode = new CSA_A23_3_19();

    //  var beta = canadianCode.BetaStressBlockValue(30);

    //  var na = new NeutralAxis(70, 180, beta, 700, 500);

    //  Assert.Equal(StressBlockShape.Rectangle, na.StressBlockShape);
    //  Assert.Equal(43855, na.WhitneyCompressionArea);
    //}

    //[Fact]
    //public void Neutral_Axis_Should_Be_Rectangle_6()
    //{
    //  var canadianCode = new CSA_A23_3_19();

    //  var beta = canadianCode.BetaStressBlockValue(30);

    //  var na = new NeutralAxis(194, 270, beta, 700, 500);

    //  Assert.Equal(StressBlockShape.Rectangle, na.StressBlockShape);
    //  Assert.Equal(86815, na.WhitneyCompressionArea);
    //}

    //[Fact]
    //public void Neutral_Axis_Should_Be_Pentagon_1()
    //{
    //  var canadianCode = new CSA_A23_3_19();

    //  var beta = canadianCode.BetaStressBlockValue(30);

    //  var na = new NeutralAxis(340, 64, beta, 300, 600);

    //  Assert.Equal(304.3, na.WhitneyDepth, 1);
    //  Assert.Equal(StressBlockShape.Pentagon, na.StressBlockShape);
    //  Assert.Equal(113822.3478, na.WhitneyCompressionArea, 2);
    //}

    //[Fact]
    //public void Neutral_Axis_Should_Be_Pentagon_2()
    //{
    //  var canadianCode = new CSA_A23_3_19();

    //  var beta = canadianCode.BetaStressBlockValue(30);

    //  var na = new NeutralAxis(550, 140, beta, 700, 400);

    //  Assert.Equal(492.25, na.WhitneyDepth, 1);
    //  Assert.Equal(StressBlockShape.Pentagon, na.StressBlockShape);
    //  Assert.Equal(209164.9554, na.WhitneyCompressionArea, 2);
    //}

    //[Fact]
    //public void Neutral_Axis_Should_Be_Pentagon_3()
    //{
    //  var canadianCode = new CSA_A23_3_19();

    //  var beta = canadianCode.BetaStressBlockValue(30);

    //  var na = new NeutralAxis(875, 243, beta, 700, 400);

    //  Assert.Equal(783.125, na.WhitneyDepth, 1);
    //  Assert.Equal(StressBlockShape.Pentagon, na.StressBlockShape);
    //  Assert.Equal(279392.1455, na.WhitneyCompressionArea, 2);
    //}

    //[Fact]
    //public void Neutral_Axis_Should_Be_Pentagon_4()
    //{
    //  var canadianCode = new CSA_A23_3_19();

    //  var beta = canadianCode.BetaStressBlockValue(30);

    //  var na = new NeutralAxis(850, 303.3, beta, 700, 400);

    //  Assert.Equal(760.75, na.WhitneyDepth, 1);
    //  Assert.Equal(StressBlockShape.Pentagon, na.StressBlockShape);
    //  Assert.Equal(277897.7579, na.WhitneyCompressionArea, 2);
    //}

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

