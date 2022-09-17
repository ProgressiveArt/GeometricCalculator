using System;

namespace GeometricCalculator.Core.Figures.TwoDimensionalFigures.Circle;

public sealed class Circle : Figure
{
    public Circle(double radius)
    {
        Radius = radius;

        if (!IsValid())
        {
            throw new ArgumentException("Invalid radius value");
        }
    }

    public double Radius { get; set; }

    protected override bool IsValid()
    {
        return Radius > 0;
    }
}