using SpectaCol.Stores;
using SpectaCol.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Services
{
  public class DialogNavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
  {
    private readonly NavigationStore _navigationStore;
    private readonly Func<TViewModel> _createViewModel;

    public DialogNavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
    {
      _navigationStore = navigationStore;
      _createViewModel = createViewModel;
    }

    public void Navigate()
    {
      _navigationStore.CurrentDialogViewModel = _createViewModel();
    }
  }
}
