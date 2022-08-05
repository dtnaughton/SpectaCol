using SpectaCol.Commands;
using SpectaCol.Converters.Units;
using SpectaCol.Extensions;
using SpectaCol.Models.Geometry;
using SpectaCol.Models.Interfaces;
using SpectaCol.Models.Materials;
using SpectaCol.Models.Sections;
using SpectaCol.Services;
using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static SpectaCol.Settings.Units;

namespace SpectaCol.ViewModels
{
  public class ConcreteColumnDesignViewModel : ViewModelBase
  {
    private readonly SettingsStore _settingsStore;
    private readonly ObjectStore _objectStore;
    private ObservableCollection<ConcreteColumnViewModel> _concreteColumnViewModels = new ObservableCollection<ConcreteColumnViewModel>();
    private ConcreteColumnViewModel _selectedConcreteColumnViewModel;
    public IEnumerable<ConcreteColumnViewModel> ConcreteColumnViewModels => _concreteColumnViewModels;
    public ConcreteColumnViewModel SelectedConcreteColumnViewModel
    {
      get => _selectedConcreteColumnViewModel;
      set
      {
        _selectedConcreteColumnViewModel = value;
        _objectStore.SelectedConcreteColumn = _objectStore.ConcreteColumns?.Where(col => _selectedConcreteColumnViewModel.ApplicationId == col.ApplicationId).FirstOrDefault();
      }
    }
    private ICommand OpenColumnForcesCommand;
    private ICommand OpenCrossSectionViewCommand;
    private ICommand OpenAxialMomentDiagramCommand;

    public ConcreteColumnDesignViewModel(ObjectStore objectStore, SettingsStore settingsStore, NavigationStore navigationStore, 
      INavigationService tabulatedForcesNavigationService,
      INavigationService crossSectionNavigationService,
      INavigationService axialMomentDiagramNavigationService)
    {
      _objectStore = objectStore;

      _objectStore.ConcreteColumns?.ForEach(column =>
      {
        var columnViewModel = new ConcreteColumnViewModel(column, settingsStore);
        _concreteColumnViewModels.Add(columnViewModel);
      });

      _settingsStore = settingsStore;

      ConvertColumnDisplayUnits();
      _settingsStore.DisplayUnitsChanged += OnDisplayUnitsChanged;
      _settingsStore.DesignCodeChanged += OnDesignCodeChanged;

      OpenColumnForcesCommand = new NavigateDialogCommand(tabulatedForcesNavigationService, navigationStore);
      OpenCrossSectionViewCommand = new NavigateDialogCommand(crossSectionNavigationService, navigationStore);
      OpenAxialMomentDiagramCommand = new NavigateDialogCommand(axialMomentDiagramNavigationService, navigationStore);
    }

    public void OpenColumnForces()
    {
      if (SelectedColumnSet())
        OpenColumnForcesCommand.Execute(null);
    }

    public void OpenCrossSectionView()
    {
      if(SelectedColumnSet())
        OpenCrossSectionViewCommand.Execute(null);
    }

    public void OpenAxialMomentDiagramView()
    {
      if (SelectedColumnSet())
        OpenAxialMomentDiagramCommand.Execute(null);
    }

    private bool SelectedColumnSet()
    {
      var selectedColumns = _concreteColumnViewModels.Where(col => col.IsSelected);

      if (selectedColumns.Count() == 1)
      {
        _objectStore.SelectedConcreteColumn = _objectStore.ConcreteColumns.Where(col => col.ApplicationId == selectedColumns.FirstOrDefault().ApplicationId).FirstOrDefault();
        return true;
      }

      return false;
    }

    private void OnDesignCodeChanged()
    {
      _settingsStore.SelectedDesignCode.DesignColumns(_objectStore.ConcreteColumns);

      foreach (var columnViewModel in _concreteColumnViewModels)
      {
        columnViewModel.UpdateResults();
      }
    }

    private void OnDisplayUnitsChanged()
    {
      ConvertColumnDisplayUnits();
    }

    private void ConvertColumnDisplayUnits()
    {
      foreach (var columnViewModel in _concreteColumnViewModels)
      {
        columnViewModel.ForceUnit = _settingsStore.SelectedUnits.ForceUnit;
        columnViewModel.LengthUnit = _settingsStore.SelectedUnits.LengthUnit;
        columnViewModel.StressUnit = _settingsStore.SelectedUnits.StressUnit;
      }
    }

    public override void Dispose()
    {
      _settingsStore.DisplayUnitsChanged -= OnDisplayUnitsChanged;
      _settingsStore.DesignCodeChanged -= OnDesignCodeChanged;
      base.Dispose();
    }
  }
}
