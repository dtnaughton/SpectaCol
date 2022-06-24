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
    public void Defines_500x500_1_Layer_Rectangular_Longitudinal_Rebar()
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
        new Rebar(){ XCoordinate =  -178.95, YCoordinate = -178.95},
        new Rebar(){ XCoordinate =  -59.65, YCoordinate = -178.95},
        new Rebar(){ XCoordinate =  59.65, YCoordinate = -178.95},
        new Rebar(){ XCoordinate =  178.95, YCoordinate = -178.95},

        new Rebar(){ XCoordinate =  -178.95, YCoordinate = -59.65},
        new Rebar(){ XCoordinate =  178.95, YCoordinate = -59.65},

        new Rebar(){ XCoordinate =  -178.95, YCoordinate = 59.65},
        new Rebar(){ XCoordinate =  178.95, YCoordinate = 59.65},

        new Rebar(){ XCoordinate =  -178.95, YCoordinate = 178.95},
        new Rebar(){ XCoordinate =  -59.65, YCoordinate = 178.95},
        new Rebar(){ XCoordinate =  59.65, YCoordinate = 178.95},
        new Rebar(){ XCoordinate =  178.95, YCoordinate = 178.95}
      };

      Assert.Equal(mockReinforcement.Count, reinforcement.Rebar.Count);

      for (int i = 0; i < mockReinforcement.Count; i++)
      {
        Assert.Equal(mockReinforcement[i].XCoordinate, reinforcement.Rebar[i].XCoordinate, 1);
        Assert.Equal(mockReinforcement[i].YCoordinate, reinforcement.Rebar[i].YCoordinate, 1);
      }
    }

    [Fact]
    public void Defines_500x500_2_Layers_Rectangular_Longitudinal_Rebar()
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
        new Rebar(){ XCoordinate =  -59.65, YCoordinate = -59.65},
        new Rebar(){ XCoordinate =  59.65, YCoordinate = -59.65},

        new Rebar(){ XCoordinate =  -59.65, YCoordinate = 59.65},
        new Rebar(){ XCoordinate =  59.65, YCoordinate = 59.65},

        new Rebar(){ XCoordinate =  -178.95, YCoordinate = -178.95},
        new Rebar(){ XCoordinate =  -59.65, YCoordinate = -178.95},
        new Rebar(){ XCoordinate =  59.65, YCoordinate = -178.95},
        new Rebar(){ XCoordinate =  178.95, YCoordinate = -178.95},

        new Rebar(){ XCoordinate =  -178.95, YCoordinate = -59.65},
        new Rebar(){ XCoordinate =  178.95, YCoordinate = -59.65},

        new Rebar(){ XCoordinate =  -178.95, YCoordinate = 59.65},
        new Rebar(){ XCoordinate =  178.95, YCoordinate = 59.65},

        new Rebar(){ XCoordinate =  -178.95, YCoordinate = 178.95},
        new Rebar(){ XCoordinate =  -59.65, YCoordinate = 178.95},
        new Rebar(){ XCoordinate =  59.65, YCoordinate = 178.95},
        new Rebar(){ XCoordinate =  178.95, YCoordinate = 178.95}
      };

      Assert.Equal(mockReinforcement.Count, reinforcement.Rebar.Count);

      for (int i = 0; i < mockReinforcement.Count; i++)
      {
        Assert.Equal(mockReinforcement[i].XCoordinate, reinforcement.Rebar[i].XCoordinate, 1);
        Assert.Equal(mockReinforcement[i].YCoordinate, reinforcement.Rebar[i].YCoordinate, 1);
      }
    }

    [Fact]
    public void Defines_400x900_2_Layers_Rectangular_Longitudinal_Rebar()
    {
      var crossSectionParameters = new CrossSectionParameters()
      {
        Width = 400,
        Depth = 900,
        Cover = 30
      };

      var reinforcement = new LongitudinalReinforcement(5, 9, 2, ReinforcementConfiguration.Rectangular, 400, ReinforcementDiameter.M20, crossSectionParameters, ReinforcementDiameter.M10);

      var mockReinforcement = new List<Rebar>()
      {
        new Rebar(){ XCoordinate =  -74.475, YCoordinate = -299.2125},
        new Rebar(){ XCoordinate =  0, YCoordinate = -299.2125},
        new Rebar(){ XCoordinate =  74.475, YCoordinate = -299.2125},

        new Rebar(){ XCoordinate =  -74.475, YCoordinate = -199.475},
        new Rebar(){ XCoordinate =  74.475, YCoordinate = -199.475},

        new Rebar(){ XCoordinate =  -74.475, YCoordinate = -99.7375},
        new Rebar(){ XCoordinate =  74.475, YCoordinate = -99.7375},

        new Rebar(){ XCoordinate =  -74.475, YCoordinate = 0},
        new Rebar(){ XCoordinate =  74.475, YCoordinate = 0},

        new Rebar(){ XCoordinate =  -74.475, YCoordinate = 99.7375},
        new Rebar(){ XCoordinate =  74.475, YCoordinate = 99.7375},

        new Rebar(){ XCoordinate =  -74.475, YCoordinate = 199.475},
        new Rebar(){ XCoordinate =  74.475, YCoordinate = 199.475},

        new Rebar(){ XCoordinate =  -74.475, YCoordinate = 299.2125},
        new Rebar(){ XCoordinate =  0, YCoordinate = 299.2125},
        new Rebar(){ XCoordinate =  74.475, YCoordinate = 299.2125},

        new Rebar(){ XCoordinate =  -148.95, YCoordinate = -398.95},
        new Rebar(){ XCoordinate =  -74.475, YCoordinate = -398.95},
        new Rebar(){ XCoordinate =  0, YCoordinate = -398.95},
        new Rebar(){ XCoordinate =  74.475, YCoordinate = -398.95},
        new Rebar(){ XCoordinate =  148.95, YCoordinate = -398.95},

        new Rebar(){ XCoordinate =  -148.95, YCoordinate = -299.2125},
        new Rebar(){ XCoordinate =  148.95, YCoordinate = -299.2125},

        new Rebar(){ XCoordinate =  -148.95, YCoordinate = -199.475},
        new Rebar(){ XCoordinate =  148.95, YCoordinate = -199.475},

        new Rebar(){ XCoordinate =  -148.95, YCoordinate = -99.7375},
        new Rebar(){ XCoordinate =  148.95, YCoordinate = -99.7375},

        new Rebar(){ XCoordinate =  -148.95, YCoordinate = 0},
        new Rebar(){ XCoordinate =  148.95, YCoordinate = 0},

        new Rebar(){ XCoordinate =  -148.95, YCoordinate = 99.7375},
        new Rebar(){ XCoordinate =  148.95, YCoordinate = 99.7375},

        new Rebar(){ XCoordinate =  -148.95, YCoordinate = 199.475},
        new Rebar(){ XCoordinate =  148.95, YCoordinate = 199.475},

        new Rebar(){ XCoordinate =  -148.95, YCoordinate = 299.2125},
        new Rebar(){ XCoordinate =  148.95, YCoordinate = 299.2125},

        new Rebar(){ XCoordinate =  -148.95, YCoordinate = 398.95},
        new Rebar(){ XCoordinate =  -74.475, YCoordinate = 398.95},
        new Rebar(){ XCoordinate =  0, YCoordinate = 398.95},
        new Rebar(){ XCoordinate =  74.475, YCoordinate = 398.95},
        new Rebar(){ XCoordinate =  148.95, YCoordinate = 398.95}
      };

      Assert.Equal(mockReinforcement.Count, reinforcement.Rebar.Count);

      for (int i = 0; i < mockReinforcement.Count; i++)
      {
        Assert.Equal(mockReinforcement[i].XCoordinate, reinforcement.Rebar[i].XCoordinate, 1);
        Assert.Equal(mockReinforcement[i].YCoordinate, reinforcement.Rebar[i].YCoordinate, 1);
      }
    }

    [Fact]
    public void Defines_400x900_3_Layers_Rectangular_Longitudinal_Rebar()
    {
      var crossSectionParameters = new CrossSectionParameters()
      {
        Width = 400,
        Depth = 900,
        Cover = 30
      };

      var reinforcement = new LongitudinalReinforcement(5, 9, 3, ReinforcementConfiguration.Rectangular, 400, ReinforcementDiameter.M20, crossSectionParameters, ReinforcementDiameter.M10);

      var mockReinforcement = new List<Rebar>()
      {
        new Rebar(){ XCoordinate =  0, YCoordinate = -199.475},

        new Rebar(){ XCoordinate =  0, YCoordinate = -99.7375},

        new Rebar(){ XCoordinate =  0, YCoordinate = 0},

        new Rebar(){ XCoordinate =  0, YCoordinate = 99.7375},

        new Rebar(){ XCoordinate =  0, YCoordinate = 199.475},

        new Rebar(){ XCoordinate =  -74.475, YCoordinate = -299.2125},
        new Rebar(){ XCoordinate =  0, YCoordinate = -299.2125},
        new Rebar(){ XCoordinate =  74.475, YCoordinate = -299.2125},

        new Rebar(){ XCoordinate =  -74.475, YCoordinate = -199.475},
        new Rebar(){ XCoordinate =  74.475, YCoordinate = -199.475},

        new Rebar(){ XCoordinate =  -74.475, YCoordinate = -99.7375},
        new Rebar(){ XCoordinate =  74.475, YCoordinate = -99.7375},

        new Rebar(){ XCoordinate =  -74.475, YCoordinate = 0},
        new Rebar(){ XCoordinate =  74.475, YCoordinate = 0},

        new Rebar(){ XCoordinate =  -74.475, YCoordinate = 99.7375},
        new Rebar(){ XCoordinate =  74.475, YCoordinate = 99.7375},

        new Rebar(){ XCoordinate =  -74.475, YCoordinate = 199.475},
        new Rebar(){ XCoordinate =  74.475, YCoordinate = 199.475},

        new Rebar(){ XCoordinate =  -74.475, YCoordinate = 299.2125},
        new Rebar(){ XCoordinate =  0, YCoordinate = 299.2125},
        new Rebar(){ XCoordinate =  74.475, YCoordinate = 299.2125},

        new Rebar(){ XCoordinate =  -148.95, YCoordinate = -398.95},
        new Rebar(){ XCoordinate =  -74.475, YCoordinate = -398.95},
        new Rebar(){ XCoordinate =  0, YCoordinate = -398.95},
        new Rebar(){ XCoordinate =  74.475, YCoordinate = -398.95},
        new Rebar(){ XCoordinate =  148.95, YCoordinate = -398.95},

        new Rebar(){ XCoordinate =  -148.95, YCoordinate = -299.2125},
        new Rebar(){ XCoordinate =  148.95, YCoordinate = -299.2125},

        new Rebar(){ XCoordinate =  -148.95, YCoordinate = -199.475},
        new Rebar(){ XCoordinate =  148.95, YCoordinate = -199.475},

        new Rebar(){ XCoordinate =  -148.95, YCoordinate = -99.7375},
        new Rebar(){ XCoordinate =  148.95, YCoordinate = -99.7375},

        new Rebar(){ XCoordinate =  -148.95, YCoordinate = 0},
        new Rebar(){ XCoordinate =  148.95, YCoordinate = 0},

        new Rebar(){ XCoordinate =  -148.95, YCoordinate = 99.7375},
        new Rebar(){ XCoordinate =  148.95, YCoordinate = 99.7375},

        new Rebar(){ XCoordinate =  -148.95, YCoordinate = 199.475},
        new Rebar(){ XCoordinate =  148.95, YCoordinate = 199.475},

        new Rebar(){ XCoordinate =  -148.95, YCoordinate = 299.2125},
        new Rebar(){ XCoordinate =  148.95, YCoordinate = 299.2125},

        new Rebar(){ XCoordinate =  -148.95, YCoordinate = 398.95},
        new Rebar(){ XCoordinate =  -74.475, YCoordinate = 398.95},
        new Rebar(){ XCoordinate =  0, YCoordinate = 398.95},
        new Rebar(){ XCoordinate =  74.475, YCoordinate = 398.95},
        new Rebar(){ XCoordinate =  148.95, YCoordinate = 398.95}
      };

      Assert.Equal(mockReinforcement.Count, reinforcement.Rebar.Count);

      for (int i = 0; i < mockReinforcement.Count; i++)
      {
        Assert.Equal(mockReinforcement[i].XCoordinate, reinforcement.Rebar[i].XCoordinate, 1);
        Assert.Equal(mockReinforcement[i].YCoordinate, reinforcement.Rebar[i].YCoordinate, 1);
      }
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
