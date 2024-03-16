using FluentAssertions;
using KiwiLoad.Core.Areas.Auth.ValueObjects;
using KiwiLoad.Core.Exceptions.Auth;

namespace KiwiLoad.Api.Tests.Core.Areas.Auth;
public class PasswordTest
{
    [Fact]
    public void WhenEmpty_Should_GetExceptions()
    {
        // Arrange
        var passwordValue = string.Empty;
        var exceptionMessage = "Password cannot be null or empty";

        // Act
        var exception = Record.Exception(() => new Password(passwordValue));

        // Assert
        exception.Should().NotBeNull();
        exception.Should().BeOfType<KiwiLoadAuthPasswordEmptyException>();
        exceptionMessage.Should().Be(exception.Message);
    }

    [Fact]
    public void WhenNull_Should_GetExceptions()
    {
        // Arrange
        string? passwordValue = null;
        var exceptionMessage = "Password cannot be null or empty";

        // Act
        var exception = Record.Exception(() => new Password(passwordValue));

        // Assert
        exception.Should().NotBeNull();
        exception.Should().BeOfType<KiwiLoadAuthPasswordEmptyException>();
        exceptionMessage.Should().Be(exception.Message);
    }

    [Fact]
    public void WhenNotNull_Should_NoException()
    {
        // Arrange
        var passwordValue = "password";

        // Act
        var exception = Record.Exception(() => new Password(passwordValue));

        // Assert
        exception.Should().BeNull();
    }

    [Fact]
    public void WhenTheSameEquals_Should_BeTrue()
    {
        // Arrange
        var password1 = new Password("password");
        var password2 = new Password("password");

        // Act
        var resultTyp = password1.Equals(password2);
        var resultObj = password1.Equals((object)password2);

        // Assert
        resultTyp.Should().BeTrue();
        resultObj.Should().BeTrue();
        password1.Value.Should().Be(password2.Value);
    }

    [Fact]
    public void WhenNotTheSameEquals_Should_BeFalse()
    {
        // Arrange
        var password1 = new Password("password1");
        var password2 = new Password("password2");

        // Act
        var resultTyp = password1.Equals(password2);
        var resultObj = password1.Equals((object)password2);

        // Assert
        resultTyp.Should().BeFalse();
        resultObj.Should().BeFalse();
    }

    [Fact]
    public void WhenOneNull_Should_BeFalse()
    {
        // Arrange
        var password1 = new Password("password");
        HashValue? password2 = null;
        object? password3 = null;
        // Act
        var resultTyp = password1.Equals(password2);
        var resultObj = password1.Equals(password3);

        // Assert
        resultTyp.Should().BeFalse();
        resultObj.Should().BeFalse();
    }

    [Fact]
    public void WhenCompare_Should_BeTrue()
    {
        // Arrange
        var password1 = new Password("password");
        var password2 = new Password("password");

        // Act
        var resultHash = password1.GetHashCode() == password2.GetHashCode();
        var resultEqual = password1 == password2;

        // Assert
        resultHash.Should().BeTrue();
        resultEqual.Should().BeTrue();
    }

    [Fact]
    public void WhenCompareDifferent_Should_BeDifferent()
    {
        // Arrange
        var password1 = new Password("password1");
        var password2 = new Password("password2");

        // Act
        var resultHash = password1.GetHashCode() != password2.GetHashCode();
        var resultEqual = password1 != password2;

        // Assert
        resultHash.Should().BeTrue();
        resultEqual.Should().BeTrue();
    }

    [Fact]
    public void WhenImplicitOperatorToString_Should_BeEqual()
    {
        // Arrange
        var initValue = "password";
        var hashValue = new Password(initValue);

        // Act
        var result = (string)hashValue;

        // Assert
        result.Should().Be(initValue);
    }
}
