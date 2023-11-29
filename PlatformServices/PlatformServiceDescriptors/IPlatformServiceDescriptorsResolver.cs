using JetBrains.Annotations;

namespace PlatformServices.PlatformServices;

[PublicAPI]
public interface IPlatformServiceDescriptorsResolver
{
    IEnumerable<PlatformServiceDescriptor> ResolveAllDescriptors();
}
