﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.Interfaces
{
  public interface IMaterial : IDesignParameter
  {
    string Grade { get; set; }
    double ElasticModulus { get; set; }
  }
}
