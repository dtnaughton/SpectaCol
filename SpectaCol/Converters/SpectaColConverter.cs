using Objects.Structural.Geometry;
using Speckle.Core.Kits;
using Speckle.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Converters
{
  public partial class SpectaColConverter : ISpeckleConverter
  {
    public string Description => throw new NotImplementedException();

    public string Name => throw new NotImplementedException();

    public string Author => "DT Naughton";

    public string WebsiteOrEmail => "naughton.dt@outlook.com";

    public ProgressReport Report => throw new NotImplementedException();

    public bool CanConvertToNative(Base @object)
    {
      // Convert only element1d or classes that inherit it
      return @object.GetType() == typeof(Element1D) || @object.GetType().IsSubclassOf(typeof(Element1D));
    }

    public bool CanConvertToSpeckle(object @object)
    {
      throw new NotImplementedException();
    }

    public object ConvertToNative(Base @object)
    {
      switch (@object)
      {
        case Element1D obj:
          throw new Exception();
          //return Element1DToNative(obj);
        default:
          throw new NotSupportedException();
      }
    }

    public List<object> ConvertToNative(List<Base> objects, IProgress<int> progress)
    {
      var retList = new List<object>();

      for (int i = 1; i <= objects.Count(); i++)
      {
        var speckleObject = ConvertToNative(objects[i - 1]);
        retList.Add(speckleObject);
        var percentComplete = (i * 100) / objects.Count();
        progress.Report(percentComplete);
      }

      return retList;
    }

    public List<object> ConvertToNative(List<Base> objects)
    {
      return objects.Select(x => ConvertToNative(x)).ToList();
    }

    public Base ConvertToSpeckle(object @object)
    {
      throw new NotImplementedException();
    }

    public List<Base> ConvertToSpeckle(List<object> objects)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<string> GetServicedApplications()
    {
      throw new NotImplementedException();
    }

    public void SetContextDocument(object doc)
    {
      throw new NotImplementedException();
    }

    public void SetContextObjects(List<ApplicationPlaceholderObject> objects)
    {
      throw new NotImplementedException();
    }

    public void SetConverterSettings(object settings)
    {
      throw new NotImplementedException();
    }

    public void SetPreviousContextObjects(List<ApplicationPlaceholderObject> objects)
    {
      throw new NotImplementedException();
    }
  }
}
