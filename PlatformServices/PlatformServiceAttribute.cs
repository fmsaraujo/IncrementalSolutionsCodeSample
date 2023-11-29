using JetBrains.Annotations;

namespace PlatformServices;

[PublicAPI]
public class PlatformServiceAttribute : Attribute
{
    public PlatformServiceAttribute(string name)
    {
        EnsureValidName(name);

        Name = name;
        Version = "1.0";
    }

    public PlatformServiceAttribute(string name, string version)
    {
        EnsureValidName(name);
        EnsureValidVersion(version);

        Name = name;
        Version = version;
    }

    public string Name { get; init; }

    public string Version { get; init; }

    private static void EnsureValidName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }
    }

    private static void EnsureValidVersion(string version)
    {
        if (string.IsNullOrEmpty(version))
        {
            throw new ArgumentNullException(nameof(version));
        }
    }
}
