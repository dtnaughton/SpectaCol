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
    private AccountStore _accountStore;
    private ObservableCollection<StreamViewModel> _streams = new ObservableCollection<StreamViewModel>();
    private ObservableCollection<BranchViewModel> _branches = new ObservableCollection<BranchViewModel>();
    private ObservableCollection<CommitViewModel> _commits = new ObservableCollection<CommitViewModel>();
    public IEnumerable<StreamViewModel> Streams => _streams;
    public IEnumerable<BranchViewModel> Branches => _branches;
    public IEnumerable<CommitViewModel> Commits => _commits;
    private StreamViewModel? _selectedStream;
    public StreamViewModel? SelectedStream
    {
      get => _selectedStream;
      set
      {
        _selectedStream = value;
        OnPropertyChanged(nameof(SelectedStream));
        _accountStore.SelectedStream = _accountStore.Streams?.Where(stream => stream.id == _selectedStream?.StreamId).FirstOrDefault();
        LoadBranchesCommand.Execute(null);
      }
    }

    private BranchViewModel? _selectedBranch;
    public BranchViewModel? SelectedBranch
    {
      get => _selectedBranch;
      set
      {
        _selectedBranch = value;
        OnPropertyChanged(nameof(SelectedBranch));
        _accountStore.SelectedBranch = _accountStore.Branches?.Where(branch => branch.id == _selectedBranch?.BranchId).FirstOrDefault();
        _accountStore.Commits = _accountStore.SelectedBranch?.commits.items;
      }
    }

    private CommitViewModel? _selectedCommit;
    public CommitViewModel? SelectedCommit
    {
      get => _selectedCommit;
      set
      {
        _selectedCommit = value;
        OnPropertyChanged(nameof(SelectedCommit));
        _accountStore.SelectedCommit = _accountStore.Commits.Where(commit => commit.id == _selectedCommit?.Id).FirstOrDefault();
      }
    }

    public ICommand LoadBranchesCommand { get; }

    public StreamSelectionViewModel(AccountStore accountStore)
    {
      _accountStore = accountStore;

      accountStore.Streams?.ForEach(stream =>
      {
        var streamViewModel = new StreamViewModel(stream);
        _streams.Add(streamViewModel);
      });

      LoadBranchesCommand = new LoadBranchesCommand(accountStore);

      _accountStore.BranchesChanged += OnBranchesChanged;
      _accountStore.CommitsChanged += OnCommitsChanged;
            
    }

    private void OnBranchesChanged()
    {
      _branches.Clear();

      _accountStore.Branches?.ForEach(branch =>
      {
        var branchViewModel = new BranchViewModel(branch);
        _branches.Add(branchViewModel);
      });
    }

    private void OnCommitsChanged()
    {
      _commits.Clear();

      _accountStore.Commits?.ForEach(commit =>
      {
        var commitViewModel = new CommitViewModel(commit);
        _commits.Add(commitViewModel);
      });
    }

    public override void Dispose()
    {
      _accountStore.BranchesChanged -= OnBranchesChanged;
      _accountStore.CommitsChanged -= OnCommitsChanged;

      base.Dispose();
    }

  }
}
