namespace NoferApi.Shared;

public record Error
{
    public string Code { get; set; }
    public string Description { get; set; }
    public ErrorType Type { get; set; }

    public Error(string code, string description, ErrorType type)
    {
        Code = code;
        Description = description;
        Type = type;
    }

    public static Error NullValue = new("Error.Null", "A null value was provided", ErrorType.Failure);
    public static Error Empty = new (string.Empty, string.Empty, ErrorType.Failure);
    public static Error Failure(string code, string description) => new (code, description, ErrorType.Failure);
    public static Error NotFound(string code, string description) => new (code, description, ErrorType.NotFound);
    public static Error Problem(string code, string description) => new (code, description, ErrorType.Problem);
    public static Error Conflict(string code, string description) => new (code, description, ErrorType.Conflict);
    
}