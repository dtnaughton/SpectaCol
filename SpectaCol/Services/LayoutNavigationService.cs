using SpectaCol.Stores;
using SpectaCol.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Services
{
  public class LayoutNavigationService<TViewModel> : INavigationService<TViewModel> where TViewModel : ViewModelBase
  {
    private readonly NavigationStore _navigationStore;
    private readonly Func<TViewModel> _createViewModel;
    private readonly NavigationBarViewModel _navigationBarViewModel;
    private readonly FooterViewModel _footerViewModel;

    public LayoutNavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel, NavigationBarViewModel navigationBarViewModel, FooterViewModel footerViewModel)
    {
      _navigationStore = navigationStore;
      _createViewModel = createViewModel;
      _navigationBarViewModel = navigationBarViewModel;
      _footerViewModel = footerViewModel;
    }

    public void Navigate()
    {
      _navigationStore.CurrentViewModel = new LayoutViewModel(_navigationBarViewModel, _footerViewModel, _createViewModel());
    }
  }
}
