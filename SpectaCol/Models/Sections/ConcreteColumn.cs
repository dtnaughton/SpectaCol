using SpectaCol.Models.Enums;
using SpectaCol.Models.Interfaces;
using SpectaCol.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.Sections
{
  public class ConcreteColumn : IConcreteSection
  {
    public SectionShape Shape { get; set; }
    public double PhiC { get; set; }
    public double PhiS { get; set; }
    public Concrete Material { get; set; }
    public double Width { get; set; }
    public double Depth { get; set; }
    public double Cover { get; set; }
    public double Length { get; set; }
    public double ReinforcementYieldStrength { get; set; }
    public double LongitudinalBarDiameter { get; set; }
    public double StirrupBarDiameter { get; set; }
    public double Alpha { get; set; }
    public double Beta { get; set; }
    public string Units { get; set; }
    public string ApplicationId { get; set; }
  }
}
