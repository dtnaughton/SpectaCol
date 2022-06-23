using SpectaCol.Models.Enums;
using SpectaCol.Models.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.Materials
{
  public class LongitudinalReinforcement : Reinforcement
  {
    private int _quantityX;
    private int _quantityY;
    public int QuantityX
    {
      get => _quantityX;
      set
      {
        _quantityX = value < 2 ? 2 : value;
      }
    }
    public int QuantityY
    {
      get => _quantityY;
      set
      {
        _quantityY = value < 2 ? 2 : value;
      }
    }
    private int _quantityLayers;
    public int QuantityLayers
    {
      get => _quantityLayers;
      set
      {
        int maxLayers;

        if (Configuration == ReinforcementConfiguration.Rectangular)
        {
          maxLayers = GetMaxRectangularLayers(QuantityX, QuantityY);
        }

        else
        {
          // Arbitrary number for circular
          maxLayers = 5;
        }

        _quantityLayers = value < maxLayers ? value : maxLayers;
      }
    }
    public ReinforcementConfiguration Configuration { get; set; }
    public List<Rebar> Rebar { get; set; } = new List<Rebar>();

    public LongitudinalReinforcement(int quantityX, int quantityY, int quantityLayers,
      ReinforcementConfiguration reinforcementConfiguration, double yieldStrength,
      ReinforcementDiameter longitudinalReinforcementDiameter, CrossSectionParameters crossSectionParameters,
      ReinforcementDiameter stirrupDiameter)
    {
      QuantityX = quantityX;
      QuantityY = quantityY;
      QuantityLayers = quantityLayers;
      Configuration = reinforcementConfiguration;
      YieldStrength = yieldStrength;
      Diameter = longitudinalReinforcementDiameter;

      DefineLongitudinalRebar(crossSectionParameters, stirrupDiameter);
    }

    private int GetMaxRectangularLayers(int quantityX, int quantityY)
    {
      var minBars = Convert.ToDouble(Math.Min(quantityX, quantityY));

      return Convert.ToInt16(Math.Ceiling(minBars / 2));
    }

    public void DefineLongitudinalRebar(CrossSectionParameters crossSectionParameters, ReinforcementDiameter stirrupDiameter)
    {
      // Edge cases: quantities are 0, rectangular arrangement in circular column (disallow this?)

      switch (Configuration)
      {
        case ReinforcementConfiguration.Rectangular:
          var edgeDistance = crossSectionParameters.Cover + GetDiameter(stirrupDiameter) + GetDiameter(Diameter) / 2;
          var extremeDistanceXBars = crossSectionParameters.Width - (2 * edgeDistance);
          var extremeDistanceYBars = crossSectionParameters.Depth - (2 * edgeDistance);

          var xCenterToCenter = (extremeDistanceXBars) / (QuantityX - 1);
          var yCenterToCenter = (extremeDistanceYBars) / (QuantityY - 1);
          //Rebar = DefineRectangularConfiguration(crossSectionParameters, stirrupDiameter);
          Rebar = DefineRectangularConfiguration_Recursion(crossSectionParameters.Width, crossSectionParameters.Depth, QuantityX, QuantityY, QuantityLayers, edgeDistance, xCenterToCenter, yCenterToCenter);
          break;
        case ReinforcementConfiguration.Circular:
          Rebar = DefineCircularConfiguration(crossSectionParameters, stirrupDiameter);
          break;
        default:
          throw new NotImplementedException();
      }
    }

    private List<Rebar> DefineRectangularConfiguration(CrossSectionParameters crossSectionParameters, ReinforcementDiameter stirrupDiameter)
    {
      var rebar = new List<Rebar>();

      // Total distance from edge of concrete to center of edge reinforcement
      var edgeDistance = crossSectionParameters.Cover + GetDiameter(stirrupDiameter) + GetDiameter(Diameter) / 2;

      var extremeDistanceXBars = crossSectionParameters.Width - (2 * edgeDistance);
      var extremeDistanceYBars = crossSectionParameters.Depth - (2 * edgeDistance);

      var xCenterToCenter = (extremeDistanceXBars) / (QuantityX - 1);
      var yCenterToCenter = (extremeDistanceYBars) / (QuantityY - 1);


      // Setting out of bars from bottom-left corner of column cross-section about origin
      for (int i = 0; i < QuantityLayers; i++)
      {
        double cumulativeYCoordinate = (-crossSectionParameters.Depth / 2) + edgeDistance + (i * yCenterToCenter);

        var startIndexYBars = 0 + i;
        var endIndexYBars = QuantityY - i;

        // Extreme distance between edge bars gets smaller for internal layers
        extremeDistanceXBars -= (2 * xCenterToCenter * i);
        extremeDistanceYBars -= (2 * yCenterToCenter * i);

        for (int j = startIndexYBars; j < endIndexYBars; j++)
        {
          double cumulativeXCoordinate;

          var startIndexXBars = 0 + i;
          var endIndexXBars = QuantityX - i;

          if (j == startIndexYBars || j == endIndexYBars - 1)
          {
            for (int k = startIndexXBars; k < endIndexXBars; k++)
            {
              cumulativeXCoordinate = (-crossSectionParameters.Width / 2) + edgeDistance + (k * xCenterToCenter);
              rebar.Add(new Rebar() { XDistance = cumulativeXCoordinate, YDistance = cumulativeYCoordinate });
            }
          }

          else
          {
            for (int k = 0; k < 2; k++)
            {
              cumulativeXCoordinate = (-crossSectionParameters.Width / 2) + edgeDistance + (k * extremeDistanceXBars);
              rebar.Add(new Rebar() { XDistance = cumulativeXCoordinate, YDistance = cumulativeYCoordinate });
            }
          }

          cumulativeYCoordinate += yCenterToCenter;

        }
      }

      return rebar;
    }

    private List<Rebar> DefineRectangularConfiguration_Recursion(double width, double depth, int quantityX, int quantityY, double edgeDistanceX, double edgeDistanceY, double centerToCenterX, double centerToCenterY, double initialCoordX, double initialCoordY)
    {
      var rebar = new List<Rebar>();

      if (quantityX == 2 && quantityY == 2)
      {
        double cumulativeYCoordinate = initialCoordY;
        for (int i = 0; i < quantityY; i++)
        {
          cumulativeYCoordinate += centerToCenterY;
          double cumulativeXCoordinate = initialCoordX;

          for (int j = 0; j < quantityX; j++)
          {
            cumulativeXCoordinate += centerToCenterX;
            rebar.Add(new Rebar() { XDistance = cumulativeXCoordinate, YDistance = cumulativeYCoordinate });
          }
        }
      }

      else
      {
        rebar.AddRange(DefineRectangularConfiguration_Recursion(width - 2 * edgeDistanceX, depth - 2 * edgeDistanceY, quantityX - 2, quantityY - 2, centerToCenterX, centerToCenterY, centerToCenterX, centerToCenterX, initialCoordX + centerToCenterX, initialCoordY + centerToCenterY));
      }

      return rebar;

    }

    private List<Rebar> DefineCircularConfiguration(CrossSectionParameters crossSectionParameters, ReinforcementDiameter stirrupDiameter)
    {
      var rebar = new List<Rebar>();
      return rebar;
    }
  }
}
