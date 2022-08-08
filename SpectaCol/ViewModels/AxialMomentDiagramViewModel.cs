using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using SpectaCol.Commands;
using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.ViewModels
{
  public class AxialMomentDiagramViewModel : ViewModelBase
  {
    public CommandBase CloseDialogCommand { get; }
    public List<double> Thetas { get; }
    public double SelectedTheta { get; set; }
    public ObservableCollection<AxialMomentDataPoint> AxialMomentDataPoints { get; }
    public string TrackerFormatString => "N = {4:0.0}\nM = {2:0.0}";
    public AxialMomentDiagramViewModel(NavigationStore navigationStore, ObjectStore objectStore)
    {
      CloseDialogCommand = new ToggleDialogVisibilityCommand(navigationStore);
      AxialMomentDataPoints = new ObservableCollection<AxialMomentDataPoint>()
      {
        new AxialMomentDataPoint(0, 100),
        new AxialMomentDataPoint(100, 200),
        new AxialMomentDataPoint(200, 300),
        new AxialMomentDataPoint(300, 250),
        new AxialMomentDataPoint(400, 225),
        new AxialMomentDataPoint(500, 200),
        new AxialMomentDataPoint(600, 0),
      };

      Thetas = objectStore.SelectedConcreteColumn?.Forces.Select(f => f.Key.Theta).ToList();
      SelectedTheta = Thetas.FirstOrDefault();

      var selectedAxialMomentPlane = objectStore.SelectedConcreteColumn?.Forces.Where(f => f.Key.Theta == SelectedTheta).FirstOrDefault();
    }
  }

  public class AxialMomentDataPoint
  {
    public AxialMomentDataPoint(double axialForce, double momentForce)
    {
      AxialForce = axialForce;
      MomentForce = momentForce;
    }

    public double AxialForce { get; }
    public double MomentForce { get; }
      
  }
}
