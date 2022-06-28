using SpectaCol.Extensions;
using SpectaCol.Models.Geometry;
using SpectaCol.Models.Materials;
using SpectaCol.Models.Sections;
using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.ViewModels
{
  public class ConcreteColumnDesignViewModel : ViewModelBase
  {
    private ObservableCollection<ConcreteColumnViewModel> _concreteColumnViewModels = new ObservableCollection<ConcreteColumnViewModel>();
    public IEnumerable<ConcreteColumnViewModel> ConcreteColumnViewModels => _concreteColumnViewModels;

    public ConcreteColumnDesignViewModel(ObjectStore objectStore)
    {
      objectStore.ConcreteColumns?.ForEach(column =>
      {
        var columnViewModel = new ConcreteColumnViewModel(column);
        _concreteColumnViewModels.Add(columnViewModel);
      });
    }

  }
}
