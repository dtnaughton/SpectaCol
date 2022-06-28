using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Extensions
{
  public class EnumBindingSourceExtension : MarkupExtension
  {
    public Type EnumType { get; }

    public EnumBindingSourceExtension(Type enumType)
    {
      if (enumType is null || !enumType.IsEnum)
      {
        throw new ArgumentNullException(nameof(enumType));
      }
      EnumType = enumType;
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
      return Enum.GetValues(EnumType);
    }
  }
}
