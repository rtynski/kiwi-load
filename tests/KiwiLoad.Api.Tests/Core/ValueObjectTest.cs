using FluentAssertions;
using KiwiLoad.Core.ValueObjects;

namespace KiwiLoad.Api.Tests.Core;
public class ValueObjectTest
{
    [Fact]
    public void WhenBothNull_Should_GetTrue()
    {
        // Arrange
        HashValue? hashValue1 = null;
        HashValue? hashValue2 = null;

        // Act
        var result = hashValue1 == hashValue2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void WhenFirsIsNull_Should_GetFalse()
    {
        // Arrange
        HashValue? hashValue1 = null;
        HashValue? hashValue2 = new HashValue("hashValue");

        // Act
        var result = hashValue1 == hashValue2;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void WhenSecondIsNull_Should_GetFalse()
    {
        // Arrange
        HashValue? hashValue1 = new HashValue("hashValue");
        HashValue? hashValue2 = null;

        // Act
        var result = hashValue1 == hashValue2;

        // Assert
        result.Should().BeFalse();
    }
}
