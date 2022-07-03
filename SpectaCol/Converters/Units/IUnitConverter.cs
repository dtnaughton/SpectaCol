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
    double GetForceScaleFactor(MetricForceUnit currentForceUnit, MetricForceUnit updatedForceUnit);
    double GetLengthScaleFactor(MetricLengthUnit currentLengthUnit, MetricLengthUnit updatedLengthUnit);
  }
}
