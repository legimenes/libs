namespace Results;

public class Result
{
    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public string? SuccessMessage { get; }

    private readonly List<Error>? _errors;

    public IReadOnlyCollection<Error>? Errors
    {
        get
        {
            return _errors?.AsReadOnly();
        }
    }

    protected internal Result(bool isSuccess, string? successMessage = null, List<Error>? errors = null)
    {
        IsSuccess = isSuccess;
        SuccessMessage = successMessage;
        _errors = errors;
    }

    public static Result Success() => new(true);

    public static Result Success(string successMessage) => new(true, successMessage);

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true);

    public static Result<TValue> Success<TValue>(TValue value, string successMessage) => new(value, true, successMessage);

    public static Result Failure() => new(false);

    public static Result Failure(Error error) => new(false, null, [error]);

    public static Result Failure(List<Error> errors) => new(false, null, errors);

    public static Result Failure(IDictionary<string, string[]> errors)
    {
        List<Error>? _errors = [];
        foreach (ICollection<string> firstLevelErrorMessages in errors.Values)
        {
            if (firstLevelErrorMessages.Count == 1)
                _errors.Add(Error.New(firstLevelErrorMessages.First()));
            else
                foreach (string secondLevelErrorMessages in firstLevelErrorMessages)
                    _errors.Add(Error.New(secondLevelErrorMessages));
        }
        return new(false, null, _errors);
    }
}

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    protected internal Result(TValue? value, bool isSuccess, string? successMessage = null, List<Error>? errors = null)
        : base(isSuccess, successMessage, errors)
        => _value = value;

    public TValue? Value => _value;
}