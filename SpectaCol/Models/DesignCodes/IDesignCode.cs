﻿using SpectaCol.Models.Interfaces;
using SpectaCol.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.DesignCodes
{
  public interface IDesignCode
  {
    DesignCode Title { get; }
    void DesignColumns(List<IConcreteSection> concreteSections);
    double CalculateCompressionResistance();
  }
}
