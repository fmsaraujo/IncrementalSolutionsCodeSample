namespace PlatformServices.PlatformServiceDescriptors;

public class PlatformServiceDescriptor
{
    private readonly HashSet<PlatformServiceOperationDescriptor> _operationDescriptors = new();

    public PlatformServiceDescriptor(string service, string version)
    {
        Service = service;
        Version = version;
    }

    public string Service { get; }
    public string Version { get; }

    public IReadOnlySet<PlatformServiceOperationDescriptor> Operations => _operationDescriptors;

    public string PlatformServiceIdentifier => $"{Service}/{Version}";

    public void AddOperationDescriptor(PlatformServiceOperationDescriptor operationDescriptor)
    {
        operationDescriptor.PlatformServiceDescriptor = this;
        _operationDescriptors.Add(operationDescriptor);
    }

    public bool TryGetOperationDescriptor(
        string operation,
        string version,
        out PlatformServiceOperationDescriptor? operationDescriptor)
    {
        var equivalentInstance = PlatformServiceOperationDescriptor.CreateEqualityInstance(operation, version, this);
        return _operationDescriptors.TryGetValue(equivalentInstance, out operationDescriptor);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        return Equals((PlatformServiceDescriptor) obj);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(Service, StringComparer.OrdinalIgnoreCase);
        hashCode.Add(Version, StringComparer.OrdinalIgnoreCase);
        return hashCode.ToHashCode();
    }

    private bool Equals(PlatformServiceDescriptor other) =>
        string.Equals(Service, other.Service, StringComparison.OrdinalIgnoreCase) &&
        string.Equals(Version, other.Version, StringComparison.OrdinalIgnoreCase);
}
