using SpectaCol.ForceSolvingMethods;
using SpectaCol.Models.Enums;
using SpectaCol.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.Materials
{
  public class Reinforcement : IMaterial
  {
    public double YieldStrength { get; set; }
    public double CrossSectionalArea => ForceEquilibriumMethods.GetCrossSectionalArea(Diameter);
    public ReinforcementDiameter Diameter { get; set; }
    public string Grade { get; set; }
    public double ElasticModulus { get; set; }





    public bool HasDefaultParameters()
    {
      throw new NotImplementedException();
    }

    public void SetDefaultParameters()
    {
      throw new NotImplementedException();
    }
  }
}
