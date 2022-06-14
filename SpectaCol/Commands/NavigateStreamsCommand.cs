using Speckle.Core.Api;
using SpectaCol.Services;
using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Commands
{
  public class NavigateStreamsCommand : CommandBase
  {
    private readonly AccountStore _accountStore;
    private readonly INavigationService _navigationService;
    private int _streamsLimit = 25; // expose this on settings

    public NavigateStreamsCommand(AccountStore accountStore, INavigationService navigationService)
    {
      _accountStore = accountStore;
      _navigationService = navigationService;
    }

    public override async void Execute(object? parameter)
    {
      if (_accountStore.SelectedAccount != null)
      {
        var speckleClient = new Client(_accountStore.SelectedAccount);
        _accountStore.Streams = await speckleClient.StreamsGet(_streamsLimit);
      }

      _navigationService.Navigate();

    }
  }
}
