using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SpectaCol.Views
{
  public partial class StreamSelectionView : UserControl
  {
    public StreamSelectionView()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
