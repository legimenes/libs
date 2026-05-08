using Results;

namespace Tests;

public class ErrorTests
{
    [Fact]
    public void GivenNewError_WhenCalledWithAllArguments_ThenPropertiesAreSet()
    {
        Error error = Error.New("Title", "Detail", "CODE");

        Assert.Equal("Title", error.Title);
        Assert.Equal("Detail", error.Detail);
        Assert.Equal("CODE", error.Code);
    }

    [Fact]
    public void GivenNewError_WhenCalledWithOnlyTitle_ThenDetailAndCodeAreEmpty()
    {
        Error error = Error.New("Title only");

        Assert.Equal("Title only", error.Title);
        Assert.Equal("", error.Detail);
        Assert.Equal("", error.Code);
    }
}