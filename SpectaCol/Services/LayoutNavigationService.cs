using SpectaCol.Stores;
using SpectaCol.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Services
{
  public class LayoutNavigationService<TContentViewModel, TDialogViewModel> : INavigationService 
    where TContentViewModel : ViewModelBase
    where TDialogViewModel : ViewModelBase
  {
    private readonly NavigationStore _navigationStore;
    private readonly IDialogStore _dialogStore;
    private readonly Func<TContentViewModel> _createMainContentViewModel;
    private readonly NavigationBarViewModel _navigationBarViewModel;
    private readonly FooterViewModel _footerViewModel;
    private readonly Func<TDialogViewModel> _createDialogViewModel;

    public LayoutNavigationService(NavigationStore navigationStore, Func<TContentViewModel> createMainContentViewModel, NavigationBarViewModel navigationBarViewModel, FooterViewModel footerViewModel, Func<TDialogViewModel> createDialogViewModel, IDialogStore dialogStore)
    {
      _navigationStore = navigationStore;
      _createMainContentViewModel = createMainContentViewModel;
      _navigationBarViewModel = navigationBarViewModel;
      _footerViewModel = footerViewModel;
      _createDialogViewModel = createDialogViewModel;
      _dialogStore = dialogStore;
    }

    public void Navigate()
    {
      _navigationStore.CurrentViewModel = new LayoutViewModel(_navigationBarViewModel, _footerViewModel, _createMainContentViewModel(), _createDialogViewModel(), _dialogStore);
    }
  }
}
