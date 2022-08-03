using SpectaCol.ForceSolvingMethods;
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
    public IConcreteSection? SelectedConcreteColumn { get; set; }

    public List<FrameResult>? Results { get; set; } = new List<FrameResult>();

    public void SyncColumnResults()
    {
      if (ConcreteColumns != null && Results != null)
      {
        foreach (var column in ConcreteColumns)
        {
          // Finds results specific to selected column
          var allColumnResults = Results.Where(result => result.AssociatedElementId == column.ApplicationId).ToList();

          foreach (var colResult in allColumnResults)
          {
            var theta = ForceEquilibriumMethods.GetMomentAngle(colResult.MomentX, colResult.MomentY);

            var existingMomentPlane = column.Forces.Where(x => x.Key.Theta == theta).FirstOrDefault();

            // No axial moment plane with theta existing
            if (existingMomentPlane.Equals(default(KeyValuePair<AxialMomentPlane, List<FrameResult>>)))
            {
              column.Forces.Add(new AxialMomentPlane(theta), new List<FrameResult>() { colResult });
            }

            else
            {
              column.Forces[existingMomentPlane.Key].Add(colResult);
            }
          }

        }
      }
    }
  }
}
