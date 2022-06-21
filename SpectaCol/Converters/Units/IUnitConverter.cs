using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpectaCol.Settings.Units;

namespace SpectaCol.Converters.Units
{
  public interface IUnitConverter
  {
    double GetForceScaleFactor(ForceUnit currentForceUnit, ForceUnit updatedForceUnit);
    double GetLengthScaleFactor(LengthUnit currentLengthUnit, LengthUnit updatedLengthUnit);
  }
}
