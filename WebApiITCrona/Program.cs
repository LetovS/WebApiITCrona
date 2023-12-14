using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTests")]
namespace WebApiITCrona;

internal class Program
{
    /// <summary>
    /// Entry point
    /// </summary>
    public static async Task Main(string[] args)
    {
        await CreateHostBuilder(args, b => ConfigureWebHostBuilder(b))
            .Build()
            .RunAsync();
    }
    
    /// <summary>
    ///  Создает построитель хоста
    /// </summary>
    public static IHostBuilder CreateHostBuilder(string[] args, Action<IWebHostBuilder> webHostBuilderConfigurator)
        => Host
            .CreateDefaultBuilder()
            .ConfigureWebHostDefaults(webHostBuilderConfigurator);

    /// <summary>
    /// Создает построитель веб хост
    /// </summary>
    public static IWebHostBuilder ConfigureWebHostBuilder(IWebHostBuilder webHostBuilder)
        => webHostBuilder
            .UseStartup<Startup>();
}