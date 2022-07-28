using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.ViewModels
{
  public class LayoutViewModel : ViewModelBase
  {
    public NavigationBarViewModel NavigationBarViewModel { get; }
    public ViewModelBase ContentViewModel { get; }
    public ViewModelBase DialogViewModel { get; }
    public FooterViewModel FooterViewModel { get; }
    public LayoutViewModel(NavigationBarViewModel navigationBarViewModel, FooterViewModel footerViewModel, ViewModelBase contentViewModel, ViewModelBase dialogViewModel)
    {
      NavigationBarViewModel = navigationBarViewModel;
      ContentViewModel = contentViewModel;
      FooterViewModel = footerViewModel;
      DialogViewModel = dialogViewModel;
    }

    public override void Dispose()
    {
      NavigationBarViewModel?.Dispose();
      ContentViewModel?.Dispose();
      FooterViewModel?.Dispose();
      DialogViewModel?.Dispose();
      base.Dispose();
    }
  }
}
