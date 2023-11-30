namespace PlatformServices.PlatformServiceDescriptors;

public class PlatformServiceOperationDescriptor
{
    private PlatformServiceDescriptor? _platformServiceDescriptor;

    public PlatformServiceOperationDescriptor(
        string operation,
        string version,
        Type? inputType,
        Type outputType)
    {
        Operation = operation;
        Version = version;
        InputType = inputType;
        OutputType = outputType;
    }

    public PlatformServiceDescriptor? PlatformServiceDescriptor
    {
        get => _platformServiceDescriptor;
        set
        {
            // TODO - Not thread-safe
            if (_platformServiceDescriptor != null)
            {
                // TODO - Exceptions..
                throw new Exception($"{nameof(PlatformServiceDescriptor)} can only be set once");
            }

            _platformServiceDescriptor = value;
            PlatformOperationIdentifier = GetPlatformOperationIdentifier();
        }
    }

    public string Operation { get; }

    public string Version { get; }

    public Type? InputType { get; }

    public Type OutputType { get; }

    public string PlatformOperationIdentifier { get; private set; } = string.Empty;

    /// <summary>
    ///     Create an instance that can be matched against another instance sharing the same equality properties.
    /// </summary>
    /// <param name="operation">Operation name.</param>
    /// <param name="version">Operation version.</param>
    /// <param name="serviceDescriptor">The service descriptor to which this operation belongs to.</param>
    /// <returns>Instance of <see cref="PlatformServiceOperationDescriptor" /></returns>
    public static PlatformServiceOperationDescriptor CreateEqualityInstance(
        string operation,
        string version,
        PlatformServiceDescriptor? serviceDescriptor = null)
    {
        var operationDescriptor = new PlatformServiceOperationDescriptor(
            operation,
            version,
            null,
            typeof(void));

        if (serviceDescriptor != null)
        {
            operationDescriptor.PlatformServiceDescriptor = serviceDescriptor;
        }

        return operationDescriptor;
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

        return Equals((PlatformServiceOperationDescriptor) obj);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        // ReSharper disable once NonReadonlyMemberInGetHashCode
        hashCode.Add(_platformServiceDescriptor);

        hashCode.Add(Operation, StringComparer.OrdinalIgnoreCase);
        hashCode.Add(Version, StringComparer.OrdinalIgnoreCase);
        return hashCode.ToHashCode();
    }

    private bool Equals(PlatformServiceOperationDescriptor other)
        => Equals(_platformServiceDescriptor, other._platformServiceDescriptor) &&
           string.Equals(Operation, other.Operation, StringComparison.OrdinalIgnoreCase) &&
           string.Equals(Version, other.Version, StringComparison.OrdinalIgnoreCase);

    private string GetPlatformOperationIdentifier()
        => $"{_platformServiceDescriptor!.PlatformServiceIdentifier}/{Operation}/{Version}";
}
