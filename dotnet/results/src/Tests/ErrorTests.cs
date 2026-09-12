using Results;

namespace Tests;

public class ErrorTests
{
    [Fact]
    [Trait("Error", "New")]
    public void GivenNewError_WhenCalledWithAllArguments_ThenPropertiesAreSet()
    {
        Error error = Error.New("Title", "Detail", "CODE");

        Assert.Equal("Title", error.Title);
        Assert.Equal("Detail", error.Detail);
        Assert.Equal("CODE", error.Code);
    }

    [Fact]
    [Trait("Error", "New")]
    public void GivenNewError_WhenCalledWithOnlyTitle_ThenDetailAndCodeAreNull()
    {
        Error error = Error.New("Title only");

        Assert.Equal("Title only", error.Title);
        Assert.Null(error.Detail);
        Assert.Null(error.Code);
    }
}