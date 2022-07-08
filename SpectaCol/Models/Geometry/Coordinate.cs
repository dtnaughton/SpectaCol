using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.Geometry
{
  public class Coordinate
  {
    public double X { get; set; }
    public double Y { get; set; }
    public CoordinateQuadrant Quadrant { get; private set; }

    public Coordinate(double x, double y)
    {
      X = x;
      Y = y;

      SetQuadrant();
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
