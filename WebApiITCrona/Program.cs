using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using WebApiITCrona.DI;
using WebApiITCrona.Infrastructure.Options;
using WebApiITCrona.Infrastructure.Validators;

namespace WebApiITCrona;


public class Program
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
        => Microsoft.Extensions.Hosting.Host
            .CreateDefaultBuilder()
            .ConfigureWebHostDefaults(webHostBuilderConfigurator);

    /// <summary>
    /// Создает построитель веб хост
    /// </summary>
    public static IWebHostBuilder ConfigureWebHostBuilder(IWebHostBuilder webHostBuilder)
        => webHostBuilder
            .UseStartup<Startup>();
}