using System;
using GeometricCalculator.Core.Figures.TwoDimensionalFigures.Triangle;

namespace GeometricCalculator.Application.FirstSolution.Extensions;

public static class TriangleExtensions
{
    public static double CalculateArea(this Triangle triangle, int? roundUpTo = null)
    {
        var perimeter = triangle.A + triangle.B + triangle.C;
        var area = Math.Sqrt(perimeter / 2 * (perimeter / 2 - triangle.A) * (perimeter / 2 - triangle.B) * (perimeter / 2 - triangle.C));
        if (roundUpTo.HasValue)
        {
            area = Math.Round(area, roundUpTo.Value);
        }

        return area;
    }
}