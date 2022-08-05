using Avalonia;
using SpectaCol.Commands;
using SpectaCol.Models.Enums;
using SpectaCol.Models.Materials;
using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace SpectaCol.ViewModels
{
  public class CrossSectionViewModel : ViewModelBase
  {
    private readonly ObjectStore _objectStore;
    public ICommand CloseDialogCommand { get; }
    public List<Point>? SectionPoints { get; private set; }
    public int CanvasWidth { get; private set; }
    public int CanvasDepth { get; private set; }
    public List<RebarViewModel> RebarPoints { get; private set; }
    public CrossSectionViewModel(NavigationStore navigationStore, ObjectStore objectStore)
    {
      CloseDialogCommand = new ToggleDialogVisibilityCommand(navigationStore);
      
      _objectStore = objectStore;

      ScaleCanvasDimensions();
    }

    private void ScaleCanvasDimensions()
    {
      CanvasWidth = 500;
      CanvasDepth = 500;
      var canvasBuffer = 100;
      var usableCanvasWidth = CanvasWidth - canvasBuffer;
      var usableCanvasDepth = CanvasDepth - canvasBuffer;

      var selectedColumn = _objectStore.SelectedConcreteColumn;
      var canvasScalingFactor = Math.Min(usableCanvasWidth / selectedColumn.CrossSectionParameters.Width, usableCanvasDepth / selectedColumn.CrossSectionParameters.Depth);
      var sectionWidth = canvasScalingFactor * selectedColumn.CrossSectionParameters.Width;
      var sectionDepth = canvasScalingFactor * selectedColumn.CrossSectionParameters.Depth;

      SectionPoints = new List<Point>()
      {
        new Point(CanvasWidth/2 + sectionWidth/2,CanvasDepth/2 - sectionDepth/2),
        new Point(CanvasWidth/2 + sectionWidth/2,CanvasDepth/2 + sectionDepth/2),
        new Point(CanvasWidth/2 - sectionWidth/2,CanvasDepth/2 + sectionDepth/2),
        new Point(CanvasWidth/2 - sectionWidth/2,CanvasDepth/2 - sectionDepth/2),
      };

      RebarPoints = new List<RebarViewModel>();

      foreach (var rebar in selectedColumn.LongitudinalReinforcement.Rebar)
      {
        RebarPoints.Add(new RebarViewModel(rebar, selectedColumn.LongitudinalReinforcement.Diameter, canvasScalingFactor, CanvasWidth, CanvasDepth));
      }
    }
  }

  public class RebarViewModel : ViewModelBase
  {
    private readonly Rebar _rebar;
    public Point Location { get; }
    public double Diameter { get; }

    public RebarViewModel(Rebar rebar, ReinforcementDiameter diameter, double canvasScalingFactor, double canvasWidth, double canvasDepth)
    {
      _rebar = rebar;
      Location = new Point(canvasWidth / 2 - (rebar.Coordinate.X * canvasScalingFactor), canvasDepth / 2 - (rebar.Coordinate.Y * canvasScalingFactor));
      //Diameter = reba
    }
  }

}
