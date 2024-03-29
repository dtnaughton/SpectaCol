﻿using SpectaCol.Services;
using SpectaCol.Stores;
using SpectaCol.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Commands
{
  public class LogoutCommand : CommandBase
  {
    private readonly AccountStore _accountStore;
    private readonly INavigationService _navigationService;

    public LogoutCommand(AccountStore accountStore, INavigationService navigationService)
    {
      _accountStore = accountStore;
      _navigationService = navigationService;
    }

    public override void Execute(object? parameter)
    {
      _accountStore.ClearSelectedAccount();
      _navigationService.Navigate();
    }
  }
}
