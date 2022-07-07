using SpectaCol.Models.Enums;
using SpectaCol.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.Materials
{
  public class TransverseReinforcement : Reinforcement, IDesignParameter
  {
    public StirrupType Type { get; set; }

    public new void SetDefaultParameters()
    {
      Type = StirrupType.Tie;
    }
  }
}
