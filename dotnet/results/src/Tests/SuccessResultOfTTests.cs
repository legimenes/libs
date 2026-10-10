using Results;

namespace Tests;

public class SuccessResultOfTTests
{
    [Fact]
    [Trait("ResultOfT", "Success")]
    public void GivenSuccessResult_WhenCalledWithAValue_ThenValueIsReturned()
    {
        Result<int> result = Result.Success(5);

        Assert.True(result.IsSuccess);
        Assert.Equal(5, result.Value);
    }

    [Fact]
    [Trait("ResultOfT", "Success")]
    public void GivenSuccessResult_WhenCalledWithSuccessMessage_ThenBothAreReturned()
    {
        Result<int> result = Result.Success(42, "The answer");

        Assert.True(result.IsSuccess);
        Assert.Equal(42, result.Value);
        Assert.Equal("The answer", result.SuccessMessage);
    }
}
