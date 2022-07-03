﻿using SpectaCol.Converters.Units;
using SpectaCol.Models.Enums;
using SpectaCol.Models.Geometry;
using SpectaCol.Models.Materials;
using SpectaCol.Models.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpectaCol.Settings.Units;

namespace SpectaCol.ViewModels
{
  public class ConcreteColumnViewModel : ViewModelBase
  {
    private ConcreteColumn _column;
    public ConcreteColumn Column
    {
      get => _column;
    }

    public bool IsSelected { get; set; }
    public SectionShape SectionShape
    {
      get => Column.Shape;
      set
      {
        Column.Shape = value;
        OnPropertyChanged(nameof(SectionShape));
      }
    }
    public double Width
    {
      get => DisplayRounding(Column.CrossSectionParameters.Width);
      set
      {
        Column.CrossSectionParameters.Width = value;
        OnPropertyChanged(nameof(Width));
        OnPropertyChanged(nameof(LongitudinalReinforcementPercentage));
      }
    }
    public double Depth
    {
      get => DisplayRounding(Column.CrossSectionParameters.Depth);
      set
      {
        Column.CrossSectionParameters.Depth = value;
        OnPropertyChanged(nameof(Depth));
        OnPropertyChanged(nameof(LongitudinalReinforcementPercentage));
      }
    }
    public double Cover
    {
      get => DisplayRounding(Column.CrossSectionParameters.Cover);
      set
      {
        Column.CrossSectionParameters.Cover = value;
        OnPropertyChanged(nameof(Cover));
      }
    }
    public double Length
    {
      get => DisplayRounding(Column.Length);
      set
      {
        Column.Length = value;
        OnPropertyChanged(nameof(Length));
      }
    }
    public double ConcreteStrength
    {
      get => DisplayRounding(Column.Material.CompressiveStrength);
      set
      {
        Column.Material.CompressiveStrength = value;
        OnPropertyChanged(nameof(ConcreteStrength));
      }
    }
    public double LongitudinalReinforcementStrength
    {
      get => DisplayRounding(Column.LongitudinalReinforcement.YieldStrength);
      set
      {
        Column.LongitudinalReinforcement.YieldStrength = value;
        OnPropertyChanged(nameof(LongitudinalReinforcementStrength));
      }
    }
    public int QuantityLayers
    {
      get => Column.LongitudinalReinforcement.QuantityLayers;
      set
      {
        Column.LongitudinalReinforcement.QuantityLayers = value;
        OnPropertyChanged(nameof(QuantityLayers));
        OnPropertyChanged(nameof(LongitudinalReinforcementPercentage));
      }
    }
    public int QuantityX
    {
      get => Column.LongitudinalReinforcement.QuantityX;
      set
      {
        Column.LongitudinalReinforcement.QuantityX = value;
        OnPropertyChanged(nameof(QuantityX));
        OnPropertyChanged(nameof(LongitudinalReinforcementPercentage));
      }
    }
    public int QuantityY
    {
      get => Column.LongitudinalReinforcement.QuantityY;
      set
      {
        Column.LongitudinalReinforcement.QuantityY = value;
        OnPropertyChanged(nameof(QuantityY));
        OnPropertyChanged(nameof(LongitudinalReinforcementPercentage));
      }
    }
    public ReinforcementDiameter LongitudinalBarDiameter
    {
      get => Column.LongitudinalReinforcement.Diameter;
      set
      {
        Column.LongitudinalReinforcement.Diameter = value;
        OnPropertyChanged(nameof(LongitudinalBarDiameter));
        OnPropertyChanged(nameof(LongitudinalReinforcementPercentage));
      }
    }
    public double LongitudinalReinforcementPercentage
    {
      get => DisplayRounding(Column.LongitudinalReinforcement.ReinforcementPercentage);
    }
    public MetricForceUnit CurrentForceUnit
    {
      get => Column.ForceUnit;
      set
      {
        Column.ForceUnit = value;
      }
    }
    public MetricLengthUnit CurrentLengthUnit
    {
      get => Column.LengthUnit;
      set
      {
        Column.LengthUnit = value;
      }
    }



    public ConcreteColumnViewModel(ConcreteColumn concreteColumn)
    {
      _column = concreteColumn;
    }

    private double DisplayRounding(double number)
    {
      return Math.Round(number, 3);
    }

    public void ConvertUnits(MetricForceUnit newForceUnit, MetricLengthUnit newLengthUnit)
    {
      //var forceScaleFactor = UnitConverter.GetForceScaleFactor(CurrentForceUnit, newForceUnit);
    }
  }
}
