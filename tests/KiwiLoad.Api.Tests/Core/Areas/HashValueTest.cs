using FluentAssertions;
using KiwiLoad.Core.Areas.Auth.ValueObjects;
using KiwiLoad.Core.Exceptions.Auth;

namespace KiwiLoad.Api.Tests.Core.Areas;
public class HashValueTest
{
    [Fact]
    public void HashValueWhenEmpty_Should_GetExceptions()
    {
        // Arrange
        var hashValue = string.Empty;
        var exceptionMessage = "Hash value cannot be null or empty";

        // Act
        var exception = Record.Exception(() => new HashValue(hashValue));

        // Assert
        exception.Should().NotBeNull();
        exception.Should().BeOfType<KiwiLoadAuthHashValueEmptyException>();
        exceptionMessage.Should().Be(exception.Message);
    }

    [Fact]
    public void HashValueWhenNull_Should_GetExceptions()
    {
        // Arrange
        string? hashValue = null;
        var exceptionMessage = "Hash value cannot be null or empty";

        // Act
        var exception = Record.Exception(() => new HashValue(hashValue));

        // Assert
        exception.Should().NotBeNull();
        exception.Should().BeOfType<KiwiLoadAuthHashValueEmptyException>();
        exceptionMessage.Should().Be(exception.Message);
    }

    [Fact]
    public void HashValueNotNull_Should_NoException()
    {
        // Arrange
        var hashValue = "hashValue";

        // Act
        var exception = Record.Exception(() => new HashValue(hashValue));

        // Assert
        exception.Should().BeNull();
    }
    [Fact]
    public void HashValueEquals_Should_BeTrue()
    {
        // Arrange
        var hashValue1 = new HashValue("hashValue");
        var hashValue2 = new HashValue("hashValue");

        // Act
        var result = hashValue1.Equals(hashValue2);

        // Assert
        result.Should().BeTrue();
        hashValue1.Value.Should().Be(hashValue2.Value);
    }
    [Fact]
    public void HashValueEquals_Should_BeFalse()
    {
        // Arrange
        var hashValue1 = new HashValue("hashValue1");
        var hashValue2 = new HashValue("hashValue2");

        // Act
        var result = hashValue1.Equals(hashValue2);

        // Assert
        result.Should().BeFalse();
        hashValue1.Value.Should().NotBe(hashValue2.Value);
    }
    
}
