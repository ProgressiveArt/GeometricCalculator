using System;
using System.Linq;
using GeometricCalculator.Core.Figures.TwoDimensionalFigures.ArbitraryPolygon;

namespace GeometricCalculator.Application.SecondSolution.Strategies.Implementations;

public sealed class CalculateArbitraryPolygonStrategy : BaseCalculateStrategy<ArbitraryPolygon>
{
    public override double CalculateArea(ArbitraryPolygon figure, int? roundUpTo = null)
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