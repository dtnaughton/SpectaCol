using SpectaCol.Converters.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static SpectaCol.Settings.Units;

namespace SpectaColTests.UnitConversionTests
{
  public class UnitConversionTests
  {
    [Fact]
    public void Metric_To_Imperial_Length_Conversion()
    {
      var mmToInch = 345.43 * UnitConverter.MetricToImperialScaleFactor(MetricLengthUnit.mm, ImperialLengthUnit.Inches);
      var mmToFeet = 501439.213 * UnitConverter.MetricToImperialScaleFactor(MetricLengthUnit.mm, ImperialLengthUnit.Feet);
      var cmToInch = 213 * UnitConverter.MetricToImperialScaleFactor(MetricLengthUnit.cm, ImperialLengthUnit.Inches);
      var cmToFeet = 40.3 * UnitConverter.MetricToImperialScaleFactor(MetricLengthUnit.cm, ImperialLengthUnit.Feet);
      var mToInch = 213 * UnitConverter.MetricToImperialScaleFactor(MetricLengthUnit.m, ImperialLengthUnit.Inches);
      var mToFeet = 23.3 * UnitConverter.MetricToImperialScaleFactor(MetricLengthUnit.m, ImperialLengthUnit.Feet);

      Assert.Equal(13.5996063, mmToInch, 1);
      Assert.Equal(1645.141774934, mmToFeet, 1);
      Assert.Equal(83.8583, cmToInch, 1);
      Assert.Equal(1.322178, cmToFeet, 1);
      Assert.Equal(8385.83, mToInch, 1);
      Assert.Equal(76.44357, mToFeet, 1);
    }

    [Fact]
    public void Imperial_To_Metric_Length_Conversion()
    {
      var inchToMm = 401432.23 * UnitConverter.ImperialToMetricScaleFactor(ImperialLengthUnit.Inches, MetricLengthUnit.mm);
      var inchToCm = 5324 * UnitConverter.ImperialToMetricScaleFactor(ImperialLengthUnit.Inches, MetricLengthUnit.cm);
      var inchToM = 523432.12 * UnitConverter.ImperialToMetricScaleFactor(ImperialLengthUnit.Inches, MetricLengthUnit.m);
      var feetToMm = 993.23 * UnitConverter.ImperialToMetricScaleFactor(ImperialLengthUnit.Feet, MetricLengthUnit.mm);
      var feetToCm = 95132.1 * UnitConverter.ImperialToMetricScaleFactor(ImperialLengthUnit.Feet, MetricLengthUnit.cm);
      var feetToM = 1234.1 * UnitConverter.ImperialToMetricScaleFactor(ImperialLengthUnit.Feet, MetricLengthUnit.m);

      Assert.Equal(10196378.642, inchToMm, 1);
      Assert.Equal(13522.96, inchToCm, 1);
      Assert.Equal(13295.175848, inchToM, 1);
      Assert.Equal(302736.504, feetToMm, 1);
      Assert.Equal(2899626.408, feetToCm, 1);
      Assert.Equal(376.15368, feetToM, 1);
    }

    [Fact]
    public void Metric_To_Imperial_Force_Conversion()
    {
      var nToPounds = 9253214.123 * UnitConverter.MetricToImperialScaleFactor(MetricForceUnit.N, ImperialForceUnit.Pounds);
      var nToKips = 23129253214.123 * UnitConverter.MetricToImperialScaleFactor(MetricForceUnit.N, ImperialForceUnit.Kips);
      var kNToPounds = 452341 * UnitConverter.MetricToImperialScaleFactor(MetricForceUnit.kN, ImperialForceUnit.Pounds);
      var kNToKips = 1356.3241 * UnitConverter.MetricToImperialScaleFactor(MetricForceUnit.kN, ImperialForceUnit.Kips);

      Assert.Equal(2080205.2944035, nToPounds, 0);
      Assert.Equal(5199662.9698, nToKips, 0);
      Assert.Equal(101690302, kNToPounds, 0);
      Assert.Equal(304.91378742, kNToKips, 0);
    }

