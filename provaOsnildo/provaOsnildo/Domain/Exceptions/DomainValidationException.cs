namespace provaOsnildo.Domain.Exceptions;

public sealed class DomainValidationException : Exception
{
    public string Field { get; }

    public DomainValidationException(string field, string message)
        : base(message)
    {
        Field = field;
    }
}
