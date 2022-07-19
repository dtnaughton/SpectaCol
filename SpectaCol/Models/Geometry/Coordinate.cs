using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.Geometry
{
  public class Coordinate
  {
    public double X { get; }
    public double Y { get; }
    public AngleLimit AngleLimit { get; }
    public CoordinateQuadrant Quadrant { get; private set; }

    public Coordinate(double x, double y)
    {
      X = x;
      Y = y;
      AngleLimit = GetAngleLimits(x, y);

      SetQuadrant();
    }

    private AngleLimit GetAngleLimits(double x, double y)
    {
      if (x == 0 || y == 0)
        return new AngleLimit(0, 360);
      else if (x < 0 && y > 0)
        return new AngleLimit(0, 90);
      else if (x < 0 && y < 0)
        return new AngleLimit(90, 180);
      else if (x > 0 && y < 0)
        return new AngleLimit(180, 270);
      else
        return new AngleLimit(270, 360);
    }

    private void SetQuadrant()
    {
      if (X == 0 && Y == 0)
      {
        Quadrant = CoordinateQuadrant.Origin;
      }

      else if (X == 0 && Y != 0)
      {
        Quadrant = CoordinateQuadrant.YAxis;
      }

      else if (Y == 0 && X != 0)
      {
        Quadrant = CoordinateQuadrant.XAxis;
      }

      else if (X > 0 && Y > 0)
      {
        Quadrant = CoordinateQuadrant.Quadrant1;
      }

      else if (X < 0 && Y > 0)
      {
        Quadrant = CoordinateQuadrant.Quadrant2;
      }

      else if (X < 0 && Y < 0)
      {
        Quadrant = CoordinateQuadrant.Quadrant3;
      }

      else
      {
        Quadrant = CoordinateQuadrant.Quadrant4;
      }
    }

  }

  public class AngleLimit
  {
    public AngleLimit(double lower, double upper)
    {
      Upper = upper;
      Lower = lower;
    }

    public double Upper { get; }
    public double Lower { get; }
  }

  public enum CoordinateQuadrant
  {
    Origin,
    XAxis,
    YAxis,
    Quadrant1,
    Quadrant2,
    Quadrant3,
    Quadrant4
  }
}
