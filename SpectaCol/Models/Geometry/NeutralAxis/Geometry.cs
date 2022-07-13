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
  }
}
