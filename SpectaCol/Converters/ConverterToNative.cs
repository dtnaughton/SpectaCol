using Objects.Structural;
using Objects.Structural.Geometry;
using Objects.Structural.GSA.Properties;
using Objects.Structural.Properties;
using Speckle.Core.Kits;
using SpectaCol.Models.Materials;
using SM = Objects.Structural.Materials;
using SpectaCol.Models.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects.Structural.GSA.Materials;
using Objects.Structural.Properties.Profiles;
using Objects.Geometry;

namespace SpectaCol.Converters
{
  public partial class SpectaColConverter : ISpeckleConverter
  {
    public static List<Type> SupportedConversions { get; } = new List<Type>()
      {
          typeof(Element1D),
      };


    #region conversion methods
    public ConcreteColumn Element1DToNative(Element1D speckleElement)
    {
      if (speckleElement.memberType != MemberType.Column)
      {
        throw new NotSupportedException($"Support for only {MemberType.Column}");
      }

      var speckleProperty = (Property1D)speckleElement.property;

      var nativeColumn = new ConcreteColumn()
      {
        ApplicationId = speckleElement.applicationId,
        Material = Property1DToNative((Property1D)speckleElement.property),
        Units = speckleElement.units
      };

      if (speckleElement.baseLine != null && speckleElement.baseLine.length != 0)
      {
        nativeColumn.Length = speckleElement.baseLine.length;
      }

      else
      {
        nativeColumn.Length = Point.Distance(speckleElement.end1Node.basePoint, speckleElement.end2Node.basePoint);
      }

      if (speckleProperty.profile.shapeType == ShapeType.Rectangular)
      {
        var sectionProfile = (Rectangular)speckleProperty.profile;
        nativeColumn.Width = sectionProfile.width;
        nativeColumn.Depth = sectionProfile.depth;
      }

      else if (speckleProperty.profile.shapeType == ShapeType.Circular)
      {
        var sectionProfile = (Circular)speckleProperty.profile;

        nativeColumn.Width = sectionProfile.radius * 2;
        nativeColumn.Depth = 0;
      }

      else
      {
        throw new NotSupportedException($"Support for only {Objects.Structural.ShapeType.Circular} and {Objects.Structural.ShapeType.Rectangular} shapes");
      }

      return nativeColumn;
    }

    public Concrete ConcreteToNative(SM.Material material)
    {
      if (material == null)
      {
        return new Concrete();
      }

      var materialType = material.GetType();

      if (materialType == typeof(SM.Material) || materialType == typeof(GSAMaterial))
      {
        return new Concrete()
        {
          Grade = material.grade,
          CompressiveStrength = material.strength,
          IsLightweight = false,
          ElasticModulus = material.elasticModulus
        };
      }

      else if (materialType == typeof(SM.Concrete) || materialType == typeof(GSAConcrete))
      {
        var castedMaterial = (SM.Concrete)material;

        return new Concrete()
        {
          Grade = castedMaterial.grade,
          CompressiveStrength = castedMaterial.compressiveStrength,
          IsLightweight = castedMaterial.lightweight,
          ElasticModulus = castedMaterial.elasticModulus
        };
      }

      else
      {
        throw new NotSupportedException($"{typeof(SM.Material).FullName} is not supported.");
      }
    }

    public Concrete Property1DToNative(Property1D property1d)
    {
      var material = property1d.material;

      if (material == null && property1d.GetType() == typeof(GSAProperty1D))
      {
        var gsaProperty1d = (GSAProperty1D)property1d;
        material = gsaProperty1d.designMaterial;
      }

      if (material == null || material.materialType != MaterialType.Concrete)
      {
        throw new NotSupportedException("Material must be concrete and not null;");
      }

      var nativeConcrete = ConcreteToNative(material);

      return nativeConcrete;
    }
    #endregion
  }
}