    [Fact]
    public void Imperial_To_Metric_Force_Conversion()
    {
      var poundsToN = 3432419.321 * UnitConverter.ImperialToMetricScaleFactor(ImperialForceUnit.Pounds, MetricForceUnit.N);
      var poundsToKn = 54324 * UnitConverter.ImperialToMetricScaleFactor(ImperialForceUnit.Pounds, MetricForceUnit.kN);
      var KipsToN = 6434.1 * UnitConverter.ImperialToMetricScaleFactor(ImperialForceUnit.Kips, MetricForceUnit.N);
      var KipsToKn = 634624.34 * UnitConverter.ImperialToMetricScaleFactor(ImperialForceUnit.Kips, MetricForceUnit.kN);

      Assert.Equal(15268161.816, poundsToN, 0);
      Assert.Equal(241.64519, poundsToKn, 0);
      Assert.Equal(28620302.59656, KipsToN, 0);
      Assert.Equal(2822949.697073744, KipsToKn, 0);
    }

    [Fact]
    public void Metric_To_Imperial_Stress_Conversion()
    {
      var mPaToKsi = 5982 * UnitConverter.MetricToImperialScaleFactor(MetricStressUnit.mPa, ImperialStressUnit.Ksi);
      var mPaToPsi = 5982 * UnitConverter.MetricToImperialScaleFactor(MetricStressUnit.mPa, ImperialStressUnit.Psi);
      var kPaToKsi = 5982 * UnitConverter.MetricToImperialScaleFactor(MetricStressUnit.kPa, ImperialStressUnit.Ksi);
      var kPaToPsi = 5982 * UnitConverter.MetricToImperialScaleFactor(MetricStressUnit.kPa, ImperialStressUnit.Psi);

      Assert.Equal(867.6157, mPaToKsi, 3);
      Assert.Equal(867615.7471, mPaToPsi, 3);
      Assert.Equal(0.8676157, kPaToKsi, 3);
      Assert.Equal(867.6157, kPaToPsi, 3);
    }

    [Fact]
    public void Imperial_To_Metric_Stress_Conversion()
    {
      var ksiToMpa = 1231 * UnitConverter.ImperialToMetricScaleFactor(ImperialStressUnit.Ksi, MetricStressUnit.mPa);
      var ksiToKpa = 1231 * UnitConverter.ImperialToMetricScaleFactor(ImperialStressUnit.Ksi, MetricStressUnit.kPa);
      var psiToMpa = 1231 * UnitConverter.ImperialToMetricScaleFactor(ImperialStressUnit.Psi, MetricStressUnit.mPa);
      var psiToKpa = 1231 * UnitConverter.ImperialToMetricScaleFactor(ImperialStressUnit.Psi, MetricStressUnit.kPa);

      Assert.Equal(8487.4462279, ksiToMpa, 3);
      Assert.Equal(8487446.2279, ksiToKpa, 3);
      Assert.Equal(8.4874462279, psiToMpa, 3);
      Assert.Equal(8487.4462279, psiToKpa, 3);
    }

    [Fact]
    public void Metric_Length_Conversion()
    {
      var mmToMm = 3420 * UnitConverter.MetricScaleFactor(MetricLengthUnit.mm, MetricLengthUnit.mm);
      var mmToCm = 3420 * UnitConverter.MetricScaleFactor(MetricLengthUnit.mm, MetricLengthUnit.cm);
      var mmToM = 3420 * UnitConverter.MetricScaleFactor(MetricLengthUnit.mm, MetricLengthUnit.m);
      var cmToMm = 3420 * UnitConverter.MetricScaleFactor(MetricLengthUnit.cm, MetricLengthUnit.mm);
      var cmToCm = 3420 * UnitConverter.MetricScaleFactor(MetricLengthUnit.cm, MetricLengthUnit.cm);
      var cmToM = 3420 * UnitConverter.MetricScaleFactor(MetricLengthUnit.cm, MetricLengthUnit.m);
      var mToMm = 3420 * UnitConverter.MetricScaleFactor(MetricLengthUnit.m, MetricLengthUnit.mm);
      var mToCm = 3420 * UnitConverter.MetricScaleFactor(MetricLengthUnit.m, MetricLengthUnit.cm);
      var mToM = 3420 * UnitConverter.MetricScaleFactor(MetricLengthUnit.m, MetricLengthUnit.m);

      Assert.Equal(3420, mmToMm, 3);
      Assert.Equal(342, mmToCm, 3);
      Assert.Equal(3.42, mmToM, 3);
      Assert.Equal(34200, cmToMm, 3);
      Assert.Equal(3420, cmToCm, 3);
      Assert.Equal(34.2, cmToM, 3);
      Assert.Equal(3420000, mToMm, 3);
      Assert.Equal(342000, mToCm, 3);
      Assert.Equal(3420, mToM, 3);
    }

