using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.Enums
{
  public enum ReinforcementDiameter
  {
    [Description("10M")]
    M10,
    [Description("15M")]
    M15,
    [Description("20M")]
    M20,
    [Description("25M")]
    M25,
    [Description("30M")]
    M30,
    [Description("35M")]
    M35,
    [Description("45M")]
    M45,
    [Description("55M")]
    M55,
    [Description("#8")]
    US8
      // CONTINUE ADDING US AND EU
  }
}
