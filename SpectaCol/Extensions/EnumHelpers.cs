using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Extensions
{
  public static class EnumHelpers
  {
    public static string GetDescription(this Enum value)
    {
      // Get the Description attribute value for the enum value
      FieldInfo fi = value.GetType().GetField(value.ToString());
      DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

      if (attributes.Length > 0)
        return attributes[0].Description;
      else
        return value.ToString();
    }
    public static T GetValueFromDescription<T>(string description) where T : Enum
    {
      foreach (var field in typeof(T).GetFields())
      {
        if (Attribute.GetCustomAttribute(field,
        typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
        {
          if (attribute.Description == description)
            return (T)field.GetValue(null);
        }
        else
        {
          if (field.Name == description)
            return (T)field.GetValue(null);
        }
      }

      throw new ArgumentException("Not found.", nameof(description));
      // Or return default(T);
    }


    public static T[] GetEnumValues<T>() where T : struct
    {
      if (!typeof(T).IsEnum)
      {
        throw new ArgumentException("GetValues<T> can only be called for types derived from System.Enum", "T");
      }
      return (T[])Enum.GetValues(typeof(T));
    }
  }
}
