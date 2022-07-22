using SpectaCol.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.Geometry
{
  public static class Geometry
  {
    public static double ConvertDegreesToRadians(double angleDeg)
    {
      return angleDeg * Math.PI / 180;
    }

    public static double MaximumNeutralAxisDepth(Coordinate extremeCompressionPoint, List<Rebar> rebar, double naAngleDeg, double concreteFailureStrain, double steelFailureStrain)
    {
      var depthToFurthestBar = rebar.Select(rebar => PerpendicularDistanceBetweenPointAndLine(extremeCompressionPoint, rebar.Coordinate, naAngleDeg)).Max();

      // returns maximum depth to achieve steel failure strain in bar further from extreme compression point
      return (concreteFailureStrain * depthToFurthestBar) / (concreteFailureStrain - steelFailureStrain);
    }

    public static double MaximumSectionDepth(Coordinate extremeCompressionPoint, Coordinate oppositeCoordinate, double naAngleDeg)
    {
      return PerpendicularDistanceBetweenPointAndLine(extremeCompressionPoint, oppositeCoordinate, naAngleDeg);
    }

    public static double PerpendicularDistanceBetweenPointAndLine(Coordinate pointOfInterest, Coordinate lineCoordinate, double lineAngleDeg)
    {
      var neutralAxisAngleRad = Geometry.ConvertDegreesToRadians(lineAngleDeg);

      var tangentAngle = Math.Tan(neutralAxisAngleRad) * -1;

      var c = pointOfInterest.Y - (pointOfInterest.X * tangentAngle);

      var b = lineCoordinate.Y + (1 / tangentAngle * lineCoordinate.X);

      var xCoordOfIntersect = (b - c) / (tangentAngle + 1 / tangentAngle);

      var yCoordOfIntersect = xCoordOfIntersect * tangentAngle + c;

      var intersectionCoord = new Coordinate(xCoordOfIntersect, yCoordOfIntersect);

      return DistanceBetweenCoordinates(intersectionCoord, lineCoordinate);
    }

    public static double DistanceBetweenCoordinates(Coordinate referencePoint, Coordinate point)
    {
      return Math.Sqrt(Math.Pow(referencePoint.X - point.X, 2) + Math.Pow(referencePoint.Y - point.Y, 2));
    }

    public static Coordinate ReturnOppositeCoordinate(Coordinate original)
    {
      return new Coordinate(original.X * -1, original.Y * -1);
    }
  }
}
