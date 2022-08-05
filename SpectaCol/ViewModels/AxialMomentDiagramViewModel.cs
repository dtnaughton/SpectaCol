using SpectaCol.Commands;
using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.ViewModels
{
  public class AxialMomentDiagramViewModel : ViewModelBase
  {
    public CommandBase CloseDialogCommand { get; }
    public List<AxialMomentDataPoint> AxialMomentDataPoints { get; }
    public AxialMomentDiagramViewModel(NavigationStore navigationStore)
    {
      CloseDialogCommand = new ToggleDialogVisibilityCommand(navigationStore);
      AxialMomentDataPoints = new List<AxialMomentDataPoint>()
      {
        new AxialMomentDataPoint(0, 100),
        new AxialMomentDataPoint(100, 200),
        new AxialMomentDataPoint(200, 300),
        new AxialMomentDataPoint(300, 250),
        new AxialMomentDataPoint(400, 225),
        new AxialMomentDataPoint(500, 200),
        new AxialMomentDataPoint(600, 0),
      };
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
