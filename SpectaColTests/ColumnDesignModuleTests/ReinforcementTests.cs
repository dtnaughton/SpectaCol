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
    public void Defines_600x400_2_Layers_Rectangular_Longitudinal_Rebar()
    {
      var crossSectionParameters = new CrossSectionParameters()
      {
        Width = 600,
        Depth = 400,
        Cover = 30
      };

      var reinforcement = new LongitudinalReinforcement(6, 5, 2, ReinforcementConfiguration.Rectangular, 400, ReinforcementDiameter.M25, crossSectionParameters, ReinforcementDiameter.M15);

      var mockReinforcement = new List<Rebar>()
      {
        new Rebar(){ XCoordinate =  -144.84, YCoordinate = -70.7},
        new Rebar(){ XCoordinate =  -48.28, YCoordinate = -70.7},
        new Rebar(){ XCoordinate =  48.28, YCoordinate = -70.7},
        new Rebar(){ XCoordinate =  144.84, YCoordinate = -70.7},

        new Rebar(){ XCoordinate =  -144.84, YCoordinate = 0},
        new Rebar(){ XCoordinate =  144.84, YCoordinate = 0},

        new Rebar(){ XCoordinate =  -144.84, YCoordinate = 70.7},
        new Rebar(){ XCoordinate =  -48.28, YCoordinate = 70.7},
        new Rebar(){ XCoordinate =  48.28, YCoordinate = 70.7},
        new Rebar(){ XCoordinate =  144.84, YCoordinate = 70.7},

        new Rebar(){ XCoordinate =  -241.4, YCoordinate = -141.4},
        new Rebar(){ XCoordinate =  -144.84, YCoordinate = -141.4},
        new Rebar(){ XCoordinate =  -48.28, YCoordinate = -141.4},
        new Rebar(){ XCoordinate =  48.28, YCoordinate = -141.4},
        new Rebar(){ XCoordinate =  144.84, YCoordinate = -141.4},
        new Rebar(){ XCoordinate =  241.4, YCoordinate = -141.4},

        new Rebar(){ XCoordinate =  -241.4, YCoordinate = -70.7},
        new Rebar(){ XCoordinate =  241.4, YCoordinate = -70.7},

        new Rebar(){ XCoordinate =  -241.4, YCoordinate = 0},
        new Rebar(){ XCoordinate =  241.4, YCoordinate = 0},

        new Rebar(){ XCoordinate =  -241.4, YCoordinate = 70.7},
        new Rebar(){ XCoordinate =  241.4, YCoordinate = 70.7},

        new Rebar(){ XCoordinate =  -241.4, YCoordinate = 141.4},
        new Rebar(){ XCoordinate =  -144.84, YCoordinate = 141.4},
        new Rebar(){ XCoordinate =  -48.28, YCoordinate = 141.4},
        new Rebar(){ XCoordinate =  48.28, YCoordinate = 141.4},
        new Rebar(){ XCoordinate =  144.84, YCoordinate = 141.4},
        new Rebar(){ XCoordinate =  241.4, YCoordinate = 141.4},

      };

      Assert.Equal(mockReinforcement.Count, reinforcement.Rebar.Count);

      for (int i = 0; i < mockReinforcement.Count; i++)
      {
        Assert.Equal(mockReinforcement[i].XCoordinate, reinforcement.Rebar[i].XCoordinate, 1);
        Assert.Equal(mockReinforcement[i].YCoordinate, reinforcement.Rebar[i].YCoordinate, 1);
      }
    }

    [Fact]
    public void Defines_600x400_3_Layers_Rectangular_Longitudinal_Rebar()
    {
      var crossSectionParameters = new CrossSectionParameters()
      {
        Width = 600,
        Depth = 400,
        Cover = 30
      };

      var reinforcement = new LongitudinalReinforcement(6, 5, 3, ReinforcementConfiguration.Rectangular, 400, ReinforcementDiameter.M25, crossSectionParameters, ReinforcementDiameter.M15);

      var mockReinforcement = new List<Rebar>()
      {
        new Rebar(){ XCoordinate =  -48.28, YCoordinate = 0},
        new Rebar(){ XCoordinate =  48.28, YCoordinate = 0},

        new Rebar(){ XCoordinate =  -144.84, YCoordinate = -70.7},
        new Rebar(){ XCoordinate =  -48.28, YCoordinate = -70.7},
        new Rebar(){ XCoordinate =  48.28, YCoordinate = -70.7},
        new Rebar(){ XCoordinate =  144.84, YCoordinate = -70.7},

        new Rebar(){ XCoordinate =  -144.84, YCoordinate = 0},
        new Rebar(){ XCoordinate =  144.84, YCoordinate = 0},

        new Rebar(){ XCoordinate =  -144.84, YCoordinate = 70.7},
        new Rebar(){ XCoordinate =  -48.28, YCoordinate = 70.7},
        new Rebar(){ XCoordinate =  48.28, YCoordinate = 70.7},
        new Rebar(){ XCoordinate =  144.84, YCoordinate = 70.7},

        new Rebar(){ XCoordinate =  -241.4, YCoordinate = -141.4},
        new Rebar(){ XCoordinate =  -144.84, YCoordinate = -141.4},
        new Rebar(){ XCoordinate =  -48.28, YCoordinate = -141.4},
        new Rebar(){ XCoordinate =  48.28, YCoordinate = -141.4},
        new Rebar(){ XCoordinate =  144.84, YCoordinate = -141.4},
        new Rebar(){ XCoordinate =  241.4, YCoordinate = -141.4},

        new Rebar(){ XCoordinate =  -241.4, YCoordinate = -70.7},
        new Rebar(){ XCoordinate =  241.4, YCoordinate = -70.7},

        new Rebar(){ XCoordinate =  -241.4, YCoordinate = 0},
        new Rebar(){ XCoordinate =  241.4, YCoordinate = 0},

        new Rebar(){ XCoordinate =  -241.4, YCoordinate = 70.7},
        new Rebar(){ XCoordinate =  241.4, YCoordinate = 70.7},

        new Rebar(){ XCoordinate =  -241.4, YCoordinate = 141.4},
        new Rebar(){ XCoordinate =  -144.84, YCoordinate = 141.4},
        new Rebar(){ XCoordinate =  -48.28, YCoordinate = 141.4},
        new Rebar(){ XCoordinate =  48.28, YCoordinate = 141.4},
        new Rebar(){ XCoordinate =  144.84, YCoordinate = 141.4},
        new Rebar(){ XCoordinate =  241.4, YCoordinate = 141.4},

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

    [Fact]
    public void Reinforcement_Percentage_Check_Good_Parameters_1_Layer()
    {
      var crossSection = new CrossSectionParameters()
      {
        Width = 500,
        Depth = 500,
        Cover = 40
      };
      var longitudinalReinforcement = new LongitudinalReinforcement(3, 4, 1, ReinforcementConfiguration.Rectangular, 400, ReinforcementDiameter.M25, crossSection, ReinforcementDiameter.M10);

      Assert.Equal(2, longitudinalReinforcement.ReinforcementPercentage);
    }

    [Fact]
    public void Reinforcement_Percentage_Check_Good_Parameters_2_Layers()
    {
      var crossSection = new CrossSectionParameters()
      {
        Width = 300,
        Depth = 300,
        Cover = 40
      };
      var longitudinalReinforcement = new LongitudinalReinforcement(4, 4, 2, ReinforcementConfiguration.Rectangular, 400, ReinforcementDiameter.M20, crossSection, ReinforcementDiameter.M10);

      Assert.Equal(5.33, longitudinalReinforcement.ReinforcementPercentage, 1);
    }

    [Fact]
    public void Reinforcement_Percentage_Check_Bad_Parameters_1_Layer()
    {
      var crossSection = new CrossSectionParameters()
      {
        Width = 0,
        Depth = 300,
        Cover = 40
      };
      var longitudinalReinforcement = new LongitudinalReinforcement(4, 4, 2, ReinforcementConfiguration.Rectangular, 400, ReinforcementDiameter.M20, crossSection, ReinforcementDiameter.M10);

      Assert.Equal(0, longitudinalReinforcement.ReinforcementPercentage, 1);
    }
  }
}
