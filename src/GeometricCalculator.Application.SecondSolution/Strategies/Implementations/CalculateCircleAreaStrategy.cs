using System;
using GeometricCalculator.Core.Figures.TwoDimensionalFigures.Circle;

namespace GeometricCalculator.Application.SecondSolution.Strategies.Implementations;

public sealed class CalculateCircleStrategy : BaseCalculateStrategy<Circle>
{
    public override double CalculateArea(Circle circle, int? roundUpTo = null)
    {
        var area = Math.PI * Math.Pow(circle.Radius, 2);
        if (roundUpTo.HasValue)
        {
            area = Math.Round(area, roundUpTo.Value);
        }

        return area;
    }
}