using JetBrains.Annotations;

namespace Console.ServiceContracts;

[PublicAPI]
public abstract record ServiceResult
{
    public record Ok(object? Result = default) : ServiceResult;

    public record Error(
        string? ErrorMessage = null,
        Dictionary<string, string>? Context = null) : ServiceResult, IError;
}

[PublicAPI]
public abstract record ServiceResult<T>
{
    public sealed record Ok(T? Result = default) : ServiceResult<T>;

    // Take care changing this constructor as instances of it are created dynamically by the SignalR Gateway
    public record Error(
        string? ErrorMessage = null,
        Dictionary<string, string>? Context = null) : ServiceResult<T>, IError;
}

[PublicAPI]
public interface IError
{
    string? ErrorMessage { get; }
    Dictionary<string, string>? Context { get; }
}
