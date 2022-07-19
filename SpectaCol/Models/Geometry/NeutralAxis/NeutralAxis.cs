using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.Geometry
{
  public class NeutralAxis
  {
    private double _hypotenuseWidth;
    private double _hypotenuseDepth;
    private readonly Coordinate _extremeCompressionPoint;
    public double Depth { get; }
    public double WhitneyDepth { get; }
    public double Angle { get; }
    public double WhitneyCompressionArea { get; }
    public List<StressBlockSegment> StressBlockSegments { get; }
    public Coordinate Centroid { get; }

    public NeutralAxis(double naDepth, double angleDegs, double beta, double sectionWidth, double sectionDepth, Coordinate extremeCompressionPoint)
    {
      _extremeCompressionPoint = extremeCompressionPoint;
      Depth = naDepth;
      WhitneyDepth = naDepth * beta;
      Angle = angleDegs;
      StressBlockSegments = GetStressBlockSegments(WhitneyDepth, Angle, sectionWidth, sectionDepth, extremeCompressionPoint, Geometry.ReturnOppositeCoordinate(extremeCompressionPoint));
      WhitneyCompressionArea = GetWhitneyCompressionArea(StressBlockSegments);
      Centroid = GetStressBlockCentroid(StressBlockSegments);
    }

    private List<StressBlockSegment> GetStressBlockSegments(double whitneyDepth, double angleDeg, double sectionWidth, double sectionDepth, Coordinate extremeCompressionCoordinate, Coordinate oppositeCoordinate)
    {
      // if angle is 90, 180, 270, or 360 then it is rectangular by default and avoids division by zero errors
      if (IsVertical(angleDeg))
      {
        var rectangleCoords = new List<Coordinate>()
        {
          SetCoordinateRelativeToOther(_extremeCompressionPoint, 0, sectionDepth/2),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, whitneyDepth, sectionDepth/2),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, whitneyDepth, -sectionDepth/2),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, 0, -sectionDepth/2),
        };

        return new List<StressBlockSegment>()
        {
          new StressBlockSegment(rectangleCoords, StressBlockSegmentShape.Rectangle) 
        };
      }

      else if (IsHorizontal(angleDeg))
      {
        var rectangleCoords = new List<Coordinate>()
        {
          SetCoordinateRelativeToOther(_extremeCompressionPoint, sectionWidth/2, 0),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, sectionWidth/2, whitneyDepth),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, -sectionWidth/2, whitneyDepth),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, -sectionWidth/2, 0),
        };

        return new List<StressBlockSegment>()
        {
          new StressBlockSegment(rectangleCoords, StressBlockSegmentShape.Rectangle)
        };
      }

      else if (ExceedsMaxDepth(whitneyDepth, extremeCompressionCoordinate, oppositeCoordinate, angleDeg))
      {
        var rectangleCoords = new List<Coordinate>()
        {
          _extremeCompressionPoint,
          SetCoordinateRelativeToOther(_extremeCompressionPoint, sectionWidth, 0),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, sectionWidth, sectionDepth),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, 0, sectionDepth),
        };

        return new List<StressBlockSegment>()
        {
          new StressBlockSegment(rectangleCoords, StressBlockSegmentShape.Rectangle)
        };
      }

      var angleRad = Geometry.ConvertDegreesToRadians(angleDeg);
      _hypotenuseWidth = Math.Abs(whitneyDepth / Math.Sin(angleRad));
      _hypotenuseDepth = Math.Abs(whitneyDepth / Math.Cos(angleRad));

      if (!HypotenuseDepthGoverns(_hypotenuseDepth, sectionDepth) && !HypotenuseWidthGoverns(_hypotenuseWidth, sectionWidth))
      {
        var triangleCoords = new List<Coordinate>()
        {
          _extremeCompressionPoint,
          SetCoordinateRelativeToOther(_extremeCompressionPoint, _hypotenuseWidth, 0),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, 0, _hypotenuseDepth),
        };

        return new List<StressBlockSegment>()
        {
          new StressBlockSegment(triangleCoords, StressBlockSegmentShape.Triangle)
        };
      }

      else if (!HypotenuseDepthGoverns(_hypotenuseDepth, sectionDepth) && HypotenuseWidthGoverns(_hypotenuseWidth, sectionWidth))
      {
        var triangleHeight = sectionWidth * Math.Abs(Math.Tan(angleRad));
        var rectangleHeight = (whitneyDepth / Math.Abs(Math.Cos(angleRad))) - triangleHeight;

        var triangleCoords = new List<Coordinate>()
        {
          SetCoordinateRelativeToOther(_extremeCompressionPoint, 0, rectangleHeight),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, 0, rectangleHeight + triangleHeight),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, sectionWidth, rectangleHeight)
        };

        var rectangleCoords = new List<Coordinate>()
        {
          _extremeCompressionPoint,
          SetCoordinateRelativeToOther(_extremeCompressionPoint, 0, rectangleHeight),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, sectionWidth, rectangleHeight),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, sectionWidth, 0),
        };

        return new List<StressBlockSegment>()
        {
          new StressBlockSegment(triangleCoords, StressBlockSegmentShape.Triangle),
          new StressBlockSegment(rectangleCoords, StressBlockSegmentShape.Rectangle)
        };
      }

      else if (HypotenuseDepthGoverns(_hypotenuseDepth, sectionDepth) && !HypotenuseWidthGoverns(_hypotenuseWidth, sectionWidth))
      {
        var triangleWidth = sectionDepth / Math.Abs(Math.Tan(angleRad));
        var rectangleWidth = (whitneyDepth / Math.Abs(Math.Sin(angleRad))) - triangleWidth;

        var triangleCoords = new List<Coordinate>()
        {
          SetCoordinateRelativeToOther(_extremeCompressionPoint, rectangleWidth, 0),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, rectangleWidth + triangleWidth, 0),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, rectangleWidth, sectionDepth)
        };

        var rectangleCoords = new List<Coordinate>()
        {
          _extremeCompressionPoint,
          SetCoordinateRelativeToOther(_extremeCompressionPoint, rectangleWidth, 0),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, rectangleWidth, sectionDepth),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, 0, sectionDepth),
        };

        return new List<StressBlockSegment>()
        {
          new StressBlockSegment(triangleCoords, StressBlockSegmentShape.Triangle),
          new StressBlockSegment(rectangleCoords, StressBlockSegmentShape.Rectangle)
        };
      }

      else
      {
        var primaryRectangleWidth = (whitneyDepth / Math.Abs(Math.Cos(angleRad)) - sectionDepth) / Math.Abs(Math.Tan(angleRad));
        var triangleWidth = sectionWidth - primaryRectangleWidth;
        var triangleHeight = triangleWidth * Math.Abs(Math.Tan(angleRad));

        var primaryRectangleCoords = new List<Coordinate>()
        {
          _extremeCompressionPoint,
          SetCoordinateRelativeToOther(_extremeCompressionPoint, primaryRectangleWidth, 0),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, primaryRectangleWidth, sectionDepth),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, 0, sectionDepth),
        };

        var secondaryRectangleCoords = new List<Coordinate>()
        {
          SetCoordinateRelativeToOther(_extremeCompressionPoint, primaryRectangleWidth, 0),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, primaryRectangleWidth + triangleWidth, 0),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, primaryRectangleWidth, sectionDepth - triangleHeight),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, primaryRectangleWidth + triangleWidth, sectionDepth - triangleHeight)
        };

        var triangleCoords = new List<Coordinate>()
        {
          SetCoordinateRelativeToOther(_extremeCompressionPoint, primaryRectangleWidth, sectionDepth - triangleHeight),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, primaryRectangleWidth + triangleWidth, sectionDepth - triangleHeight),
          SetCoordinateRelativeToOther(_extremeCompressionPoint, primaryRectangleWidth, sectionDepth)
        };

        return new List<StressBlockSegment>()
        {
          new StressBlockSegment(triangleCoords, StressBlockSegmentShape.Triangle),
          new StressBlockSegment(primaryRectangleCoords, StressBlockSegmentShape.Rectangle),
          new StressBlockSegment(secondaryRectangleCoords, StressBlockSegmentShape.Rectangle)
        };
      }
    }

    private Coordinate GetStressBlockCentroid(List<StressBlockSegment> segments)
    {
      double xMomentOfArea = 0;
      double yMomentOfArea = 0;
      double totalArea = 0;

      foreach (var seg in segments)
      {
        var segArea = seg.GetArea();
        totalArea += segArea;
        var segCentroid = seg.GetCentroid();
        xMomentOfArea += segArea * segCentroid.X;
        yMomentOfArea += segArea * segCentroid.Y;
      }

      return new Coordinate(xMomentOfArea/totalArea, yMomentOfArea/totalArea);
    }

    private Coordinate SetCoordinateRelativeToOther(Coordinate relativeCoord, double deltaX, double deltaY)
    {
      double newX;
      double newY;

      if (relativeCoord.X <= 0)
        newX = relativeCoord.X + deltaX;

      else
        newX = relativeCoord.X - deltaX;

      if (relativeCoord.Y <= 0)
        newY = relativeCoord.Y + deltaY;

      else
        newY = relativeCoord.Y - deltaY;

      return new Coordinate(newX, newY);
    }

    private bool HypotenuseDepthGoverns(double _hypotenuseDepth, double sectionDepth)
    {
      return _hypotenuseDepth > sectionDepth;
    }

    private bool HypotenuseWidthGoverns(double _hypotenuseWidth, double sectionWidth)
    {
      return _hypotenuseWidth > sectionWidth;
    }

    private bool IsHorizontal(double angleDeg)
    {
      return angleDeg == 0 || angleDeg == 180 || angleDeg == 360;
    }

    private bool IsVertical(double angleDeg)
    {
      return angleDeg == 90 || angleDeg == 270;
    }

    private bool ExceedsMaxDepth(double whitneyDepth, Coordinate extremeCompressionCoordinate, Coordinate oppositeCoordinate, double angleDeg)
    {
      return whitneyDepth > Geometry.MaximumSectionDepth(extremeCompressionCoordinate, oppositeCoordinate, angleDeg);
    }

    private double GetWhitneyCompressionArea(List<StressBlockSegment> stressBlockSegments)
    {
      return stressBlockSegments.Sum(segment => segment.GetArea());
    }
  }
}
