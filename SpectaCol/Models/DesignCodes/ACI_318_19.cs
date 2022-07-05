using SpectaCol.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.DesignCodes
{
  public class ACI_318_19 : IDesignCode
  {
    public DesignCode Title { get; }

    public ACI_318_19()
    {
      Title = DesignCode.ACI31819;
    }

    public double CalculateCompressionResistance()
    {
      throw new NotImplementedException();
    }
  }
}
