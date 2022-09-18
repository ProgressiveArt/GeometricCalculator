using GeometricCalculator.Core.Figures.TwoDimensionalFigures;

namespace GeometricCalculator.Application.SecondSolution.Strategies;

public interface ICalculateStrategy
{
    double CalculateArea<TFigure>(TFigure figure, int? roundUpTo = null) where TFigure : Figure;
}

public interface ICalculateStrategy<in TFigure> where TFigure : Figure
{
    double CalculateArea(TFigure figure, int? roundUpTo = null);
    ICalculateStrategy AsCalculateStrategy();
}