    [Fact]
    public void Metric_Force_Conversion()
    {
      var nToN = 5432 * UnitConverter.MetricScaleFactor(MetricForceUnit.N, MetricForceUnit.N);
      var nToKn = 5432 * UnitConverter.MetricScaleFactor(MetricForceUnit.N, MetricForceUnit.kN);
      var knToN = 5432 * UnitConverter.MetricScaleFactor(MetricForceUnit.kN, MetricForceUnit.N);
      var knToKn = 5432 * UnitConverter.MetricScaleFactor(MetricForceUnit.kN, MetricForceUnit.kN);

      Assert.Equal(5432, nToN, 3);
      Assert.Equal(5.432, nToKn, 3);
      Assert.Equal(5432000, knToN, 3);
      Assert.Equal(5432, knToKn, 3);
    }

    [Fact]
    public void Metric_Stress_Conversion()
    {
      var mPaToMpa = 4132.23 * UnitConverter.MetricScaleFactor(MetricStressUnit.mPa, MetricStressUnit.mPa);
      var mPaToKpa = 4132.23 * UnitConverter.MetricScaleFactor(MetricStressUnit.mPa, MetricStressUnit.kPa);
      var kPaToMpa = 4132.23 * UnitConverter.MetricScaleFactor(MetricStressUnit.kPa, MetricStressUnit.mPa);
      var kPaToKpa = 4132.23 * UnitConverter.MetricScaleFactor(MetricStressUnit.kPa, MetricStressUnit.kPa);

      Assert.Equal(4132.23, mPaToMpa, 3);
      Assert.Equal(4132230, mPaToKpa, 3);
      Assert.Equal(4.13223, kPaToMpa, 3);
      Assert.Equal(4132.23, kPaToKpa, 3);
    }

    [Fact]
    public void Imperial_Force_Conversion()
    {
      var poundsToPounds = 3230 * UnitConverter.ImperialScaleFactor(ImperialForceUnit.Pounds, ImperialForceUnit.Pounds);
      var poundsToKips = 3230 * UnitConverter.ImperialScaleFactor(ImperialForceUnit.Pounds, ImperialForceUnit.Kips);
      var kipsToPounds = 3230 * UnitConverter.ImperialScaleFactor(ImperialForceUnit.Kips, ImperialForceUnit.Pounds);
      var kipsToKips = 3230 * UnitConverter.ImperialScaleFactor(ImperialForceUnit.Kips, ImperialForceUnit.Kips);

      Assert.Equal(3230, poundsToPounds, 3);
      Assert.Equal(3.230, poundsToKips, 3);
      Assert.Equal(3230000, kipsToPounds, 3);
      Assert.Equal(3230, kipsToKips, 3);
    }

    [Fact]
    public void Imperial_Stress_Conversion()
    {
      var psiToPsi = 5203.235 * UnitConverter.ImperialScaleFactor(ImperialStressUnit.Psi, ImperialStressUnit.Psi);
      var psiToKsi = 5203.235 * UnitConverter.ImperialScaleFactor(ImperialStressUnit.Psi, ImperialStressUnit.Ksi);
      var ksiToPsi = 5203.235 * UnitConverter.ImperialScaleFactor(ImperialStressUnit.Ksi, ImperialStressUnit.Psi);
      var ksiToKsi = 5203.235 * UnitConverter.ImperialScaleFactor(ImperialStressUnit.Ksi, ImperialStressUnit.Ksi);

      Assert.Equal(5203.235, psiToPsi, 3);
      Assert.Equal(5.2032350023, psiToKsi, 3);
      Assert.Equal(5203235, ksiToPsi, 3);
      Assert.Equal(5203.235, ksiToKsi, 3);
    }

    [Fact]
    public void Imperial_Length_Conversion()
    {
      var inchToInch = 439 * UnitConverter.ImperialScaleFactor(ImperialLengthUnit.Inches, ImperialLengthUnit.Inches);
      var inchToFeet = 439 * UnitConverter.ImperialScaleFactor(ImperialLengthUnit.Inches, ImperialLengthUnit.Feet);
      var feetToInches = 439 * UnitConverter.ImperialScaleFactor(ImperialLengthUnit.Feet, ImperialLengthUnit.Inches);
      var feetToFeet = 439 * UnitConverter.ImperialScaleFactor(ImperialLengthUnit.Feet, ImperialLengthUnit.Feet);

      Assert.Equal(439, inchToInch, 3);
      Assert.Equal(36.58333333, inchToFeet, 3);
      Assert.Equal(5268, feetToInches, 3);
      Assert.Equal(439, feetToFeet, 3);
    }
  }
}
