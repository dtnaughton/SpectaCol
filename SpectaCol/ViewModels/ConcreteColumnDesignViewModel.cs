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
    public ObservableCollection<ConcreteColumn> ConcreteColumns { get; }

    public ConcreteColumnDesignViewModel(ObjectStore objectStore)
    {
      ConcreteColumns = objectStore.ConcreteColumns.ToObservableCollection();
    }

  }
}
