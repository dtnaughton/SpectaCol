using SpectaCol.Models.Enums;
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
  public class CSA_A23_3_19 : IDesignCode
  {
    private readonly double _phiC = 0.65;
    private readonly double _phiS = 0.85;
    public DesignCode Title { get; }

    public CSA_A23_3_19()
    {
      Title = DesignCode.A23319;
    }



    public void DesignColumns(List<IConcreteSection> concreteSections)
    {
      foreach (var concSect in concreteSections)
      {
        DesignColumns(concSect);
      }
    }
    public void DesignColumns(IConcreteSection concreteSection)
    {
      concreteSection.DesignResults.Alpha = AlphaStressBlockValue(concreteSection.Concrete.CompressiveStrength);
      concreteSection.DesignResults.Beta = BetaStressBlockValue(concreteSection.Concrete.CompressiveStrength);
      concreteSection.DesignResults.CompressionResistance = CalculateCompressionResistance(concreteSection.DesignResults.Alpha, concreteSection.Concrete.CompressiveStrength, concreteSection.CrossSectionParameters, concreteSection.LongitudinalReinforcement, concreteSection.TransverseReinforcement);
    }

    #region Chapter 10
    /// <summary>
    /// Clause 10.1.7 equation 10.1
    /// </summary>
    /// <returns>Average stress factor for equivalent rectangular concrete stress distribution</returns>
    public double AlphaStressBlockValue(double concreteStrength)
    {
      return Math.Max(0.85 - (0.0015 * concreteStrength), 0.67);
    }

    /// <summary>
    /// Clause 10.1.7 equation 10.2
    /// </summary>
    /// <returns>Ratio of depth of equivalent rectangular block to depth to the neutral axis</returns>
    public double BetaStressBlockValue(double concreteStrength)
    {
      return Math.Max(0.97 - (0.0025 * concreteStrength), 0.67);
    }

    /// <summary>
    /// Clause 10.10.4
    /// </summary>
    /// <param name="alpha"></param>
    /// <param name="phiC"></param>
    /// <param name="concreteStrength"></param>
    /// <param name="crossSectionParameters"></param>
    /// <param name="longitudinalReinforcement"></param>
    /// <param name="transverseReinforcement"></param>
    /// <returns>Maximum factored axial load resistance of compression members</returns>
    public double CalculateCompressionResistance(double alpha, double concreteStrength, CrossSectionParameters crossSectionParameters, LongitudinalReinforcement longitudinalReinforcement, TransverseReinforcement transverseReinforcement)
    {
      // Clause 10.10.5 - reduced capacity factor for less than minimum reinforcement
      var minReinforcementReductionFactor = Math.Min(1, 0.5 * (1 + (longitudinalReinforcement.ReinforcementPercentage / 100) / 0.01));

      // Equation 10.11
      var P_ro = (alpha * _phiC * concreteStrength * ((crossSectionParameters.Width * crossSectionParameters.Depth) - longitudinalReinforcement.TotalReinforcementArea)) + (_phiS * longitudinalReinforcement.YieldStrength * longitudinalReinforcement.TotalReinforcementArea);

      // Equation 10.8
      if (transverseReinforcement.Type == StirrupType.Spiral)
      {
        return 0.9 * P_ro * minReinforcementReductionFactor;
      }

      //Equation 10.9
      else
      {
        return Math.Min(((0.2 + 0.002 * Math.Min(crossSectionParameters.Width, crossSectionParameters.Depth)) * P_ro), 0.8 * P_ro) * minReinforcementReductionFactor;
      }
    }

    #endregion
  }
}
