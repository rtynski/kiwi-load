using FluentAssertions;
using KiwiLoad.Core.Areas.Auth.ValueObjects;
using KiwiLoad.Core.Exceptions.Auth;

namespace KiwiLoad.Api.Tests.Core.Areas.Auth;
public class TokenTest
{
    [Fact]
    public void WhenEmpty_Should_GetExceptions()
    {
        // Arrange
        var tokenValue = string.Empty;
        var exceptionMessage = "Token cannot be null or empty";

        // Act
        var exception = Record.Exception(() => new Token(tokenValue));

        // Assert
        exception.Should().NotBeNull();
        exception.Should().BeOfType<KiwiLoadAuthTokenEmptyException>();
        exceptionMessage.Should().Be(exception.Message);
    }

    [Fact]
    public void WhenNull_Should_GetExceptions()
    {
        // Arrange
        string? tokenValue = null;
        var exceptionMessage = "Token cannot be null or empty";

        // Act
        var exception = Record.Exception(() => new Token(tokenValue));

        // Assert
        exception.Should().NotBeNull();
        exception.Should().BeOfType<KiwiLoadAuthTokenEmptyException>();
        exceptionMessage.Should().Be(exception.Message);
    }

    [Fact]
    public void WhenNotNull_Should_NoException()
    {
        // Arrange
        var tokenValue = "token";

        // Act
        var exception = Record.Exception(() => new Token(tokenValue));

        // Assert
        exception.Should().BeNull();
    }

    [Fact]
    public void WhenTheSameEquals_Should_BeTrue()
    {
        // Arrange
        var token1 = new Token("token");
        var token2 = new Token("token");

        // Act
        var resultTyp = token1.Equals(token2);
        var resultObj = token1.Equals((object)token2);

        // Assert
        resultTyp.Should().BeTrue();
        resultObj.Should().BeTrue();
        token1.Value.Should().Be(token2.Value);
    }

    [Fact]
    public void WhenNotTheSameEquals_Should_BeFalse()
    {
        // Arrange
        var token1 = new Token("token1");
        var token2 = new Token("token2");

        // Act
        var resultTyp = token1.Equals(token2);
        var resultObj = token1.Equals((object)token2);

        // Assert
        resultTyp.Should().BeFalse();
        resultObj.Should().BeFalse();
    }

    [Fact]
    public void WhenOneNull_Should_BeFalse()
    {
        // Arrange
        var token1 = new Token("token");
        Token? token2 = null;
        object? token3 = null;
        // Act
        var resultTyp = token1.Equals(token2);
        var resultObj = token1.Equals(token3);

        // Assert
        resultTyp.Should().BeFalse();
        resultObj.Should().BeFalse();
    }

    [Fact]
    public void WhenCompare_Should_BeTrue()
    {
        // Arrange
        var token1 = new Token("token");
        var token2 = new Token("token");

        // Act
        var resultHash = token1.GetHashCode() == token2.GetHashCode();
        var resultEqual = token1 == token2;

        // Assert
        resultHash.Should().BeTrue();
        resultEqual.Should().BeTrue();
    }

    [Fact]
    public void WhenCompareDifferent_Should_BeDifferent()
    {
        // Arrange
        var token1 = new Token("token1");
        var token2 = new Token("token2");

        // Act
        var resultHash = token1.GetHashCode() != token2.GetHashCode();
        var resultEqual = token1 != token2;

        // Assert
        resultHash.Should().BeTrue();
        resultEqual.Should().BeTrue();
    }

    [Fact]
    public void WhenImplicitOperatorToString_Should_BeEqual()
    {
        // Arrange
        var initValue = "token";
        var hashValue = new Token(initValue);

        // Act
        var result = (string)hashValue;

        // Assert
        result.Should().Be(initValue);
    }
}
