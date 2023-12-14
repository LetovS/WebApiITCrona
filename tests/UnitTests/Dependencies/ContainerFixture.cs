using Microsoft.Extensions.Hosting;
using WebApiITCrona;
using Xunit;

namespace UnitTests.Dependencies;

/// <summary>
/// 
/// </summary>
public class ContainerFixture : IDisposable
{
    private readonly IHost _host;
    
    /// <summary>
    /// ctor.
    /// </summary>
    public ContainerFixture()
    {
        _host = Program.CreateHostBuilder(Array.Empty<string>(), b =>
            {
                var builder = Program.ConfigureWebHostBuilder(b);
            })
            .Build();
    }
    
    /// <summary>
    /// Контейнер сервисов
    /// </summary>
    public IServiceProvider Container => _host.Services;

    /// <inheritdoc />
    public void Dispose()
    {
        _host.Dispose();
    }
}