using SpectaCol.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.Geometry
{
  public class CrossSectionParameters : IDesignParameter
  {
    public double Width { get; set; }
    public double Depth { get; set; }
    public double Cover { get; set; }

    public CrossSectionParameters()
    {
      SetDefaultParameters();
    }

    public CrossSectionParameters(double width, double depth, double cover)
    {
      Width = width;
      Depth = depth;
      Cover = cover;
    }

    public void SetDefaultParameters()
    {
      if (Width == 0) Width = 400;
      if (Depth == 0) Depth = 400;
      if (Cover == 0) Cover = 40;
    }

    public bool HasDefaultParameters()
    {
      throw new NotImplementedException();
    }
  }
}
