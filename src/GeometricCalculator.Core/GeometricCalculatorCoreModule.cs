using System.Linq;
using System.Reflection;
using Autofac;
using GeometricCalculator.Core.Interfaces;
using Module = Autofac.Module;

namespace GeometricCalculator.Core;

public class GeometricCalculatorCoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var domainTypes = new[]
        {
            typeof(IService),
            typeof(IFactory),
            typeof(IFigure),
        };

        builder.RegisterAssemblyTypes(GetType().GetTypeInfo().Assembly)
            .Where(t => t.GetTypeInfo().ImplementedInterfaces.Intersect(domainTypes).Any())
            .AsImplementedInterfaces()
            .AsSelf()
            .InstancePerLifetimeScope();
    }
}