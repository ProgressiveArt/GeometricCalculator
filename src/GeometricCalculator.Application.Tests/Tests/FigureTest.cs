using System;
using GeometricCalculator.Application.FirstSolution.Extensions;
using GeometricCalculator.Core.Figures;
using GeometricCalculator.Core.Figures.TwoDimensionalFigures.ArbitraryPolygon;
using GeometricCalculator.Core.Figures.TwoDimensionalFigures.Circle;
using GeometricCalculator.Core.Figures.TwoDimensionalFigures.Triangle;
using Xunit;

namespace GeometricCalculator.Application.Tests.Tests;

public class FigureTest
    // Не вышло настроить регистрацию в контейнере, чтобы написать тесты для SecondSolution
    // : IClassFixture<DependencySetupFixture>
{
    // private readonly Calculator _calculator;

    // public CircleTest(DependencySetupFixture fixture)
    // {
        // _calculator = fixture.Container.ResolveService(Calculator);
    // }

    [Fact]
    public void create_exception()
    {
        // по-хорошему под ошибки либы надо завести свой кастомный тип ошибки(ок) с кодом,
        // т.к. если у клиента есть глобальный обработчик ошибок, то он может неверно обработать ArgumentException и любой другой дефолтный,
        // а если потребуется обработать конкретно ошибки из этой либы, то это будет почти не решаемая задача
        Assert.Throws<ArgumentException>(() => new Triangle(10, 5, 3));
        Assert.Throws<ArgumentException>(() => new Triangle(-1, 3, 3));

        Assert.Throws<ArgumentException>(() => new ArbitraryPolygon(new Vertex(-3, 0), new Vertex(0, 3)));
    }

    [Fact]
    public void calculate_circle_area()
    {
        const double expectedValue = 50.27;
        var testCircle = new Circle(4);

        var firstSolutionArea = testCircle.CalculateArea(2);

        Assert.Equal(firstSolutionArea, expectedValue);
    }

    [Fact]
    public void triangle_correct_type_matching()
    {
        var rectangularIsoscelesTriangle = new Triangle(3, 3, 3);

        Assert.NotNull(rectangularIsoscelesTriangle);
        Assert.Equal(TriangleType.Equilateral, rectangularIsoscelesTriangle.Type);
        Assert.Equal(TriangleTypeByAngles.Rectangular, rectangularIsoscelesTriangle.TypeByAngles);

        var versatileAcuteTriangle = new Triangle(2, 3, 5);

        Assert.NotNull(rectangularIsoscelesTriangle);
        Assert.Equal(TriangleType.Versatile, versatileAcuteTriangle.Type);
        Assert.Equal(TriangleTypeByAngles.Acute, versatileAcuteTriangle.TypeByAngles);
    }

    [Fact]
    public void compare_triangle_area_with_polygon_area_special_case()
    {
        const double expectedValue = 9;
        var triangle = new Triangle(4.243, 6, 4.243);
        var arbitraryPolygon = new ArbitraryPolygon(new Vertex(-3, 0), new Vertex(0, 3), new Vertex(0, -3));

        var triangleArea = triangle.CalculateArea(2);
        var arbitraryPolygonArea = arbitraryPolygon.CalculateArea(2);

        Assert.Equal(expectedValue, triangleArea);
        Assert.Equal(expectedValue, arbitraryPolygonArea);
    }
}