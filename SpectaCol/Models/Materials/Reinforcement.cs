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
    public double CrossSectionalArea => GetCrossSectionalArea(Diameter);
    public ReinforcementDiameter Diameter { get; set; }
    public string Grade { get; set; }
    public double ElasticModulus { get; set; }

    public double GetCrossSectionalArea(ReinforcementDiameter diameter)
    {
      return diameter switch
      {
        // Canadian bars
        ReinforcementDiameter.M10 => 100,
        ReinforcementDiameter.M15 => 200,
        ReinforcementDiameter.M20 => 300,
        ReinforcementDiameter.M25 => 500,
        ReinforcementDiameter.M30 => 700,
        ReinforcementDiameter.M35 => 1000,
        ReinforcementDiameter.M45 => 1500,
        ReinforcementDiameter.M55 => 2500,
        _ => throw new NotImplementedException(),
      };
    }

    public double GetDiameter(ReinforcementDiameter diameter)
    {
      return diameter switch
      {
        // Canadian bars
        ReinforcementDiameter.M10 => 11.3,
        ReinforcementDiameter.M15 => 16,
        ReinforcementDiameter.M20 => 19.5,
        ReinforcementDiameter.M25 => 25.2,
        ReinforcementDiameter.M30 => 29.9,
        ReinforcementDiameter.M35 => 35.7,
        ReinforcementDiameter.M45 => 43.7,
        ReinforcementDiameter.M55 => 56.4,
        _ => throw new NotImplementedException(),
      };
    }

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
