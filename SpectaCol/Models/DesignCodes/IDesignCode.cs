using SpectaCol.Models.Geometry;
using SpectaCol.Models.Interfaces;
using SpectaCol.Models.Materials;
using SpectaCol.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.DesignCodes
{
  public interface IDesignCode
  {
    DesignCode Title { get; }
    void DesignColumns(List<IConcreteSection> concreteSections);
    double CalculateCompressionResistance(double alpha, double concreteStrength, CrossSectionParameters crossSectionParameters, LongitudinalReinforcement longitudinalReinforcement, TransverseReinforcement transverseReinforcement);
    double AlphaStressBlockValue(double concreteStrength);
    double BetaStressBlockValue(double concreteStrength);
  }
}
