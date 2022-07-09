using Objects.Structural.Geometry;
using Objects.Structural.Results;
using Speckle.Core.Kits;
using Speckle.Core.Models;
using SpectaCol.Models.Results;
using SpectaCol.Models.Sections;
using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Converters
{
  public partial class SpectaColConverter : ISpeckleConverter
  {
    private readonly ObjectStore _objectStore;
    public string Description => throw new NotImplementedException();

    public string Name => throw new NotImplementedException();

    public string Author => "DT Naughton";

    public string WebsiteOrEmail => "naughton.dt@outlook.com";

    public ProgressReport Report => throw new NotImplementedException();

    public bool CanConvertToNative(Base @object)
    {
      // Check if objects are converted or parents of objects
      return SupportedConversions.Contains(@object.GetType()) || SupportedConversions.Any(obj => @object.GetType().BaseType == obj);
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
          return Element1DToNative(obj);
        case ResultSetAll obj:
          return ResultSetAllToNative(obj);
        case ResultSet1D obj:
          return ResultSet1dToNative(obj);
        case Result1D obj:
          return Result1dToNative(obj);
        default:
          throw new NotSupportedException();
      }
    }

    public List<object> ConvertToNative(List<Base> objects)
    {
      var retList = new List<object>();

      for (int i = 1; i <= objects.Count(); i++)
      {
        try
        {
          var nativeObject = ConvertToNative(objects[i - 1]);
          
          //var percentComplete = (i * 100) / objects.Count();
          //progress.Report(percentComplete);
        }
        catch (Exception)
        {

        }
      }

      return retList;
    }

    //public List<object> ConvertToNative(List<Base> objects)
    //{
    //  return objects.Select(x => ConvertToNative(x)).ToList();
    //}

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

    public SpectaColConverter(ObjectStore objectStore)
    {
      _objectStore = objectStore;
    }

    //public ReceiveMode ReceiveMode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
  }
}
