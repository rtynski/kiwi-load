using FluentAssertions;
using KiwiLoad.Core.Areas.Auth.ValueObjects;
using KiwiLoad.Core.Exceptions.Auth;

namespace KiwiLoad.Api.Tests.Core.Areas;
public class TokenTest
{
    [Fact]
    public void TokenWhenEmpty_Should_GetExceptions()
    {
        // Arrange
        var token = string.Empty;
        var exceptionMessage = "Token cannot be null or empty";

        // Act
        var exception = Record.Exception(() => new Token(token));

        // Assert
        exception.Should().NotBeNull();
        exception.Should().BeOfType<KiwiLoadAuthTokenEmptyException>();
        exceptionMessage.Should().Be(exception.Message);
    }

    [Fact]
    public void TokenWhenNull_Should_GetExceptions()
    {
        // Arrange
        string? token = null;
        var exceptionMessage = "Token cannot be null or empty";

        // Act
        var exception = Record.Exception(() => new Token(token));

        // Assert
        exception.Should().NotBeNull();
        exception.Should().BeOfType<KiwiLoadAuthTokenEmptyException>();
        exceptionMessage.Should().Be(exception.Message);
    }

    [Fact]
    public void TokenNotNull_Should_NoException()
    {
        // Arrange
        var token = "token";

        // Act
        var exception = Record.Exception(() => new Token(token));

        // Assert
        exception.Should().BeNull();
    }

    [Fact]
    public void TokenEquals_Should_BeTrue()
    {
        // Arrange
        var token1 = new Token("token");
        var token2 = new Token("token");

        // Act
        var result = token1.Equals(token2);

        // Assert
        result.Should().BeTrue();
    }
}
