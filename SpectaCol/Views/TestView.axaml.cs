using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SpectaCol.Views
{
  public partial class TestView : UserControl
  {
    public TestView()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
