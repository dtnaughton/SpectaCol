using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;

namespace SpectaCol.Views
{
  public partial class ConcreteColumnDesignView : UserControl
  {
    private DataGrid? columnDataGrid;
    private List<Key> numbersKeys = new List<Key>() { Key.D0, Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7, Key.D8, Key.D9 };
    public ConcreteColumnDesignView()
    {
      InitializeComponent();
      columnDataGrid = this.Find<DataGrid>("ColumnDataGrid");
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      if(numbersKeys.Contains(e.Key))
      {
        columnDataGrid?.BeginEdit();
      }

      base.OnKeyDown(e);
    }

  }
}
