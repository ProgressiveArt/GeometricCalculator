namespace GeometricCalculator.Core.Figures;

public sealed class Vertex
{
    public Vertex(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double X { get; }
    public double Y { get; }
}