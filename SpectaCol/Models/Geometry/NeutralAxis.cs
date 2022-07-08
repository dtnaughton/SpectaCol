﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.Models.Geometry
{
  public class NeutralAxis
  {
    private double _hypotenuseWidth;
    private double _hypotenuseDepth;
    public double Depth { get; }
    public double WhitneyDepth { get; }
    public double Angle { get; }
    public StressBlockShape StressBlockShape { get; }
    public double WhitneyCompressionArea { get; }

    public NeutralAxis(double naDepth, double angleDegs, double beta, double sectionWidth, double sectionDepth)
    {
      Depth = naDepth;
      WhitneyDepth = naDepth * beta;
      Angle = angleDegs;
      StressBlockShape = GetStressBlockShape(WhitneyDepth, Angle, sectionWidth, sectionDepth);
    }

    private StressBlockShape GetStressBlockShape(double whitneyDepth, double angleDeg, double sectionWidth, double sectionDepth)
    {
      // if angle is 90, 180, 270, or 360 then it is rectangular by default and avoids division by zero errors
      if (angleDeg == 90 || angleDeg == 180 || angleDeg == 270 || angleDeg == 360)
      {
        return StressBlockShape.Trapezoid;
      }

      var angleRad = ConvertDegreesToRadians(angleDeg);
      _hypotenuseWidth = Math.Abs(whitneyDepth / Math.Sin(angleRad));
      _hypotenuseDepth = Math.Abs(whitneyDepth / Math.Cos(angleRad));

      if (_hypotenuseDepth <= sectionDepth && _hypotenuseWidth <= sectionWidth)
      {
        return StressBlockShape.Triangle;
      }
      
      else if ((_hypotenuseDepth <= sectionDepth && _hypotenuseWidth > sectionWidth) || (_hypotenuseDepth > sectionDepth && _hypotenuseWidth <= sectionWidth))
      {
        return StressBlockShape.Trapezoid;
      }

      // if code reaches this point, shape is either pentagon or full rectangle shape in compression

      var maxNaDepth = MaximumNeutralAxisDepth(sectionWidth, sectionDepth, angleDeg);

      if (whitneyDepth > maxNaDepth)
      {
        return StressBlockShape.Rectangle;
      }

      else
      {
        return StressBlockShape.Pentagon;
      }
    }

    private bool HypotenuseDepthGoverns(double _hypotenuseDepth, double sectionDepth)
    {
      return _hypotenuseDepth > sectionDepth;
    }

    private bool HypotenuseWidthGoverns(double _hypotenuseWidth, double sectionWidth)
    {
      return _hypotenuseWidth > sectionWidth;
    }

    private double GetWhitneyCompressionArea(StressBlockShape stressBlockShape, double sectionWidth, double sectionDepth)
    {
      if (stressBlockShape == StressBlockShape.Rectangle)
      {
        return sectionWidth * sectionDepth;
      }

      else if (stressBlockShape == StressBlockShape.Triangle)
      {
        return _hypotenuseWidth * _hypotenuseDepth * 0.5;
      }

      else if (stressBlockShape == StressBlockShape.Trapezoid)
      {
        return 0;
      }

      return 0;
    }

    private double ConvertDegreesToRadians(double angleDeg)
    {
      return angleDeg * Math.PI / 180;
    }

    private double MaximumNeutralAxisDepth(double sectionWidth, double sectionDepth, double naAngleDeg)
    {
      var angleRad = ConvertDegreesToRadians(naAngleDeg);

      return (Math.Abs((sectionDepth / Math.Tan(angleRad)) + sectionWidth) * Math.Abs(Math.Sin(angleRad)));
    }
  }

  public enum StressBlockShape
  {
    Triangle,
    Trapezoid,
    Pentagon,
    Rectangle
  }
}