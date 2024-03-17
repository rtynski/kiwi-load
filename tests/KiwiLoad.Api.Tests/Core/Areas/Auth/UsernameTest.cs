using FluentAssertions;
using KiwiLoad.Core.Areas.Auth.ValueObjects;
using KiwiLoad.Core.Exceptions.Auth;
using KiwiLoad.Core.ValueObjects;

namespace KiwiLoad.Api.Tests.Core.Areas.Auth;
public class UsernameTest
{
    [Fact]
    public void WhenEmpty_Should_GetExceptions()
    {
        // Arrange
        var usernameValue = string.Empty;
        var exceptionMessage = "Username cannot be null or empty";

        // Act
        var exception = Record.Exception(() => new Username(usernameValue));

        // Assert
        exception.Should().NotBeNull();
        exception.Should().BeOfType<KiwiLoadAuthUsernameEmptyException>();
        exceptionMessage.Should().Be(exception.Message);
    }

    [Fact]
    public void WhenNull_Should_GetExceptions()
    {
        // Arrange
        string? usernameValue = null;
        var exceptionMessage = "Username cannot be null or empty";

        // Act
        var exception = Record.Exception(() => new Username(usernameValue));

        // Assert
        exception.Should().NotBeNull();
        exception.Should().BeOfType<KiwiLoadAuthUsernameEmptyException>();
        exceptionMessage.Should().Be(exception.Message);
    }

    [Fact]
    public void WhenNotNull_Should_NoException()
    {
        // Arrange
        var usernameValue = "username";

        // Act
        var exception = Record.Exception(() => new Username(usernameValue));

        // Assert
        exception.Should().BeNull();
    }

    [Fact]
    public void WhenTheSameEquals_Should_BeTrue()
    {
        // Arrange
        var usernameValue1 = new Username("username");
        var usernameValue2 = new Username("username");

        // Act
        var resultTyp = usernameValue1.Equals(usernameValue2);
        var resultObj = usernameValue1.Equals((object)usernameValue2);

        // Assert
        resultTyp.Should().BeTrue();
        resultObj.Should().BeTrue();
        usernameValue1.Value.Should().Be(usernameValue2.Value);
    }

    [Fact]
    public void WhenNotTheSameEquals_Should_BeFalse()
    {
        // Arrange
        var usernameValue1 = new Username("username1");
        var usernameValue2 = new Username("username2");

        // Act
        var resultTyp = usernameValue1.Equals(usernameValue2);
        var resultObj = usernameValue1.Equals((object)usernameValue2);

        // Assert
        resultTyp.Should().BeFalse();
        resultObj.Should().BeFalse();
    }

    [Fact]
    public void WhenOneNull_Should_BeFalse()
    {
        // Arrange
        var usernameValue1 = new Username("username1");
        Token? usernameValue2 = null;
        object? usernameValue3 = null;
        // Act
        var resultTyp = usernameValue1.Equals(usernameValue2);
        var resultObj = usernameValue1.Equals(usernameValue3);

        // Assert
        resultTyp.Should().BeFalse();
        resultObj.Should().BeFalse();
    }

    [Fact]
    public void WhenCompare_Should_BeTrue()
    {
        // Arrange
        var usernameValue1 = new Username("username");
        var usernameValue2 = new Username("username");

        // Act
        var resultHash = usernameValue1.GetHashCode() == usernameValue2.GetHashCode();
        var resultEqual = usernameValue1 == usernameValue2;

        // Assert
        resultHash.Should().BeTrue();
        resultEqual.Should().BeTrue();
    }

    [Fact]
    public void WhenCompareDifferent_Should_BeDifferent()
    {
        // Arrange
        var usernameValue1 = new Username("username1");
        var usernameValue2 = new Username("username2");

        // Act
        var resultHash = usernameValue1.GetHashCode() != usernameValue2.GetHashCode();
        var resultEqual = usernameValue1 != usernameValue2;

        // Assert
        resultHash.Should().BeTrue();
        resultEqual.Should().BeTrue();
    }

    [Fact]
    public void WhenImplicitOperatorToString_Should_BeEqual()
    {
        // Arrange
        var initValue = "username";
        var hashValue = new Username(initValue);

        // Act
        var result = (string)hashValue;

        // Assert
        result.Should().Be(initValue);
    }
}
