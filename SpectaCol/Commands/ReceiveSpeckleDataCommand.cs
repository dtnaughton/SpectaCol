using Speckle.Core.Api;
using Speckle.Core.Transports;
using SpectaCol.Converters;
using SpectaCol.Models.Sections;
using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Commands
{
  public class ReceiveSpeckleDataCommand : CommandBase
  {
    private readonly AccountStore _accountStore;
    private readonly ObjectStore _objectStore;

    public ReceiveSpeckleDataCommand(AccountStore accountStore, ObjectStore objectStore)
    {
      _accountStore = accountStore;
      _objectStore = objectStore;
    }

    public override async void Execute(object? parameter)
    {
      var transport = new ServerTransport(_accountStore?.SelectedAccount, _accountStore?.SelectedStream?.id);

      var converter = new SpectaColConverter(_objectStore); // add this to store?

      var commitObj = await Operations.Receive(_accountStore?.SelectedCommit?.referencedObject, transport);

      var flattenedCommitObj = ConversionUtils.FlattenCommitObject(commitObj, converter);

      var convertedObjects = converter.ConvertToNative(flattenedCommitObj);

      var column = _objectStore.ConcreteColumns;
      var results = _objectStore.ColumnResults;

      _accountStore?.InvokeSelectedTargetChanged();
    }
  }
}
