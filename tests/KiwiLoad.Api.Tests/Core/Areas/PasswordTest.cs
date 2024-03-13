using FluentAssertions;
using KiwiLoad.Core.Areas.Auth.ValueObjects;
using KiwiLoad.Core.Exceptions.Auth;

namespace KiwiLoad.Api.Tests.Core.Areas;
public class PasswordTest
{
    [Fact]
    public void PasswordWhenEmpty_Should_GetExceptions()
    {
        // Arrange
        var password = string.Empty;
        var exceptionMessage = "Password cannot be null or empty";

        // Act
        var exception = Record.Exception(() => new Password(password));

        // Assert
        exception.Should().NotBeNull();
        exception.Should().BeOfType<KiwiLoadAuthPasswordEmptyException>();
        exceptionMessage.Should().Be(exception.Message);
    }

    [Fact]
    public void PasswordWhenNull_Should_GetExceptions()
    {
        // Arrange
        string? password = null;
        var exceptionMessage = "Password cannot be null or empty";

        // Act
        var exception = Record.Exception(() => new Password(password));

        // Assert
        exception.Should().NotBeNull();
        exception.Should().BeOfType<KiwiLoadAuthPasswordEmptyException>();
        exceptionMessage.Should().Be(exception.Message);
    }

    [Fact]
    public void PasswordNotNull_Should_NoException()
    {
        // Arrange
        var password = "password";

        // Act
        var exception = Record.Exception(() => new Password(password));

        // Assert
        exception.Should().BeNull();
    }
    [Fact]
    public void PasswordEquals_Should_BeTrue()
    {
        // Arrange
        var password1 = new Password("password");
        var password2 = new Password("password");

        // Act
        var result = password1.Equals(password2);

        // Assert
        result.Should().BeTrue();
    }
    [Fact]
    public void PasswordEquals_Should_BeFalse()
    {
        // Arrange
        var password1 = new Password("password1");
        var password2 = new Password("password2");

        // Act
        var result = password1.Equals(password2);

        // Assert
        result.Should().BeFalse();
    }
    [Fact]
    public void PasswordEquals_Should_BeFalseWhenNull()
    {
        // Arrange
        var password1 = new Password("password");
        Password? password2 = null;

        // Act
        var result = password1.Equals(password2);

        // Assert
        result.Should().BeFalse();
    }
    [Fact]
    public void PasswordEquals_Should_BeFalseWhenDifferentType()
    {
        // Arrange
        var password1 = new Password("password");
        var password2 = new object();

        // Act
        var result = password1.Equals(password2);

        result.Should().BeFalse();
    }
}
