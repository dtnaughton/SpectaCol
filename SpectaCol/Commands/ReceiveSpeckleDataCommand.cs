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

      var converter = new SpectaColConverter(); // add this to store?

      var commitObj = await Operations.Receive(_accountStore?.SelectedCommit?.referencedObject, transport);

      var flattenedCommitObj = ConversionUtils.FlattenCommitObject(commitObj, converter);

      _objectStore.ConcreteColumns = converter.ConvertToNative(flattenedCommitObj).Cast<ConcreteColumn>().ToList();

      _accountStore?.InvokeSelectedTargetChanged();
    }
  }
}
