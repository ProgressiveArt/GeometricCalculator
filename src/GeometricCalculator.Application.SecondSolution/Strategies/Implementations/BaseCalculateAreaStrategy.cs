using GeometricCalculator.Core.Figures.TwoDimensionalFigures;
using GeometricCalculator.Core.Interfaces;

namespace GeometricCalculator.Application.SecondSolution.Strategies.Implementations;

public abstract class BaseCalculateStrategy<TFigure> : IFactory, ICalculateStrategy<TFigure> where TFigure : Figure
{
    public abstract double CalculateArea(TFigure figure, int? roundUpTo = null);

    public ICalculateStrategy AsCalculateStrategy()
    {
        return CalculateStrategyAdapter.SetStrategy(this);
    }
}