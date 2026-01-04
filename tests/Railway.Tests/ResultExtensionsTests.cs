using Railway.Functional;

namespace Railway.Tests;

public class ResultExtensionsTests
{
    [Fact]
    public void OnSuccess_Should_Chain_Operations()
    {
        // Arrange
        bool step1Run = false;
        bool step2Run = false;
        
        // Act
        Result.Ok()
            .OnSuccess(() => step1Run = true)
            .OnSuccess(() => step2Run = true);
        
        // Assert
        Assert.True(step1Run);
        Assert.True(step2Run);
    }

    [Fact]
    public void OnSuccess_Should_Stop_At_Failure()
    {
        // Arrange
        var step1Run = false;
        
        // Act
        Result.Fail("Something is wrong")
            .OnSuccess(() => step1Run = true);
        
        // Assert
        Assert.False(step1Run);
    }

    [Fact]
    public void OnSuccess_With_Value_Should_Call_Action_With_Value()
    {
        // Arrange
        var value = 100;
        
        // Act
        var result = Result<int>.Ok(value)
            .OnSuccess((v) =>
            {
                Assert.Equal(100, v);
            });
        
        // Assert
        Assert.Equal(100, result.Value);
    }

    [Fact]
    public void OnFail_Should_Call_OnError_Extension_Method_With_Message()
    {
        // Arrange
        var error = "Wow!";
        
        // Act
        var result = Result.Fail("Wow!")
            .OnSuccess(() =>
            {
            })
            .OnFail((errorMsg) =>
            {
                Assert.Equal(error, errorMsg);
            });
        
        // Assert
        Assert.Equal(error, result.Error);
    }

    [Fact]
    public void OnFail_Should_Call_OnError_With_Message_And_Value()
    {
        // Arrange
        var error = "Wow";
        
        // Act
        var result = Result<int>.Fail(error)
            .OnSuccess(() =>
            {
            })
            .OnFail((errorMsg) =>
            {
                Assert.Equal(error, errorMsg);
            });
        
        // Assert
        Assert.Equal(error, result.Error);
        Assert.Equal(0, result.Value);
    }
}