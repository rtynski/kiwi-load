using FluentAssertions;
using KiwiLoad.Core.Areas.Auth.ValueObjects;
using KiwiLoad.Core.Exceptions.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiwiLoad.Api.Tests.Core.Areas;
public class UsernameTest
{
    [Fact]
    public void UsernameWhenEmpty_Should_GetExceptions()
    {
        // Arrange
        var username = string.Empty;
        var exceptionMessage = "Username cannot be null or empty";

        // Act
        var exception = Record.Exception(() => new Username(username));

        // Assert
        exception.Should().NotBeNull();
        exception.Should().BeOfType<KiwiLoadAuthUsernameEmptyException>();
        exceptionMessage.Should().Be(exception.Message);
    }

    [Fact]
    public void UsernameWhenNull_Should_GetExceptions()
    {
        // Arrange
        string? username = null;
        var exceptionMessage = "Username cannot be null or empty";

        // Act
        var exception = Record.Exception(() => new Username(username));

        // Assert
        exception.Should().NotBeNull();
        exception.Should().BeOfType<KiwiLoadAuthUsernameEmptyException>();
        exceptionMessage.Should().Be(exception.Message);
    }

    [Fact]
    public void UsernameNotNull_Should_NoException()
    {
        // Arrange
        var username = "username";

        // Act
        var exception = Record.Exception(() => new Username(username));

        // Assert
        exception.Should().BeNull();
    }
    [Fact]
    public void UsernameEquals_Should_BeTrue()
    {
        // Arrange
        var username1 = new Username("username");
        var username2 = new Username("username");

        // Act
        var result = username1.Equals(username2);

        // Assert
        result.Should().BeTrue();
    }
}
