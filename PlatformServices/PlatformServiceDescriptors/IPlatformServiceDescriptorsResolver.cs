using JetBrains.Annotations;

namespace PlatformServices.PlatformServiceDescriptors;

[PublicAPI]
public interface IPlatformServiceDescriptorsResolver
{
    IEnumerable<PlatformServiceDescriptor> ResolveAllDescriptors();
}
