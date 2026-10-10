using Results;

namespace Tests;

public class ResultTypeTests
{
    [Fact]
    [Trait("ResultType", "")]
    public void GivenResultType_WhenSetToEachEnumValue_ThenValueIsPreserved()
    {
        foreach (ResultType resultType in Enum.GetValues<ResultType>())
        {
            Result successResult = Result.Success(resultType);
            Result failureResult = Result.Failure(resultType);
            Assert.Equal(resultType, successResult.Type);
            Assert.Equal(resultType, failureResult.Type);
        }
    }
}