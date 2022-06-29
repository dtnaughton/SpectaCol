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
    public List<ConcreteColumn>? ConcreteColumns { get; set; } = new List<ConcreteColumn>();

    public List<FrameResult>? ColumnResults { get; set; } = new List<FrameResult>();
  }
}
