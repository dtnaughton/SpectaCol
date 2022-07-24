using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.Results
{
  public class FrameResult
  {
    public double Axial { get; set; }
    public double ShearX { get; set; }
    public double ShearY { get; set; }
    public double MomentX { get; set; }
    public double MomentY { get; set; }
    public double Torsion{ get; set; }
    public double Position { get; set; }
    public string? LoadCombination { get; set; }
    public int? Index { get; set; }
    public string? AssociatedElementId { get; set; }
    public FrameResult(double axial, double shearX, double shearY, double momentX, double momentY, double torsion, double position, string? loadCombination, string? associatedElementId, int? index)
    {
      Axial = axial;
      ShearX = shearX;
      ShearY = shearY;
      MomentX = momentX;
      MomentY = momentY;
      Torsion = torsion;
      Position = position;
      LoadCombination = loadCombination;
      AssociatedElementId = associatedElementId;
      Index = index;
    }
  }
}
