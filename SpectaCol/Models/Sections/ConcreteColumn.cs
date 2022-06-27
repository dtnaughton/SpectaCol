using SpectaCol.Models.Enums;
using SpectaCol.Models.Geometry;
using SpectaCol.Models.Interfaces;
using SpectaCol.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.Sections
{
  public class ConcreteColumn : IConcreteSection, IDesignParameter
  {
    public SectionShape Shape { get; set; }
    public double PhiC { get; set; } // Belong to design code?
    public double PhiS { get; set; } // Belong to design code?
    public Concrete Material { get; set; }
    public CrossSectionParameters CrossSectionParameters {get;set;}
    public LongitudinalReinforcement LongitudinalReinforcement { get; set; }
    public double Length { get; set; }
    public double StirrupBarDiameter { get; set; }
    public double Alpha { get; set; } // Belong to design code?
    public double Beta { get; set; } // Belong to design code?
    public string Units { get; set; }
    public string ApplicationId { get; set; }

    public bool HasDefaultParameters()
    {
      throw new NotImplementedException();
    }

    public void SetDefaultParameters()
    {
      // Set any default parameters that are required but likely not to be received by Speckle
    }
  }
}
