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
    public ViewModelBase CurrentDialogViewModel => _navigationStore.CurrentDialogViewModel;
    public bool IsDialogOpen => _navigationStore.IsDialogOpen;


    public MainWindowViewModel(NavigationStore navigationStore)
    {
      _navigationStore = navigationStore;
      _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
      _navigationStore.IsDialogOpenChanged += OnIsOpenDialogChanged;
    }

    private void OnIsOpenDialogChanged()
    {
      OnPropertyChanged(nameof(IsDialogOpen));
    }

    private void OnCurrentViewModelChanged()
    {
      OnPropertyChanged(nameof(CurrentViewModel));
      OnPropertyChanged(nameof(CurrentDialogViewModel));
    }
  }
}
