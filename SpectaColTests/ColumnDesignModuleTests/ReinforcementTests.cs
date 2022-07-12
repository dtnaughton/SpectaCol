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
        new Rebar(new Coordinate(-178.95, -178.95)),
        new Rebar(new Coordinate(-59.65, -178.95)),
        new Rebar(new Coordinate(59.65, -178.95)),
        new Rebar(new Coordinate(178.95, -178.95)),

        new Rebar(new Coordinate(-178.95, -59.65)),
        new Rebar(new Coordinate(178.95, -59.65)),

        new Rebar(new Coordinate(-178.95, 59.65)),
        new Rebar(new Coordinate(178.95, 59.65)),

        new Rebar(new Coordinate(-178.95, 178.95)),
        new Rebar(new Coordinate(-59.65, 178.95)),
        new Rebar(new Coordinate(59.65, 178.95)),
        new Rebar(new Coordinate(178.95, 178.95))
      };

      Assert.Equal(mockReinforcement.Count, reinforcement.Rebar.Count);

      for (int i = 0; i < mockReinforcement.Count; i++)
      {
        Assert.Equal(mockReinforcement[i].Coordinate.X, reinforcement.Rebar[i].Coordinate.X, 1);
        Assert.Equal(mockReinforcement[i].Coordinate.Y, reinforcement.Rebar[i].Coordinate.Y, 1);
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
        new Rebar(new Coordinate(-59.65, -59.65)),
        new Rebar(new Coordinate(59.65, -59.65)),

        new Rebar(new Coordinate(-59.65, 59.65)),
        new Rebar(new Coordinate(59.65, 59.65)),

        new Rebar(new Coordinate(-178.95, -178.95)),
        new Rebar(new Coordinate(-59.65, -178.95)),
        new Rebar(new Coordinate(59.65, -178.95)),
        new Rebar(new Coordinate(178.95, -178.95)),

        new Rebar(new Coordinate(-178.95, -59.65)),
        new Rebar(new Coordinate(178.95, -59.65)),

        new Rebar(new Coordinate(-178.95, 59.65)),
        new Rebar(new Coordinate(178.95, 59.65)),

        new Rebar(new Coordinate(-178.95, 178.95)),
        new Rebar(new Coordinate(-59.65, 178.95)),
        new Rebar(new Coordinate(59.65, 178.95)),
        new Rebar(new Coordinate(178.95, 178.95))
      };

      Assert.Equal(mockReinforcement.Count, reinforcement.Rebar.Count);

      for (int i = 0; i < mockReinforcement.Count; i++)
      {
        Assert.Equal(mockReinforcement[i].Coordinate.X, reinforcement.Rebar[i].Coordinate.X, 1);
        Assert.Equal(mockReinforcement[i].Coordinate.Y, reinforcement.Rebar[i].Coordinate.Y, 1);
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
        new Rebar(new Coordinate(-74.475, -299.2125)),
        new Rebar(new Coordinate(0, -299.2125)),
        new Rebar(new Coordinate(74.475, -299.2125)),

        new Rebar(new Coordinate(-74.475, -199.475)),
        new Rebar(new Coordinate(74.475, -199.475)),

        new Rebar(new Coordinate(-74.475, -99.7375)),
        new Rebar(new Coordinate(74.475, -99.7375)),

        new Rebar(new Coordinate(-74.475, 0)),
        new Rebar(new Coordinate(74.475, 0)),

        new Rebar(new Coordinate(-74.475, 99.7375)),
        new Rebar(new Coordinate(74.475, 99.7375)),

        new Rebar(new Coordinate(-74.475, 199.475)),
        new Rebar(new Coordinate(74.475, 199.475)),

        new Rebar(new Coordinate(-74.475, 299.2125)),
        new Rebar(new Coordinate(0, 299.2125)),
        new Rebar(new Coordinate(74.475, 299.2125)),

        new Rebar(new Coordinate(-148.95, -398.95)),
        new Rebar(new Coordinate(-74.475, -398.95)),
        new Rebar(new Coordinate(0, -398.95)),
        new Rebar(new Coordinate(74.475, -398.95)),
        new Rebar(new Coordinate(148.95, -398.95)),

        new Rebar(new Coordinate(-148.95, -299.2125)),
        new Rebar(new Coordinate(148.95, -299.2125)),

        new Rebar(new Coordinate(-148.95, -199.475)),
        new Rebar(new Coordinate(148.95, -199.475)),

        new Rebar(new Coordinate(-148.95, -99.7375)),
        new Rebar(new Coordinate(148.95, -99.7375)),

        new Rebar(new Coordinate(-148.95, 0)),
        new Rebar(new Coordinate(148.95, 0)),

        new Rebar(new Coordinate(-148.95, 99.7375)),
        new Rebar(new Coordinate(148.95, 99.7375)),

        new Rebar(new Coordinate(-148.95, 199.475)),
        new Rebar(new Coordinate(148.95, 199.475)),

        new Rebar(new Coordinate(-148.95, 299.2125)),
        new Rebar(new Coordinate(148.95, 299.2125)),

        new Rebar(new Coordinate(-148.95, 398.95)),
        new Rebar(new Coordinate(-74.475, 398.95)),
        new Rebar(new Coordinate(0, 398.95)),
        new Rebar(new Coordinate(74.475, 398.95)),
        new Rebar(new Coordinate(148.95, 398.95))
      };

      Assert.Equal(mockReinforcement.Count, reinforcement.Rebar.Count);

      for (int i = 0; i < mockReinforcement.Count; i++)
      {
        Assert.Equal(mockReinforcement[i].Coordinate.X, reinforcement.Rebar[i].Coordinate.X, 1);
        Assert.Equal(mockReinforcement[i].Coordinate.Y, reinforcement.Rebar[i].Coordinate.Y, 1);
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
        new Rebar(new Coordinate(0, -199.475)),

        new Rebar(new Coordinate(0, -99.7375)),

        new Rebar(new Coordinate(0, 0)),

        new Rebar(new Coordinate(0, 99.7375)),

        new Rebar(new Coordinate(0, 199.475)),

        new Rebar(new Coordinate(-74.475, -299.2125)),
        new Rebar(new Coordinate(0, -299.2125)),
        new Rebar(new Coordinate(74.475, -299.2125)),

        new Rebar(new Coordinate(-74.475, -199.475)),
        new Rebar(new Coordinate(74.475, -199.475)),

        new Rebar(new Coordinate(-74.475, -99.7375)),
        new Rebar(new Coordinate(74.475, -99.7375)),

        new Rebar(new Coordinate(-74.475, 0)),
        new Rebar(new Coordinate(74.475, 0)),

        new Rebar(new Coordinate(-74.475, 99.7375)),
        new Rebar(new Coordinate(74.475, 99.7375)),

        new Rebar(new Coordinate(-74.475, 199.475)),
        new Rebar(new Coordinate(74.475, 199.475)),

        new Rebar(new Coordinate(-74.475, 299.2125)),
        new Rebar(new Coordinate(0, 299.2125)),
        new Rebar(new Coordinate(74.475, 299.2125)),

        new Rebar(new Coordinate(-148.95, -398.95)),
        new Rebar(new Coordinate(-74.475, -398.95)),
        new Rebar(new Coordinate(0, -398.95)),
        new Rebar(new Coordinate(74.475, -398.95)),
        new Rebar(new Coordinate(148.95, -398.95)),

        new Rebar(new Coordinate(-148.95, -299.2125)),
        new Rebar(new Coordinate(148.95, -299.2125)),

        new Rebar(new Coordinate(-148.95, -199.475)),
        new Rebar(new Coordinate(148.95, -199.475)),

        new Rebar(new Coordinate(-148.95, -99.7375)),
        new Rebar(new Coordinate(148.95, -99.7375)),

        new Rebar(new Coordinate(-148.95, 0)),
        new Rebar(new Coordinate(148.95, 0)),

        new Rebar(new Coordinate(-148.95, 99.7375)),
        new Rebar(new Coordinate(148.95, 99.7375)),

        new Rebar(new Coordinate(-148.95, 199.475)),
        new Rebar(new Coordinate(148.95, 199.475)),

        new Rebar(new Coordinate(-148.95, 299.2125)),
        new Rebar(new Coordinate(148.95, 299.2125)),

        new Rebar(new Coordinate(-148.95, 398.95)),
        new Rebar(new Coordinate(-74.475, 398.95)),
        new Rebar(new Coordinate(0, 398.95)),
        new Rebar(new Coordinate(74.475, 398.95)),
        new Rebar(new Coordinate(148.95, 398.95))
      };

      Assert.Equal(mockReinforcement.Count, reinforcement.Rebar.Count);

      for (int i = 0; i < mockReinforcement.Count; i++)
      {
        Assert.Equal(mockReinforcement[i].Coordinate.X, reinforcement.Rebar[i].Coordinate.X, 1);
        Assert.Equal(mockReinforcement[i].Coordinate.Y, reinforcement.Rebar[i].Coordinate.Y, 1);
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
        new Rebar(new Coordinate(-144.84, -70.7)),
        new Rebar(new Coordinate(-48.28, -70.7)),
        new Rebar(new Coordinate(48.28, -70.7)),
        new Rebar(new Coordinate(144.84, -70.7)),

        new Rebar(new Coordinate(-144.84, 0)),
        new Rebar(new Coordinate(144.84, 0)),

        new Rebar(new Coordinate(-144.84, 70.7)),
        new Rebar(new Coordinate(-48.28, 70.7)),
        new Rebar(new Coordinate(48.28, 70.7)),
        new Rebar(new Coordinate(144.84, 70.7)),

        new Rebar(new Coordinate(-241.4, -141.4)),
        new Rebar(new Coordinate(-144.84, -141.4)),
        new Rebar(new Coordinate(-48.28, -141.4 )),
        new Rebar(new Coordinate(48.28, -141.4)),
        new Rebar(new Coordinate(144.84, -141.4)),
        new Rebar(new Coordinate(241.4, -141.4)),

        new Rebar(new Coordinate(-241.4, -70.7)),
        new Rebar(new Coordinate(241.4, -70.7)),

        new Rebar(new Coordinate(-241.4, 0)),
        new Rebar(new Coordinate(241.4, 0)),

        new Rebar(new Coordinate(-241.4, 70.7)),
        new Rebar(new Coordinate(241.4, 70.7)),

        new Rebar(new Coordinate(-241.4, 141.4)),
        new Rebar(new Coordinate(-144.84, 141.4)),
        new Rebar(new Coordinate(-48.28, 141.4)),
        new Rebar(new Coordinate(48.28, 141.4)),
        new Rebar(new Coordinate(144.84, 141.4)),
        new Rebar(new Coordinate(241.4, 141.4)),

      };

      Assert.Equal(mockReinforcement.Count, reinforcement.Rebar.Count);

      for (int i = 0; i < mockReinforcement.Count; i++)
      {
        Assert.Equal(mockReinforcement[i].Coordinate.X, reinforcement.Rebar[i].Coordinate.X, 1);
        Assert.Equal(mockReinforcement[i].Coordinate.Y, reinforcement.Rebar[i].Coordinate.Y, 1);
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
        new Rebar(new Coordinate(-48.28, 0)),
        new Rebar(new Coordinate(48.28, 0)),

        new Rebar(new Coordinate(-144.84, -70.7)),
        new Rebar(new Coordinate(-48.28, -70.7)),
        new Rebar(new Coordinate(48.28, -70.7)),
        new Rebar(new Coordinate(144.84, -70.7)),

        new Rebar(new Coordinate(-144.84, 0)),
        new Rebar(new Coordinate(144.84, 0)),

        new Rebar(new Coordinate(-144.84, 70.7)),
        new Rebar(new Coordinate(-48.28, 70.7)),
        new Rebar(new Coordinate(48.28, 70.7)),
        new Rebar(new Coordinate(144.84, 70.7)),

        new Rebar(new Coordinate(-241.4, -141.4)),
        new Rebar(new Coordinate(-144.84, -141.4)),
        new Rebar(new Coordinate(-48.28, -141.4)),
        new Rebar(new Coordinate(48.28, -141.4)),
        new Rebar(new Coordinate(144.84, -141.4)),
        new Rebar(new Coordinate(241.4, -141.4)),

        new Rebar(new Coordinate(-241.4, -70.7)),
        new Rebar(new Coordinate(241.4, -70.7)),

        new Rebar(new Coordinate(-241.4, 0)),
        new Rebar(new Coordinate(241.4, 0)),

        new Rebar(new Coordinate(-241.4, 70.7)),
        new Rebar(new Coordinate(241.4, 70.7)),

        new Rebar(new Coordinate(-241.4, 141.4)),
        new Rebar(new Coordinate(-144.84, 141.4)),
        new Rebar(new Coordinate(-48.28, 141.4)),
        new Rebar(new Coordinate(48.28, 141.4)),
        new Rebar(new Coordinate(144.84, 141.4)),
        new Rebar(new Coordinate(241.4, 141.4)),

      };

      Assert.Equal(mockReinforcement.Count, reinforcement.Rebar.Count);

      for (int i = 0; i < mockReinforcement.Count; i++)
      {
        Assert.Equal(mockReinforcement[i].Coordinate.X, reinforcement.Rebar[i].Coordinate.X, 1);
        Assert.Equal(mockReinforcement[i].Coordinate.Y, reinforcement.Rebar[i].Coordinate.Y, 1);
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
