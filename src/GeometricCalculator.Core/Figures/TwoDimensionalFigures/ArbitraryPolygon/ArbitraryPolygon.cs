using System;

namespace GeometricCalculator.Core.Figures.TwoDimensionalFigures.ArbitraryPolygon;

public sealed class ArbitraryPolygon : Figure
{
    public ArbitraryPolygon(params Vertex[] vertices)
    {
        Vertices = vertices;

        if (!IsValid())
        {
            throw new ArgumentException("Количество вершин многоугольника должно быть не менее трех");
        }
    }

    public Vertex[] Vertices { get; }
    protected override bool IsValid()
    {
        return Vertices.Length >= 3;
    }
}