using SpectaCol.Models.Geometry;
using SpectaCol.Models.Materials;
using SpectaCol.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpectaCol.Settings.Units;

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
    public StructuralCapacity StructuralCapacity { get; set; }
    public List<FrameResult> Results { get; set; }
    public string ApplicationId { get; set; }
    public double Length { get; set; }
    public ForceUnit ForceUnit { get; set; }
    public LengthUnit LengthUnit { get; set; }
    public StressUnit StressUnit { get; set; }
  }
}
