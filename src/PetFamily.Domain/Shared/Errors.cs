namespace PetFamily.Domain.Shared;

public static class Errors
{
    public static class General
    {
        public static Error ValueIsInvalid(string? name = null)
        {
            var result = name ?? "value";
            return Error.Validation("value.is.invalid", $"{result} is invalid");
        }

        public static Error NotFounded(Guid? id = null)
        {
            var forId = id is null ? "" : $"id: '{id}'";
            return Error.NotFounded("not.founded.by.id", $"{forId} is not founded");
        }

        public static Error InCorrectAmount(float value)
        {
            var forAmount = value < 0 ? "" : $"value: '{value}'";
            return Error.Validation("value.is.in.correct", $"{forAmount} is in correct");
        }
    }
}