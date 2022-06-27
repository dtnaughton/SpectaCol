using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.Interfaces
{
  public interface IDesignParameter
  {
    bool HasDefaultParameters();
    void SetDefaultParameters();
  }
}
