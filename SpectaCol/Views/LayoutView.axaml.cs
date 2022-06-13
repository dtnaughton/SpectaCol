using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SpectaCol.Views
{
  public partial class LayoutView : UserControl
  {
    public LayoutView()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
