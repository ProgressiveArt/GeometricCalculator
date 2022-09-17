using GeometricCalculator.Application.SecondSolution.Strategies;
using GeometricCalculator.Core.Interfaces;

namespace GeometricCalculator.Application.SecondSolution.Extensions;

public static class FigureExtensions
{
    public static double CalculateArea(this IFigure figure,
        ICalculateStrategy strategy,
        int? roundUpTo) => strategy.CalculateArea((dynamic) figure, roundUpTo);
}