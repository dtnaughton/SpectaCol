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
    private readonly IDialogStore _dialogStore;
    public NavigationBarViewModel NavigationBarViewModel { get; }
    public ViewModelBase ContentViewModel { get; }
    public ViewModelBase DialogViewModel { get; }
    public FooterViewModel FooterViewModel { get; }
    public LayoutViewModel(NavigationBarViewModel navigationBarViewModel, FooterViewModel footerViewModel, ViewModelBase contentViewModel, ViewModelBase dialogViewModel, IDialogStore dialogStore)
    {
      NavigationBarViewModel = navigationBarViewModel;
      ContentViewModel = contentViewModel;
      FooterViewModel = footerViewModel;
      DialogViewModel = dialogViewModel;
      _dialogStore = dialogStore;
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
