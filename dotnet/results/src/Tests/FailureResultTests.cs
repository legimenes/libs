using Results;

namespace Tests;

public class FailureResultTests
{
    [Fact]
    [Trait("Result", "Failure")]
    public void GivenFailureResult_WhenCalledWithNoArguments_ThenIsFailureIsTrue()
    {
        Result result = Result.Failure();

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
    }

    [Fact]
    [Trait("Result", "Failure")]
    public void GivenFailureResult_WhenCalledWithSingleError_ThenErrorsContainsTheError()
    {
        Error error = Error.New("Error title", "Error detail", "ERR001");
        Result result = Result.Failure(error);

        Assert.False(result.IsSuccess);
        Assert.NotNull(result.Errors);
        Assert.Single(result.Errors);
        Assert.Equal(error, result.Errors.First());
    }

    [Fact]
    [Trait("Result", "Failure")]
    public void GivenFailureResult_WhenCalledWithListOfErrors_ThenErrorsContainsAllErrors()
    {
        List<Error> errors =
        [
            Error.New("Error 1"),
            Error.New("Error 2")
        ];
        Result result = Result.Failure(errors);

        Assert.False(result.IsSuccess);
        Assert.NotNull(result.Errors);
        Assert.Equal(2, result.Errors.Count);
    }

    [Fact]
    [Trait("Result", "Failure")]
    public void GivenFailureResult_WhenCalledWithDictionary_ThenErrorsContainsAllErrors()
    {
        Dictionary<string, string[]> errors = new()
        {
            { "field1", [ "Error A", "Error B" ] },
            { "field2", [ "Error C" ] }
        };
        Result result = Result.Failure(errors);

        Assert.False(result.IsSuccess);
        Assert.NotNull(result.Errors);
        Assert.Equal(3, result.Errors.Count);
    }

    [Fact]
    [Trait("Result<TValue>", "Failure")]
    public void GivenFailureResult_WhenCalledWithGenericValueAndSingleError_ThenErrorsContainsTheError()
    {
        Error error = Error.New("Error title", "Error detail", "ERR001");
        Result<int> result = Result.Failure<int>(error);

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(default, result.Value);
    }

    [Fact]
    [Trait("Result<TValue>", "Failure")]
    public void GivenFailureResult_WhenCalledWithGenericValueAndListOfErrors_ThenErrorsContainsAllErrors()
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
    [Trait("Result<TValue>", "Failure")]
    public void GivenFailureResult_WhenCalledWithGenericValueAndDictionary_ThenErrorsContainsAllErrors()
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