using Railway.Functional;

namespace Railway.Tests;

public class ResultTests
{
    [Fact]
    public void Result_Ok_Should_Be_Success()
    {
        // Arrange & Act
        var result = Result.Ok();
        
        // Assert
        Assert.True(result.IsSuccess);
        Assert.Empty(result.Error);
    }

    [Fact]
    public void Result_Fail_Should_Have_Error()
    {
        // Arrange
        var message = "Something went wrong";
        
        // Act
        var result = Result.Fail(message);
        
        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(message, result.Error);
    }

    [Fact]
    public void ResultT_Ok_Should_Store_Value()
    {
        // Arrange
        var value = 200;
        
        // Act
        var result = Result<int>.Ok(value);
        
        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(value, result.Value);
        Assert.Empty(result.Error);
    }
}