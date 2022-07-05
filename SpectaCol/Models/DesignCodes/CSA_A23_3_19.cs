using SpectaCol.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.DesignCodes
{
  public class CSA_A23_3_19 : IDesignCode
  {
    public DesignCode Title { get; }

    public CSA_A23_3_19()
    {
      Title = DesignCode.A23319;
    }

    public double CalculateCompressionResistance()
    {
      //Temp
      return 1000;
    }
  }
}
