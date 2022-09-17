﻿using System;
using GeometricCalculator.Core.Figures.TwoDimensionalFigures.ArbitraryPolygon;
using GeometricCalculator.Core.Figures.TwoDimensionalFigures.Circle;
using GeometricCalculator.Core.Figures.TwoDimensionalFigures.Triangle;
using GeometricCalculator.Core.Interfaces;

namespace GeometricCalculator.Application.FirstSolution.Extensions;

public static class FigureExtensions
{
    public static double CalculateArea(this IFigure figure, int? roundUpTo = null)
    {
        return figure switch
        {
            Circle circle => circle.CalculateArea(roundUpTo),
            Triangle triangle => triangle.CalculateArea(roundUpTo),
            ArbitraryPolygon arbitraryPolygon => arbitraryPolygon.CalculateArea(roundUpTo),
            _ => throw new ArgumentException("Unsupported figure type")
        };
    }
}