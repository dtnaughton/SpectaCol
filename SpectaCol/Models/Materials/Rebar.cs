using SpectaCol.Models.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.Materials
{
  public class Rebar
  {
    public Coordinate Coordinates{ get; set; }
    public Rebar(Coordinate coordinates)
    {
      Coordinates = coordinates;
    }
  }
}
