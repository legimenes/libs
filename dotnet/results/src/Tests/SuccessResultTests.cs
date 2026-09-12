using Results;

namespace Tests;

public class SuccessResultTests
{
    [Fact]
    [Trait("Result", "Success")]
    public void GivenSuccessResult_WhenCalledWithNoArguments_ThenIsSuccessIsTrue()
    {
        Result result = Result.Success();

        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
    }

    [Fact]
    [Trait("Result", "Success")]
    public void GivenSuccessResult_WhenCalledWithSuccessMessage_ThenSuccessMessageIsSet()
    {
        Result result = Result.Success("Operation completed");

        Assert.True(result.IsSuccess);
        Assert.Equal("Operation completed", result.SuccessMessage);
    }

    [Fact]
    [Trait("Result<TValue>", "Success")]
    public void GivenSuccessResult_WhenCalledWithGenericValue_ThenValueIsReturned()
    {
        Result<int> result = Result.Success(5);

        Assert.True(result.IsSuccess);
        Assert.Equal(5, result.Value);
    }

    [Fact]
    [Trait("Result<TValue>", "Success")]
    public void GivenSuccessResult_WhenCalledWithGenericValueAndSuccessMessage_ThenBothAreReturned()
    {
        Result<int> result = Result.Success(42, "The answer");

        Assert.True(result.IsSuccess);
        Assert.Equal(42, result.Value);
        Assert.Equal("The answer", result.SuccessMessage);
    }
}