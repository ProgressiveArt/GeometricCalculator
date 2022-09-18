using System.Reflection;
using Autofac;
using GeometricCalculator.Core;
using Module = Autofac.Module;

namespace GeometricCalculator.Application.SecondSolution;

public sealed class SecondSolutionGeometricCalculatorModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(GetType().GetTypeInfo().Assembly)
            .Where(t => t.GetTypeInfo().IsPublic)
            .AsImplementedInterfaces()
            .AsSelf()
            .InstancePerLifetimeScope();

        builder.RegisterModule(new GeometricCalculatorCoreModule());
    }
}