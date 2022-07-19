using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.Results
{
  public class InternalSectionForce
  {
    public InternalSectionForce(double axialForce, double momentX, double momentY)
    {
      AxialForce = axialForce;
      MomentX = momentX;
      MomentY = momentY;
    }

    public double AxialForce { get; set; }
    public double MomentX { get; set; }
    public double MomentY { get; set; }
  }
}
