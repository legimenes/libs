using Results;

namespace Tests;

public class FailureResultOfTTests
{
    [Fact]
    [Trait("ResultOfT", "Failure")]
    public void GivenFailureResultOfT_WhenCalledWithSingleError_ThenErrorsContainsTheError()
    {
        Error error = Error.New("Error title", "Error detail", "ERR001");
        Result<int> result = Result.Failure<int>(error);

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(default, result.Value);
    }

    [Fact]
    [Trait("ResultOfT", "Failure")]
    public void GivenFailureResult_WhenCalledWithListOfErrors_ThenErrorsContainsAllErrors()
    {
        List<Error> errors =
        [
            Error.New("Error 1"),
            Error.New("Error 2")
        ];
        Result<int> result = Result.Failure<int>(errors);

        Assert.False(result.IsSuccess);
        Assert.NotNull(result.Errors);
        Assert.Equal(2, result.Errors.Count);
        Assert.Equal(default, result.Value);
    }

    [Fact]
    [Trait("ResultOfT", "Failure")]
    public void GivenFailureResult_WhenCalledWithDictionary_ThenErrorsContainsAllErrors()
    {
        Dictionary<string, string[]> errors = new()
        {
            { "field1", [ "Error A", "Error B" ] },
            { "field2", [ "Error C" ] }
        };
        Result<int> result = Result.Failure<int>(errors);

        Assert.False(result.IsSuccess);
        Assert.NotNull(result.Errors);
        Assert.Equal(3, result.Errors.Count);
        Assert.Equal(default, result.Value);
    }
}