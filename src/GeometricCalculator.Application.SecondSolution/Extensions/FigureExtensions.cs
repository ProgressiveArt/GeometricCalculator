using GeometricCalculator.Application.SecondSolution.Strategies;
using GeometricCalculator.Core.Figures.TwoDimensionalFigures;

namespace GeometricCalculator.Application.SecondSolution.Extensions;

public static class FigureExtensions
{
    public static double CalculateArea(this Figure figure,
        ICalculateStrategy strategy,
        int? roundUpTo) => strategy.CalculateArea((dynamic) figure, roundUpTo);
}