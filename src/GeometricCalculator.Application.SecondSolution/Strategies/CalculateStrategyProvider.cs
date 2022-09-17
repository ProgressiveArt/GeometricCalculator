using System;
using GeometricCalculator.Core.Figures.TwoDimensionalFigures;
using GeometricCalculator.Core.Interfaces;

namespace GeometricCalculator.Application.SecondSolution.Strategies;

public class CalculateStrategyProvider : IFactory
{
    private readonly IServiceProvider _serviceProvider;

    public CalculateStrategyProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ICalculateStrategy GetStrategy<TFigure>(TFigure figure) where TFigure : Figure
    {
        var strategy = ResolveStrategy(figure as dynamic);
        if (ReferenceEquals(strategy, null))
        {
            throw new ArgumentNullException(nameof(strategy), "Not found");
        }

        return strategy.AsCalculateStrategy();
    }

    private ICalculateStrategy<TFigure> ResolveStrategy<TFigure>(TFigure figure) where TFigure : Figure
    {
        var strategy = (ICalculateStrategy<TFigure>) _serviceProvider.GetService(typeof(ICalculateStrategy<TFigure>));
        return strategy;
    }
}