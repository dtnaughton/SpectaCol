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

    public Concrete()
    {

    }

    public void SetDefaultParameters()
    {
      if (string.IsNullOrEmpty(Grade)) Grade = "C35";
      if (ElasticModulus == 0) ElasticModulus = 24000;
      if (CompressiveStrength == 0) CompressiveStrength = 30;
    }

    public bool HasDefaultParameters()
    {
      return string.IsNullOrEmpty(Grade) || ElasticModulus == 0 || CompressiveStrength == 0;
    }
  }
}
