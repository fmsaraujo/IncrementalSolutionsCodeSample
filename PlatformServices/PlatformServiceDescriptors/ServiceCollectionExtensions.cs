using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace PlatformServices.PlatformServiceDescriptors;

[PublicAPI]
public static class ServiceCollectionExtensions
{
    public static void AddPlatformServiceDescriptors(this IServiceCollection services)
        => services.AddSingleton<IPlatformServiceDescriptorsResolver>(_ => new PlatformServiceDescriptorsResolver());
}
