using SpectaCol.Models.Enums;
using SpectaCol.Models.Geometry;
using SpectaCol.Models.Interfaces;
using SpectaCol.Models.Materials;
using SpectaCol.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpectaCol.Settings.Units;

namespace SpectaCol.Models.Sections
{
  public class ConcreteColumn : IConcreteSection, IDesignParameter
  {
    public bool IsSelected { get; set; }
    public SectionShape Shape { get; set; }
    public Concrete Concrete { get; set; }
    public CrossSectionParameters CrossSectionParameters {get;set;}
    public LongitudinalReinforcement LongitudinalReinforcement { get; set; }
    public TransverseReinforcement TransverseReinforcement { get; set; }
    public double Length { get; set; }
    public double StirrupBarDiameter { get; set; }
    public string Units { get; set; }
    public string ApplicationId { get; set; }
    public Dictionary<AxialMomentPlane, List<FrameResult>> Forces { get; set; } = new Dictionary<AxialMomentPlane, List<FrameResult>>();
    public double MaximumUtilization { get; set; }
    public ForceUnit ForceUnit { get; set; }
    public LengthUnit LengthUnit { get; set; }
    public StressUnit StressUnit { get; set; }
    public DesignResults DesignResults { get; set; }

    public ConcreteColumn()
    {
      DesignResults = new DesignResults();
    }

    public bool HasDefaultParameters()
    {
      throw new NotImplementedException();
    }

    public void SetDefaultUnits()
    {
      ForceUnit = ForceUnit.N;
      LengthUnit = LengthUnit.mm;
      StressUnit = StressUnit.mPa;
    }

    public void SetDefaultParameters()
    {
    }
  }
}
