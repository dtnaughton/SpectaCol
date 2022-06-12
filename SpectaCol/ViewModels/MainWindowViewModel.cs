using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpectaCol.ViewModels
{
  public class MainWindowViewModel : ViewModelBase
  {
    private readonly NavigationStore _navigationStore;
    public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

    public MainWindowViewModel(NavigationStore navigationStore)
    {
      _navigationStore = navigationStore;
      _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
    }

    private void OnCurrentViewModelChanged()
    {
      OnPropertyChanged(nameof(CurrentViewModel));
    }
  }
}
