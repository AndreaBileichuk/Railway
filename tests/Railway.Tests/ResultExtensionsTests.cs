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
    public void OnSuccess_Should_Chain_With_Value()
    {
        // Arrange
        var value = 100;
        
        // Act
        var result = Result<int>.Ok(value)
            .OnSuccess((v) => v + 10)
            .OnSuccess((v) => v + 10);
        
        // Assert
        Assert.Equal(100, value);
        Assert.Equal(120, result.Value);
    }
}