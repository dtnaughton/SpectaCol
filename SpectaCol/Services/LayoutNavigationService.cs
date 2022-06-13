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

    public LayoutNavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel, NavigationBarViewModel navigationBarViewModel)
    {
      _navigationStore = navigationStore;
      _createViewModel = createViewModel;
      _navigationBarViewModel = navigationBarViewModel;
    }

    public void Navigate()
    {
      _navigationStore.CurrentViewModel = new LayoutViewModel(_navigationBarViewModel, _createViewModel());
    }
  }
}
