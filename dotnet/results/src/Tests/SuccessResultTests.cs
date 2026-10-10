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
}