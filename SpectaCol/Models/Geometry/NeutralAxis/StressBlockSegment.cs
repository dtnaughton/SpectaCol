using System;
using System.Collections.Generic;
using System.Linq;

namespace SpectaCol.Models.Geometry
{
  public class StressBlockSegment
  {
    private List<double> _xCoords;
    private List<double> _yCoords;
    public List<Coordinate> Coordinates { get; }
    public StressBlockSegmentShape Shape { get; }

    public StressBlockSegment(List<Coordinate> coordinates, StressBlockSegmentShape shape)
    {
      if (shape == StressBlockSegmentShape.Triangle && coordinates.Count != 3)
        throw new ArgumentException("Triangle segment must have 3 coordinates");

      else if (shape == StressBlockSegmentShape.Rectangle && coordinates.Count != 4)
        throw new ArgumentException("Rectangle segment must have 4 coordinates");

      Coordinates = coordinates;
      Shape = shape;

      _xCoords = Coordinates.Select(coord => coord.X).Distinct().ToList();

      if (_xCoords.Count() != 2)
        throw new ArgumentException("Invalid number of X coordinates in segment");

      _yCoords = Coordinates.Select(coord => coord.Y).Distinct().ToList();

      if (_yCoords.Count() != 2)
        throw new ArgumentException("Invalid number of Y coordinates in segment");
    }

    public double GetArea()
    {
      var shapeSf = Shape == StressBlockSegmentShape.Triangle ? 0.5 : 1;

      return Math.Abs(_xCoords[0] - _xCoords[1]) * Math.Abs(_yCoords[0] - _yCoords[1]) * shapeSf;
    }
    public Coordinate GetCentroid()
    {
      var cumulativeX = Coordinates.Sum(coord => coord.X);
      var cumulativeY = Coordinates.Sum(coord => coord.Y);
      var quantityCoords = Coordinates.Count();

      return new Coordinate(cumulativeX / quantityCoords, cumulativeY / quantityCoords);
    }
  }
}
