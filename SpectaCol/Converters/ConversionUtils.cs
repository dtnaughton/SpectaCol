using Speckle.Core.Kits;
using Speckle.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Converters
{
  public static class ConversionUtils
  {
    public static List<Base> FlattenCommitObject(object obj, ISpeckleConverter converter, Dictionary<Type, HashSet<string>>? uniques = null)
    {
      if (uniques == null)
      {
        uniques = new Dictionary<Type, HashSet<string>>();
      }

      List<Base> objects = new List<Base>();

      if (obj is Base @base)
      {
        if (converter.CanConvertToNative(@base))
        {
          var t = obj.GetType();
          var id = (string.IsNullOrEmpty(@base.id)) ? @base.GetId() : @base.id;
          if (!uniques.ContainsKey(t))
          {
            uniques.Add(t, new HashSet<string>() { id });
            objects.Add(@base);
          }
          if (!uniques[t].Contains(id))
          {
            uniques[t].Add(id);
            objects.Add(@base);
          }

          return objects;
        }
        else
        {
          foreach (var prop in @base.GetDynamicMembers())
          {
            objects.AddRange(FlattenCommitObject(@base[prop], converter, uniques));
          }
          foreach (var kvp in @base.GetMembers())
          {
            var prop = kvp.Key;
            if (prop == "elements")
              objects.AddRange(FlattenCommitObject(@base[prop], converter, uniques));
          }
          return objects;
        }
      }

      if (obj is List<object> list)
      {
        foreach (var listObj in list)
        {
          objects.AddRange(FlattenCommitObject(listObj, converter, uniques));
        }
        return objects;
      }
      else if (obj is List<Base> baseObjList)
      {
        foreach (var baseObj in baseObjList)
        {
          objects.AddRange(FlattenCommitObject(baseObj, converter, uniques));
        }
        return objects;
      }
      else if (obj is IDictionary dict)
      {
        foreach (DictionaryEntry kvp in dict)
        {
          objects.AddRange(FlattenCommitObject(kvp.Value, converter, uniques));
        }
        return objects;
      }

      return objects;
    }
  }
}
