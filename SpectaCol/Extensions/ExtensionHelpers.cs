using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Extensions
{
  public static class ExtensionHelpers
  {
    public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
    {
      if (collection != null)
        return new ObservableCollection<T>(collection);

      return new ObservableCollection<T>();
    }
  }
}
