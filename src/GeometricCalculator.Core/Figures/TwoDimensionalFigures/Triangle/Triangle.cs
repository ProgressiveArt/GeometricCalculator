using System;
using System.Linq;

namespace GeometricCalculator.Core.Figures.TwoDimensionalFigures.Triangle;

public sealed class Triangle : Figure
{
    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;

        if (!IsValid())
        {
            throw new ArgumentException("Invalid triangle sides");
        }
    }

    public double A { get; }
    public double B { get; }
    public double C { get; }

    public TriangleType Type => GetTriangleType(A, B, C);
    public TriangleTypeByAngles TypeByAngles => GetTriangleTypeByAngles(A, B, C);

    protected override bool IsValid()
    {
        var sides = new[] { A, B, C }
            .OrderByDescending(x => x)
            .ToArray();

        var isCorrectValues = sides.All(x => x > 0);
        var isValidSides = A <= B + C &&
                           B <= A + C &&
                           C <= A + B;

        return isCorrectValues && isValidSides;
    }

    private static TriangleType GetTriangleType(double a, double b, double c)
    {
        if (a.CompareTo(b) == 0 && b.CompareTo(c) == 0)
        {
            return TriangleType.Equilateral;
        }

        if ((a.CompareTo(b) == 0 && b.CompareTo(c) != 0) ||
            (a.CompareTo(c) == 0 && b.CompareTo(c) != 0) ||
            (b.CompareTo(c) == 0 && a.CompareTo(c) != 0))
        {
            return TriangleType.Isosceles;
        }

        return TriangleType.Versatile;
    }

    private static TriangleTypeByAngles GetTriangleTypeByAngles(double a, double b, double c)
    {
        var sides = new[] { a, b, c };
        var maxSide = Math.Pow(sides.Max(), 2);
        var squaresSum = Math.Pow(a, 2) + Math.Pow(b, 2);

        return maxSide.CompareTo(squaresSum) switch
        {
            > 0 => TriangleTypeByAngles.Acute,
            0 => TriangleTypeByAngles.Obtuse,
            _ => TriangleTypeByAngles.Rectangular
        };
    }
}