using System;

namespace GeometricCalculator.Core.Figures.TwoDimensionalFigures.ArbitraryPolygon;

public sealed class ArbitraryPolygon : Figure
{
    public ArbitraryPolygon(params Vertex[] vertices)
    {
        Vertices = vertices;

        if (!IsValid())
        {
            throw new ArgumentException("Vertices count must be greater then or equal 3");
        }
    }

    public Vertex[] Vertices { get; }
    protected override bool IsValid()
    {
        return Vertices.Length >= 3;
    }
}