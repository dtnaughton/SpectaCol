using SpectaCol.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.Materials
{
  public class Concrete : IMaterial
  {
    public string Grade { get; set; }
    public double ElasticModulus { get; set; }
    public double CompressiveStrength { get; set; }
    public bool IsLightweight { get; set; }
  }
}
