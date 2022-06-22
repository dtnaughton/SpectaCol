using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SpectaCol.Views
{
  public partial class ConcreteColumnDesignView : UserControl
  {
    public ConcreteColumnDesignView()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
