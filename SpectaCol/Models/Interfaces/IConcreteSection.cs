using SpectaCol.Models.Geometry;
using SpectaCol.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.Interfaces
{
  public interface IConcreteSection : ISection
  {
    public double PhiC { get; set; }
    public double PhiS { get; set; }
    public CrossSectionParameters CrossSectionParameters { get; set; }
    public Concrete Material { get; set; }
    public LongitudinalReinforcement LongitudinalReinforcement { get; set; }
    public double StirrupBarDiameter { get; set; }
    public double Alpha { get; set; }
    public double Beta { get; set; }
    public string Units { get; set; }
  }
}
