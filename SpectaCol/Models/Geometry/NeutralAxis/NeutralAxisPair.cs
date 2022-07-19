using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.Geometry
{
  public class NeutralAxisPair : Dictionary<double, double>
  {
    public double Guess => this.First().Key;
    public double Force => this.First().Value;
  }
}
