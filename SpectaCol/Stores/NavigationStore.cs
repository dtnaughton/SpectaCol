using SpectaCol.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Stores
{
  public class NavigationStore
  {
    public event Action CurrentViewModelChanged;
    private bool _isDialogOpen;
    private ViewModelBase _currentViewModel;
    private ViewModelBase _currentDialogViewModel;
    public event Action IsDialogOpenChanged;
    public bool IsDialogOpen
    {
      get => _isDialogOpen;
      set
      {
        _isDialogOpen = value;
        IsDialogOpenChanged?.Invoke();
      }
    }
    public ViewModelBase CurrentViewModel
    {
      get => _currentViewModel;
      set
      {
        _currentViewModel?.Dispose();
        _currentViewModel = value;
        OnCurrentViewModelChanged();
      }
    }

    public ViewModelBase CurrentDialogViewModel
    {
      get => _currentDialogViewModel;
      set
      {
        _currentDialogViewModel?.Dispose();
        _currentDialogViewModel = value;
        OnCurrentViewModelChanged();
      }
    }

    private void OnCurrentViewModelChanged()
    {
      CurrentViewModelChanged?.Invoke();
    }
  }
}
