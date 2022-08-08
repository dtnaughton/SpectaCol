using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using OxyPlot;

namespace SpectaCol.Views
{
  public partial class AxialMomentDiagramView : UserControl
  {
    public AxialMomentDiagramView()
    {
      InitializeComponent();
      var plot = new PlotModel();
      
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
