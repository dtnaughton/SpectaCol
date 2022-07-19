using SpectaCol.Models.Enums;
using SpectaCol.Models.Geometry;
using SpectaCol.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.Materials
{
  public class LongitudinalReinforcement : Reinforcement, IDesignParameter
  {
    private readonly ReinforcementDiameter _stirrupDiameter;
    private readonly CrossSectionParameters _crossSectionParameters;
    private int _quantityX;
    private int _quantityY;
    private int _quantityLayers;
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
    public List<Rebar> Rebar => DefineLongitudinalRebar(_crossSectionParameters, _stirrupDiameter);
    public double ReinforcementPercentage => GetReinforcementPercentage(_crossSectionParameters, Rebar, Diameter);

    public double TotalReinforcementArea => GetReinforcementArea(Diameter, Rebar);



    public LongitudinalReinforcement(int quantityX, int quantityY, int quantityLayers,
      ReinforcementConfiguration reinforcementConfiguration, double yieldStrength, double elasticModulus,
      ReinforcementDiameter longitudinalReinforcementDiameter, CrossSectionParameters crossSectionParameters,
      ReinforcementDiameter stirrupDiameter)
    {
      QuantityX = quantityX;
      QuantityY = quantityY;
      QuantityLayers = quantityLayers;
      Configuration = reinforcementConfiguration;
      YieldStrength = yieldStrength;
      ElasticModulus = elasticModulus;
      Diameter = longitudinalReinforcementDiameter;
      _crossSectionParameters = crossSectionParameters;
      _stirrupDiameter = stirrupDiameter;

      DefineLongitudinalRebar(crossSectionParameters, stirrupDiameter);
    }

    public LongitudinalReinforcement(CrossSectionParameters crossSectionParameters)
    {
      _crossSectionParameters = crossSectionParameters;

      SetDefaultParameters();
    }

    private int GetMaxRectangularLayers(int quantityX, int quantityY)
    {
      var minBars = Convert.ToDouble(Math.Min(quantityX, quantityY));

      return Convert.ToInt16(Math.Ceiling(minBars / 2));
    }

    public List<Rebar> DefineLongitudinalRebar(CrossSectionParameters crossSectionParameters, ReinforcementDiameter stirrupDiameter)
    {
      // Edge cases: quantities are 0, rectangular arrangement in circular column (disallow this?)

      switch (Configuration)
      {
        case ReinforcementConfiguration.Rectangular:
          var edgeDistance = crossSectionParameters.Cover + GetDiameter(stirrupDiameter) + GetDiameter(Diameter) / 2;
          var centerToCenterX = (crossSectionParameters.Width - (2 * edgeDistance)) / (QuantityX - 1);
          var centerToCenterY = (crossSectionParameters.Depth - (2 * edgeDistance)) / (QuantityY - 1);
          return DefineRectangularConfiguration(crossSectionParameters.Width, crossSectionParameters.Depth, QuantityX, QuantityY, QuantityLayers, edgeDistance, edgeDistance, centerToCenterX, centerToCenterY, -(crossSectionParameters.Width) / 2 + edgeDistance, -(crossSectionParameters.Depth) / 2 + edgeDistance);
        case ReinforcementConfiguration.Circular:
          return DefineCircularConfiguration(crossSectionParameters, stirrupDiameter);
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
            var coord = new Coordinate(cumulativeXCoordinate, cumulativeYCoordinate);
            rebar.Add(new Rebar(coord));
            cumulativeXCoordinate += centerToCenterX;
          }
        }

        // internal row of bars
        else
        {
          var quantityInternalBars = quantityX < 2 ? 1 : 2;

          for (int j = 0; j < quantityInternalBars; j++)
          {
            var coord = new Coordinate(cumulativeXCoordinate, cumulativeYCoordinate);
            rebar.Add(new Rebar(coord));
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

    private double GetReinforcementPercentage(CrossSectionParameters crossSectionParameters, List<Rebar> rebar, ReinforcementDiameter diameter)
    {
      // Prevent divide by zero errors
      if (crossSectionParameters.Width == 0 || crossSectionParameters.Depth == 0) return 0;

      return (TotalReinforcementArea / (crossSectionParameters.Width * crossSectionParameters.Depth)) * 100;
    }

    public double GetReinforcementArea(ReinforcementDiameter longitudinalDiameter, List<Rebar> rebar)
    {
      return rebar.Count() * GetCrossSectionalArea(longitudinalDiameter);
    }

    public new void SetDefaultParameters()
    {
      if (QuantityX == 0) QuantityX = 2;
      if (QuantityY == 0) QuantityY = 2;
      if (QuantityLayers == 0) QuantityLayers = 1;
      if (YieldStrength == 0) YieldStrength = 400;
      if (ElasticModulus == 0) ElasticModulus = 200000;
      Diameter = ReinforcementDiameter.M20;
    }

  }
}
