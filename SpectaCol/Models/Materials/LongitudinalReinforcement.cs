using SpectaCol.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.Materials
{
  public class LongitudinalReinforcement
  {
    public int QuantityX { get; set; }
    public int QuantityY { get; set; }
    public int QuantityLayers { get; set; }
    public double YieldStrength { get; set; }
    public double CrossSectionalArea => GetCrossSectionalArea();
    public ReinforcementDiameter Diameter { get; set; }
    public ReinforcementConfiguration Configuration { get; set; }
    public List<Rebar> Rebar => DefineRebar();

    private double GetCrossSectionalArea()
    {
      return Diameter switch
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

    private List<Rebar> DefineRebar()
    {
      // Edge cases: quantities are 0
      var rebar = new List<Rebar>();



      return rebar;
    }
  }
}
