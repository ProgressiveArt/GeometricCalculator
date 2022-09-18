using System;
using System.Linq;
using GeometricCalculator.Core.Figures.TwoDimensionalFigures.ArbitraryPolygon;

namespace GeometricCalculator.Application.FirstSolution.Extensions;

public static class ArbitraryPolygonExtensions
{
    public static double CalculateArea(this ArbitraryPolygon figure, int? roundUpTo = null)
    {
        double area = 0;
        var vertices = figure.Vertices.ToList();
        var endVertex = vertices.First();
        vertices.Add(endVertex);

        for (var i = 0; i < vertices.Count - 1; i++)
        {
            var currentVertex = vertices[i];
            var nextVertex = vertices[i + 1];
            area += (currentVertex.X + nextVertex.X) * (currentVertex.Y - nextVertex.Y);
        }

        area = 0.5 * Math.Abs(area);

        if (roundUpTo.HasValue)
        {
            area = Math.Round(area, roundUpTo.Value);
        }

        return area;
    }
}