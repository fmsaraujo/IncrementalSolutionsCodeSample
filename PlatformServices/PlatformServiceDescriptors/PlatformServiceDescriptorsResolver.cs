using JetBrains.Annotations;
using System.Reflection;

namespace PlatformServices.PlatformServices;

[PublicAPI]
public class PlatformServiceDescriptorsResolver : IPlatformServiceDescriptorsResolver
{
    public IEnumerable<PlatformServiceDescriptor> ResolveAllDescriptors()
    {
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        foreach (var assembly in ReflectionUtils.GetAssemblies(baseDirectory))
        {
            foreach (var platformServiceDescriptor in GetAssemblyDescriptors(assembly))
            {
                yield return platformServiceDescriptor;
            }
        }
    }

    private static IEnumerable<PlatformServiceDescriptor> GetAssemblyDescriptors(Assembly assembly)
    {
        // TODO - Improve this
        var platformServiceDefinitions = assembly.ExportedTypes
            .Where(et => et.IsInterface && et.GetCustomAttribute<PlatformServiceAttribute>() is not null);

        foreach (var psd in platformServiceDefinitions)
        {
            var platformServiceAttribute = psd.GetCustomAttribute<PlatformServiceAttribute>()!;

            var serviceName = platformServiceAttribute.Name;
            var serviceVersion = platformServiceAttribute.Version;

            var serviceDescriptor = new PlatformServiceDescriptor(serviceName, serviceVersion);

            foreach (var method in psd.GetMethods())
            {
                var platformServiceOperationAttribute = method.GetCustomAttribute<PlatformServiceOperationAttribute>();
                if (platformServiceOperationAttribute == null)
                {
                    continue;
                }

                var operation = platformServiceOperationAttribute.Name;
                var version = platformServiceOperationAttribute.Version;

                var parameters = method.GetParameters();

                var operationDescriptor = new PlatformServiceOperationDescriptor(
                    operation,
                    version,
                    parameters.Any() ? parameters[0].ParameterType : null,
                    method.ReturnType);

                serviceDescriptor.AddOperationDescriptor(operationDescriptor);
            }

            yield return serviceDescriptor;
        }
    }
}
