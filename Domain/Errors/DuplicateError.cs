using FluentResults;

namespace CarRental.Domain.Errors;

public class DuplicateError : IError
{
    public DuplicateError(string message)
    {
        Message = message;
    }

    public string Message { get; }
    public Dictionary<string, object> Metadata { get; }
    public List<IError> Reasons { get; }
}