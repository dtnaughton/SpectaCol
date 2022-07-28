﻿using SpectaCol.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Commands
{
  public class ToggleDialogVisibilityCommand : CommandBase
  {
    private readonly NavigationStore _navigationStore;

    public ToggleDialogVisibilityCommand(NavigationStore navigationStore)
    {
      _navigationStore = navigationStore;
    }

    public override void Execute(object? parameter)
    {
      _navigationStore.IsDialogOpen = !_navigationStore.IsDialogOpen;
    }
  }
}
