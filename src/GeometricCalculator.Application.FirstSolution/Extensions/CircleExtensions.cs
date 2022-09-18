using System;
using GeometricCalculator.Core.Figures.TwoDimensionalFigures.Circle;

namespace GeometricCalculator.Application.FirstSolution.Extensions;

public static class CircleExtensions
{
    public static double CalculateArea(this Circle circle, int? roundUpTo = null)
    {
        var area = Math.PI * Math.Pow(circle.Radius, 2);
        if (roundUpTo.HasValue)
        {
            area = Math.Round(area, roundUpTo.Value);
        }

        return area;
    }
}