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
          var centerToCenterX = (crossSectionParameters.Width - (2 * edgeDistance)) / (QuantityX - 1);
          var centerToCenterY = (crossSectionParameters.Depth - (2 * edgeDistance)) / (QuantityY - 1);
          Rebar = DefineRectangularConfiguration(crossSectionParameters.Width, crossSectionParameters.Depth, QuantityX, QuantityY, QuantityLayers, edgeDistance, edgeDistance, centerToCenterX, centerToCenterY, -(crossSectionParameters.Width) / 2 + edgeDistance, -(crossSectionParameters.Depth) / 2 + edgeDistance);
          break;
        case ReinforcementConfiguration.Circular:
          Rebar = DefineCircularConfiguration(crossSectionParameters, stirrupDiameter);
          break;
        default:
          throw new NotImplementedException();
      }
    }

    private List<Rebar> DefineRectangularConfiguration(double width, double depth, int quantityX, int quantityY, int quantityLayers, double edgeDistanceX, double edgeDistanceY, double centerToCenterX, double centerToCenterY, double initialCoordX, double initialCoordY)
    {
      var rebar = new List<Rebar>();

      // Base cases
      if (quantityX <= 2 || quantityY <= 2 || quantityLayers == 1)
      {
        return DefineSingleRectangularLayer(width, quantityX, quantityY, edgeDistanceX, initialCoordX, initialCoordY, centerToCenterX, centerToCenterY);
      }

      else
      {
        rebar.AddRange(DefineRectangularConfiguration(width - 2 * edgeDistanceX, depth - 2 * edgeDistanceY, quantityX - 2, quantityY - 2, quantityLayers -1, centerToCenterX, centerToCenterY, centerToCenterX, centerToCenterY, initialCoordX + centerToCenterX, initialCoordY + centerToCenterY));
        rebar.AddRange(DefineSingleRectangularLayer(width, quantityX, quantityY, edgeDistanceX, initialCoordX, initialCoordY, centerToCenterX, centerToCenterY));
      }

      return rebar;
    }

    private List<Rebar> DefineSingleRectangularLayer(double width, int quantityX, int quantityY, double edgeDistanceX, double initialCoordX, double initialCoordY, double centerToCenterX, double centerToCenterY)
    {
      List<Rebar> rebar = new List<Rebar>();

      double cumulativeYCoordinate = initialCoordY;
      double extremeDistanceBetweenbarsX = width - 2 * edgeDistanceX;

      for (int i = 0; i < quantityY; i++)
      {
        double cumulativeXCoordinate = initialCoordX;

        // external row of bars
        if (i == 0 || i == quantityY - 1)
        {
          for (int j = 0; j < quantityX; j++)
          {
            rebar.Add(new Rebar() { XCoordinate = cumulativeXCoordinate, YCoordinate = cumulativeYCoordinate });
            cumulativeXCoordinate += centerToCenterX;
          }
        }

        // internal row of bars
        else
        {
          var quantityInternalBars = quantityX < 2 ? 1 : 2;

          for (int j = 0; j < quantityInternalBars; j++)
          {
            rebar.Add(new Rebar() { XCoordinate = cumulativeXCoordinate, YCoordinate = cumulativeYCoordinate });
            cumulativeXCoordinate += extremeDistanceBetweenbarsX;
          }
        }

        cumulativeYCoordinate += centerToCenterY;
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
