using System;
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
      WhitneyCompressionArea = GetWhitneyCompressionArea(StressBlockShape, sectionWidth, sectionDepth, WhitneyDepth, angleDegs);
    }

    private StressBlockShape GetStressBlockShape(double whitneyDepth, double angleDeg, double sectionWidth, double sectionDepth)
    {
      // if angle is 90, 180, 270, or 360 then it is rectangular by default and avoids division by zero errors
      if (IsVertical(angleDeg) || IsHorizontal(angleDeg) || ExceedsMaxDepth(whitneyDepth, sectionWidth, sectionDepth, angleDeg)) 
      {
        return StressBlockShape.Rectangle;
      }

      var angleRad = ConvertDegreesToRadians(angleDeg);
      _hypotenuseWidth = Math.Abs(whitneyDepth / Math.Sin(angleRad));
      _hypotenuseDepth = Math.Abs(whitneyDepth / Math.Cos(angleRad));

      if (!HypotenuseDepthGoverns(_hypotenuseDepth, sectionDepth) && !HypotenuseWidthGoverns(_hypotenuseWidth, sectionWidth))
      {
        return StressBlockShape.Triangle;
      }

      else if ((!HypotenuseDepthGoverns(_hypotenuseDepth, sectionDepth) && HypotenuseWidthGoverns(_hypotenuseWidth, sectionWidth)) || (HypotenuseDepthGoverns(_hypotenuseDepth, sectionDepth) && !HypotenuseWidthGoverns(_hypotenuseWidth, sectionWidth)))
      {
        return StressBlockShape.Trapezoid;
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

    private bool IsHorizontal(double angleDeg)
    {
      return angleDeg == 0 || angleDeg == 180 || angleDeg == 360;
    }

    private bool IsVertical(double angleDeg)
    {
      return angleDeg == 90 || angleDeg == 270;
    }

    private bool ExceedsMaxDepth(double whitneyDepth, double sectionWidth, double sectionDepth, double angleDeg)
    {
      var maxNaDepth = MaximumNeutralAxisDepth(sectionWidth, sectionDepth, angleDeg);

      return whitneyDepth > maxNaDepth;
    }

    private double GetWhitneyCompressionArea(StressBlockShape stressBlockShape, double sectionWidth, double sectionDepth, double whitneyDepth, double angleDeg)
    {
      var angleRad = ConvertDegreesToRadians(angleDeg);

      if (stressBlockShape == StressBlockShape.Rectangle)
      {
        var exceedsMax = ExceedsMaxDepth(whitneyDepth, sectionWidth, sectionDepth, angleDeg);

        if (IsHorizontal(angleDeg) && !exceedsMax)
        {
          return sectionWidth * whitneyDepth;
        }

        else if (IsVertical(angleDeg) && !exceedsMax)
        {
          return sectionDepth * whitneyDepth;
        }

        else
        {
          return sectionWidth * sectionDepth;
        }
      }

      else if (stressBlockShape == StressBlockShape.Triangle)
      {
        return _hypotenuseWidth * _hypotenuseDepth * 0.5;
      }

      else if (stressBlockShape == StressBlockShape.Trapezoid)
      {
        if (HypotenuseWidthGoverns(_hypotenuseWidth, sectionWidth))
        {
          var triangleHeight = sectionWidth * Math.Abs(Math.Tan(angleRad));
          var triangleArea = sectionWidth * triangleHeight * 0.5;

          var rectangleHeight = (whitneyDepth / Math.Abs(Math.Cos(angleRad))) - triangleHeight;
          var rectangleArea = rectangleHeight * sectionWidth;

          return triangleArea + rectangleArea;
        }

        // HypotenuseDepth must govern
        else
        {
          var triangleHeight = sectionDepth / Math.Abs(Math.Tan(angleRad));
          var triangleArea = triangleHeight * sectionDepth * 0.5;

          var rectangleHeight = (whitneyDepth / Math.Abs(Math.Sin(angleRad))) - triangleHeight;
          var rectangleArea = rectangleHeight * sectionDepth;

          return triangleArea + rectangleArea;
        }
      }

      // Must be pentagon
      else
      {
        var primaryRectangleWidth = (whitneyDepth / Math.Abs(Math.Cos(angleRad)) - sectionDepth) / Math.Abs(Math.Tan(angleRad));
        var primaryRectangleArea = primaryRectangleWidth * sectionDepth;

        var triangleWidth = sectionWidth - primaryRectangleWidth;
        var triangleHeight = triangleWidth * Math.Abs(Math.Tan(angleRad));
        var triangleArea = triangleWidth * triangleHeight * 0.5;

        var secondaryRectangleArea = triangleWidth * (sectionDepth - triangleHeight);

        return triangleArea + primaryRectangleArea + secondaryRectangleArea;
      }
    }

    private double ConvertDegreesToRadians(double angleDeg)
    {
      return angleDeg * Math.PI / 180;
    }

    private double MaximumNeutralAxisDepth(double sectionWidth, double sectionDepth, double naAngleDeg)
    {
      var angleRad = ConvertDegreesToRadians(naAngleDeg);
      return (Math.Abs(sectionDepth / Math.Tan(angleRad)) + sectionWidth) * Math.Abs(Math.Sin(angleRad));
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
