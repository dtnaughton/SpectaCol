using SpectaCol.Models.Geometry;
using SpectaCol.Models.Interfaces;
using SpectaCol.Models.Materials;
using SpectaCol.Models.Results;
using SpectaCol.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.DesignCodes
{
  public class ACI_318_19 : IDesignCode
  {
    public DesignCode Title { get; }

    public ACI_318_19()
    {
      Title = DesignCode.ACI31819;
    }

    public double CalculateCompressionResistance()
    {
      //temp
      return 2000;
    }

    public void DesignColumns(List<IConcreteSection> concreteSections)
    {
      foreach (var concSect in concreteSections)
      {
        concSect.DesignResults = new DesignResults()
        {
          CompressionResistance = CalculateCompressionResistance()
        };
      }
    }

    public double AlphaStressBlockValue(double concreteStrength)
    {
      throw new NotImplementedException();
    }

    public double BetaStressBlockValue(double concreteStrength)
    {
      throw new NotImplementedException();
    }

    public double CalculateCompressionResistance(double alpha, double concreteStrength, CrossSectionParameters crossSectionParameters, LongitudinalReinforcement longitudinalReinforcement, TransverseReinforcement transverseReinforcement)
    {
      throw new NotImplementedException();
    }
  }
}
