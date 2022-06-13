using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SpectaCol.Components
{
  public partial class Footer : UserControl
  {
    public Footer()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
