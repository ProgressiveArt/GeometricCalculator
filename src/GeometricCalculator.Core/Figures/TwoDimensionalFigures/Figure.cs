using GeometricCalculator.Core.Interfaces;

namespace GeometricCalculator.Core.Figures.TwoDimensionalFigures;

public abstract class Figure : IFigure
{
    protected abstract bool IsValid();
}