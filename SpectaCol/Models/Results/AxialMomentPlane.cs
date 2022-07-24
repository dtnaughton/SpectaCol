using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.Results
{
  public class AxialMomentPlane
  {
    public AxialMomentPlane(double theta)
    {
      Theta = theta;
    }

    public AxialMomentPlane()
    {
    }

    public double Theta { get; set; }
    public Dictionary<double, double> Points { get; set; } = new Dictionary<double, double>();
  }
}
