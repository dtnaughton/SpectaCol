using Speckle.Core.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.ViewModels
{
  public class StreamViewModel : ViewModelBase
  {
    private readonly Stream _stream;
    public string StreamName => _stream.name;
    public string StreamDetails => $"{_stream.id} - {_stream.role}";
    public string StreamId => _stream.id;
    public string UpdatedAt => $"Last updated: {ViewModelUtilities.UpdatedTimeAgo(_stream.updatedAt)}";
    public StreamViewModel(Stream stream)
    {
      _stream = stream;
    }

    

  }

}
