using DeepEqual.Syntax;
using SpectaCol.Models.Enums;
using SpectaCol.Models.Geometry;
using SpectaCol.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpectaColTests.ColumnDesignModuleTests
{
  public class ReinforcementTests
  {
    [Fact]
    public void Defines_4x4_Single_Layer_Rectangular_Longitudinal_Rebar()
    {
      var crossSectionParameters = new CrossSectionParameters()
      {
        Width = 500,
        Depth = 500,
        Cover = 50
      };

      var reinforcement = new LongitudinalReinforcement(4, 4, 1, ReinforcementConfiguration.Rectangular, 400, ReinforcementDiameter.M20, crossSectionParameters, ReinforcementDiameter.M10);

      var mockReinforcement = new List<Rebar>()
      {
        new Rebar(){ XDistance =  -178.95, YDistance = -178.95},
        new Rebar(){ XDistance =  -59.65, YDistance = -178.95},
        new Rebar(){ XDistance =  59.65, YDistance = -178.95},
        new Rebar(){ XDistance =  178.95, YDistance = -178.95},
        new Rebar(){ XDistance =  -178.95, YDistance = -59.65},
        new Rebar(){ XDistance =  178.95, YDistance = -59.65},
        new Rebar(){ XDistance =  -178.95, YDistance = 59.65},
        new Rebar(){ XDistance =  178.95, YDistance = 59.65},
        new Rebar(){ XDistance =  -178.95, YDistance = 178.95},
        new Rebar(){ XDistance =  -59.65, YDistance = 178.95},
        new Rebar(){ XDistance =  59.65, YDistance = 178.95},
        new Rebar(){ XDistance =  178.95, YDistance = 178.95}
      };

      Assert.Equal(mockReinforcement.Count, reinforcement.Rebar.Count);

      reinforcement.Rebar[0].ShouldDeepEqual(mockReinforcement[0]);
      reinforcement.Rebar[1].ShouldDeepEqual(mockReinforcement[1]);
      reinforcement.Rebar[2].ShouldDeepEqual(mockReinforcement[2]);
      reinforcement.Rebar[3].ShouldDeepEqual(mockReinforcement[3]);
      reinforcement.Rebar[4].ShouldDeepEqual(mockReinforcement[4]);
      reinforcement.Rebar[5].ShouldDeepEqual(mockReinforcement[5]);
      reinforcement.Rebar[6].ShouldDeepEqual(mockReinforcement[6]);
      reinforcement.Rebar[7].ShouldDeepEqual(mockReinforcement[7]);
      reinforcement.Rebar[8].ShouldDeepEqual(mockReinforcement[8]);
      reinforcement.Rebar[9].ShouldDeepEqual(mockReinforcement[9]);
      reinforcement.Rebar[10].ShouldDeepEqual(mockReinforcement[10]);
      reinforcement.Rebar[11].ShouldDeepEqual(mockReinforcement[11]);
    }

    [Fact]
    public void Defines_4x4_Double_Layer_Rectangular_Longitudinal_Rebar()
    {
      var crossSectionParameters = new CrossSectionParameters()
      {
        Width = 500,
        Depth = 500,
        Cover = 50
      };

      var reinforcement = new LongitudinalReinforcement(4, 4, 2, ReinforcementConfiguration.Rectangular, 400, ReinforcementDiameter.M20, crossSectionParameters, ReinforcementDiameter.M10);

      var mockReinforcement = new List<Rebar>()
      {
        new Rebar(){ XDistance =  -178.95, YDistance = -178.95},
        new Rebar(){ XDistance =  -59.65, YDistance = -178.95},
        new Rebar(){ XDistance =  59.65, YDistance = -178.95},
        new Rebar(){ XDistance =  178.95, YDistance = -178.95},
        new Rebar(){ XDistance =  -178.95, YDistance = -59.65},
        new Rebar(){ XDistance =  178.95, YDistance = -59.65},
        new Rebar(){ XDistance =  -178.95, YDistance = 59.65},
        new Rebar(){ XDistance =  178.95, YDistance = 59.65},
        new Rebar(){ XDistance =  -178.95, YDistance = 178.95},
        new Rebar(){ XDistance =  -59.65, YDistance = 178.95},
        new Rebar(){ XDistance =  59.65, YDistance = 178.95},
        new Rebar(){ XDistance =  178.95, YDistance = 178.95},
        new Rebar(){ XDistance =  -59.65, YDistance = -59.65},
        new Rebar(){ XDistance =  59.65, YDistance = -59.65},
        new Rebar(){ XDistance =  -59.65, YDistance = 59.65},
        new Rebar(){ XDistance =  59.65, YDistance = 59.65}
      };

      Assert.Equal(reinforcement.Rebar.Count, mockReinforcement.Count);

      reinforcement.Rebar[0].ShouldDeepEqual(mockReinforcement[0]);
      reinforcement.Rebar[1].ShouldDeepEqual(mockReinforcement[1]);
      reinforcement.Rebar[2].ShouldDeepEqual(mockReinforcement[2]);
      reinforcement.Rebar[3].ShouldDeepEqual(mockReinforcement[3]);
      reinforcement.Rebar[4].ShouldDeepEqual(mockReinforcement[4]);
      reinforcement.Rebar[5].ShouldDeepEqual(mockReinforcement[5]);
      reinforcement.Rebar[6].ShouldDeepEqual(mockReinforcement[6]);
      reinforcement.Rebar[7].ShouldDeepEqual(mockReinforcement[7]);
      reinforcement.Rebar[8].ShouldDeepEqual(mockReinforcement[8]);
      reinforcement.Rebar[9].ShouldDeepEqual(mockReinforcement[9]);
      reinforcement.Rebar[10].ShouldDeepEqual(mockReinforcement[10]);
      reinforcement.Rebar[11].ShouldDeepEqual(mockReinforcement[11]);
    }

    [Fact]
    public void Should_Limit_Max_Layers_Rectangular_Reinforcement()
    {
      var crossSectionParameters = new CrossSectionParameters()
      {
        Width = 500,
        Depth = 500,
        Cover = 50
      };

      var reinforcement = new LongitudinalReinforcement(4, 4, 3, ReinforcementConfiguration.Rectangular, 400, ReinforcementDiameter.M20, crossSectionParameters, ReinforcementDiameter.M10);

      Assert.Equal(2, reinforcement.QuantityLayers);

      reinforcement.QuantityX = 6;
      reinforcement.QuantityY = 6;
      reinforcement.QuantityLayers = 9;

      Assert.Equal(3, reinforcement.QuantityLayers);

      reinforcement.QuantityX = 8;
      reinforcement.QuantityY = 9;
      reinforcement.QuantityLayers = 3;

      Assert.Equal(3, reinforcement.QuantityLayers);

      reinforcement.QuantityX = 8;
      reinforcement.QuantityY = 9;
      reinforcement.QuantityLayers = 8;

      Assert.Equal(4, reinforcement.QuantityLayers);

    }
  }
}
