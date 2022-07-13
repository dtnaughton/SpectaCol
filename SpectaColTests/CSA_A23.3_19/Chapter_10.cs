using SpectaCol.Models.DesignCodes;
using SpectaCol.Models.Enums;
using SpectaCol.Models.Geometry;
using SpectaCol.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpectaColTests.CSA_A23._3_19
{
  public class Chapter_10
  {
    [Fact]
    public void Alpha_Returns_Calculated_Value()
    {
      var csaCode = new CSA_A23_3_19();

      var concreteStrength = 40;

      var alpha = csaCode.AlphaStressBlockValue(concreteStrength);

      Assert.Equal(0.79, alpha);
    }

    [Fact]
    public void Alpha_Returns_Minimum_Value()
    {
      var csaCode = new CSA_A23_3_19();

      var concreteStrength = 150;

      var alpha = csaCode.AlphaStressBlockValue(concreteStrength);

      Assert.Equal(0.67, alpha);
    }

    [Fact]
    public void Beta_Returns_Calculated_Value()
    {
      var csaCode = new CSA_A23_3_19();

      var concreteStrength = 40;

      var beta = csaCode.BetaStressBlockValue(concreteStrength);

      Assert.Equal(0.87, beta);
    }

    [Fact]
    public void Beta_Returns_Minimum_Value()
    {
      var csaCode = new CSA_A23_3_19();

      var concreteStrength = 150;

      var beta = csaCode.BetaStressBlockValue(concreteStrength);

      Assert.Equal(0.67, beta);
    }

    [Fact]
    // Governed by max factor 0.8 Pro
    public void Compression_Resistance_With_Greater_Than_Minimum_Reinforcement_Governed_By_Max()
    {
      var csaCode = new CSA_A23_3_19();

      var crossSectionParameters = new CrossSectionParameters(400, 400, 40);

      var concreteStrength = 35;

      var alpha = csaCode.AlphaStressBlockValue(concreteStrength);

      var longReinf = new LongitudinalReinforcement(4, 4, 1, ReinforcementConfiguration.Rectangular, 400, 200000, ReinforcementDiameter.M20, crossSectionParameters, ReinforcementDiameter.M10);
      var transReinf = new TransverseReinforcement();

      var compressionResistance = csaCode.CalculateCompressionResistance(alpha, concreteStrength, crossSectionParameters, longReinf, transReinf);

      Assert.Equal(3249267.8, compressionResistance, 1);
    }

    [Fact]
    // Governed by max factor 0.8 Pro
    public void Compression_Resistance_With_Less_Than_Minimum_Reinforcement_Governed_By_Max()
    {
      var csaCode = new CSA_A23_3_19();

      var crossSectionParameters = new CrossSectionParameters(400, 400, 40);

      var concreteStrength = 35;

      var alpha = csaCode.AlphaStressBlockValue(concreteStrength);

      var longReinf = new LongitudinalReinforcement(2, 2, 1, ReinforcementConfiguration.Rectangular, 400, 200000, ReinforcementDiameter.M20, crossSectionParameters, ReinforcementDiameter.M10);
      var transReinf = new TransverseReinforcement();

      var compressionResistance = csaCode.CalculateCompressionResistance(alpha, concreteStrength, crossSectionParameters, longReinf, transReinf);

      Assert.Equal(2302389.775, compressionResistance, 1);
    }

    [Fact]
    public void Compression_Resistance_With_Greater_Than_Minimum_Reinforcement()
    {
      var csaCode = new CSA_A23_3_19();

      var crossSectionParameters = new CrossSectionParameters(600, 250, 40);

      var concreteStrength = 35;

      var alpha = csaCode.AlphaStressBlockValue(concreteStrength);

      var longReinf = new LongitudinalReinforcement(3, 7, 1, ReinforcementConfiguration.Rectangular, 400, 200000, ReinforcementDiameter.M20, crossSectionParameters, ReinforcementDiameter.M10);
      var transReinf = new TransverseReinforcement();

      var compressionResistance = csaCode.CalculateCompressionResistance(alpha, concreteStrength, crossSectionParameters, longReinf, transReinf);

      Assert.Equal(2986467.225, compressionResistance, 1);
    }
  }
}
