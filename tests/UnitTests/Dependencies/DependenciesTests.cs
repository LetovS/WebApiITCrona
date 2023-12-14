using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WebApiITCrona.Controllers;
using Xunit;

namespace UnitTests.Dependencies;

/// <summary>
/// Тест DI
/// </summary>
public class DependenciesTests : IClassFixture<ContainerFixture>
{
    private readonly IServiceProvider _container;

    /// <summary>
    /// .ctor
    /// </summary>
    public DependenciesTests(ContainerFixture fixture)
    {
        _container = fixture.Container;
    }

    [Theory, MemberData(nameof(Controllers))]
    internal void ControllerShouldBeResolved(Type controller)
    {
        // Arrange
        // Получаем инжектируемые параметры в конструктор
        var constructorsParams = controller.GetConstructors()[0].GetParameters();
        
        // Act
        // проверяем есть ли они в DI
        var services = constructorsParams
            .Select(x => _container.GetRequiredService(x.ParameterType))
            .ToList();
        
        // Assert
        services.Should().NotBeNull().And.HaveCount(constructorsParams.Length);
    }
    
    /// <summary>
    /// Список контроллеров Api
    /// </summary>
    public static IEnumerable<object[]> Controllers =>
        typeof(LocationController).Assembly
            .DefinedTypes
            .Where(type => typeof(ControllerBase).IsAssignableFrom(type))
            .Where(type => !type.IsAbstract)
            .Select(type => new[] { type });
}