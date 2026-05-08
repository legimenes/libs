using Results;

namespace Tests;

public class SuccessResultTests
{
    [Fact]
    public void GivenSuccessResult_WhenCalledWithNoArguments_ThenIsSuccessIsTrue()
    {
        Result result = Result.Success();

        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
    }

    [Fact]
    public void GivenSuccessResult_WhenCalledWithMessage_ThenSuccessMessageIsSet()
    {
        Result result = Result.Success("Operation completed");

        Assert.True(result.IsSuccess);
        Assert.Equal("Operation completed", result.SuccessMessage);
    }

    [Fact]
    public void GivenSuccessResult_WhenCalledWithGenericValue_ThenValueIsReturned()
    {
        Result<int> result = Result.Success(5);

        Assert.True(result.IsSuccess);
        Assert.Equal(5, result.Value);
    }

    [Fact]
    public void GivenSuccessResult_WhenCalledWithGenericValueAndMessage_ThenBothAreReturned()
    {
        Result<int> result = Result.Success(42, "The answer");

        Assert.True(result.IsSuccess);
        Assert.Equal(42, result.Value);
        Assert.Equal("The answer", result.SuccessMessage);
    }
}