using System.Reflection;
using System.Runtime.Loader;

namespace PlatformServices;

/// <summary>
///     cfr:
///     https://github.com/castleproject/Windsor/blob/master/src/Castle.Windsor/MicroKernel/Registration/AssemblyFilter.cs
/// </summary>
public static class ReflectionUtils
{
    public static IEnumerable<Assembly> GetAssemblies(string directoryPath)
    {
        foreach (var filePath in GetFiles(directoryPath))
        {
            if (!IsAssemblyFile(filePath))
            {
                continue;
            }

            var assembly = LoadAssemblyIgnoringErrors(filePath);
            if (assembly != null)
            {
                yield return assembly;
            }
        }
    }

    private static IEnumerable<string> GetFiles(string directoryPath)
    {
        try
        {
            if (Directory.Exists(directoryPath) == false)
            {
                return Enumerable.Empty<string>();
            }

            return Directory.EnumerateFiles(directoryPath);
        }
        catch (IOException e)
        {
            throw new ArgumentException("Could not resolve assemblies.", e);
        }
    }

    private static Assembly? LoadAssemblyIgnoringErrors(string filePath)
    {
        // based on MEF DirectoryCatalog
        try
        {
            var assemblyName = AssemblyLoadContext.GetAssemblyName(filePath);
            return Assembly.Load(assemblyName);
        }
        catch (FileNotFoundException) { }
        catch (FileLoadException)
        {
            // File was found but could not be loaded
        }
        catch (BadImageFormatException)
        {
            // Dlls that contain native code or assemblies for wrong runtime (like .NET 4 assembly when we're in CLR2 process)
        }
        catch (ReflectionTypeLoadException)
        {
            // Dlls that have missing Managed dependencies are not loaded, but do not invalidate the Directory
        }

        return null;
    }

    private static bool IsAssemblyFile(string filePath)
    {
        string extension;
        try
        {
            extension = Path.GetExtension(filePath);
        }
        catch (ArgumentException)
        {
            // path contains invalid characters...
            return false;
        }

        return IsDll(extension) || IsExe(extension);
    }

    private static bool IsDll(string extension)
        => ".dll".Equals(extension, StringComparison.OrdinalIgnoreCase);

    private static bool IsExe(string extension)
        => ".exe".Equals(extension, StringComparison.OrdinalIgnoreCase);
}
