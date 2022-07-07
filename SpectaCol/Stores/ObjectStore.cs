using SpectaCol.Models.Interfaces;
using SpectaCol.Models.Results;
using SpectaCol.Models.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Stores
{
  public class ObjectStore
  {
    public List<IConcreteSection>? ConcreteColumns { get; set; } = new List<IConcreteSection>();

    public List<FrameResult>? Results { get; set; } = new List<FrameResult>();

    public void SyncColumnResults()
    {
      if (ConcreteColumns != null && Results != null)
      {
        foreach (var column in ConcreteColumns)
        {
          column.ForceResults = Results.Where(result => result.AssociatedElementId == column.ApplicationId).ToList();
        }
      }
    }
  }
}
