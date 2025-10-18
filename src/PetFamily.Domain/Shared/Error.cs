namespace PetFamily.Domain.Shared;

public record Error
{
    public string Message { get; }
    public string Code { get; }
    
    public Error(string message, string code)
    {
        Message = message;
        Code = code;
    }
    
    public static Error Validation(string message, string code) => new Error(message, code);
    public static Error NotFounded(string message, string code) => new Error(message, code);
    
    public static Error InCorrectAmount(string message, string code) => new Error(message, code);
}