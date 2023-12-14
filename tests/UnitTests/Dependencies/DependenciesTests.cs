using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WebApiITCrona.Controllers;
using Xunit;

namespace UnitTests.Dependencies;

public class DependenciesTests : IClassFixture<ContainerFixture>
{
    private readonly IServiceProvider _container;

    /// <summary>
    /// .ctor
    /// </summary>
    public DependenciesTests(ContainerFixture fixture)
    {
        _container = fixture.Container;

        var t = _container.GetRequiredService(typeof(GeoController));
    }

    [Theory, MemberData(nameof(Controllers))]
    internal void ControllerShouldBeResolved(Type controller)
    {
        var instance = _container.GetService(controller);

        instance.Should().NotBeNull();
    }
    
    /// <summary>
    /// Список контроллеров Api
    /// </summary>
    public static IEnumerable<object[]> Controllers =>
        typeof(GeoController).Assembly
            .DefinedTypes
            .Where(type => typeof(ControllerBase).IsAssignableFrom(type))
            .Where(type => !type.IsAbstract)
            .Select(type => new[] { type });
}