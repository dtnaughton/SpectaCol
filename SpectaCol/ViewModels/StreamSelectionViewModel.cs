using SpectaCol.Commands;
using SpectaCol.Services;
using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpectaCol.ViewModels
{
  public class StreamSelectionViewModel : ViewModelBase
  {
    private ObservableCollection<StreamViewModel> _streams;
    private AccountStore _accountStore;
    public IEnumerable<StreamViewModel> Streams => _streams;
    private StreamViewModel? _selectedStream;
    public StreamViewModel? SelectedStream
    {
      get => _selectedStream;
      set
      {
        _selectedStream = value;
        OnPropertyChanged(nameof(SelectedStream));
      }
    }

    public ICommand TestCommand { get; }

    public StreamSelectionViewModel(AccountStore accountStore)
    {
      _streams = new ObservableCollection<StreamViewModel>();
      _accountStore = accountStore;

      accountStore.Streams?.ForEach(stream =>
      {
        var streamViewModel = new StreamViewModel(stream);
        _streams.Add(streamViewModel);
      });
            
    }
  }
}
