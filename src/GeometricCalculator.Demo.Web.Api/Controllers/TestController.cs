using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GeometricCalculator.Application.FirstSolution.Extensions;
using GeometricCalculator.Application.SecondSolution.Services;
using GeometricCalculator.Core.Figures;
using GeometricCalculator.Core.Figures.TwoDimensionalFigures;
using GeometricCalculator.Core.Figures.TwoDimensionalFigures.ArbitraryPolygon;
using GeometricCalculator.Core.Figures.TwoDimensionalFigures.Circle;
using GeometricCalculator.Core.Figures.TwoDimensionalFigures.Triangle;
using Microsoft.AspNetCore.Mvc;

namespace GeometricCalculator.Demo.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class TestController : Controller
{
    private readonly Calculator _calculator;

    public TestController(
        Calculator calculator)
    {
        _calculator = calculator;
    }


    [HttpGet, Route("compare-solutions")]
    public JsonResult Compare()
    {
        var figures = new List<Figure>
        {
            new Circle(4),
            new Triangle(4.243, 6, 4.243),
            new ArbitraryPolygon(new Vertex(-3, 0), new Vertex(0, 3), new Vertex(0, -3))
        };

        var watch1 = new Stopwatch();
        var watch2 = new Stopwatch();

        watch1.Start();
        var runTimeResult = figures.Select(figure =>
        {
            var area = _calculator.CalculateArea(figure, 2);
            return new
            {
                Figure = figure.GetType().Name,
                Area = area
            };
        });
        watch1.Stop();

        watch2.Start();
        var compileTimeResult = figures.Select(figure =>
        {
            var area = figure.CalculateArea(2);
            return new
            {
                Figure = figure.GetType().Name,
                Area = area
            };
        });
        watch2.Stop();

        var result = new
        {
            runTimeResult,
            runTimeVersionExecutionTime = watch1.ElapsedTicks,
            compileTimeResult,
            compileTimeVersionExecutionTime = watch2.ElapsedTicks,
        };

        return new JsonResult(result);
    }
}