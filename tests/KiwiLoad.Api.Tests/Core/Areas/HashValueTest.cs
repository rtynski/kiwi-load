using FluentAssertions;
using KiwiLoad.Core.Areas.Auth.ValueObjects;
using KiwiLoad.Core.Exceptions.Auth;

namespace KiwiLoad.Api.Tests.Core.Areas;
public class HashValueTest
{
    [Fact]
    public void WhenEmpty_Should_GetExceptions()
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
    public void WhenNull_Should_GetExceptions()
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
    public void WhenNotNull_Should_NoException()
    {
        // Arrange
        var hashValue = "hashValue";

        // Act
        var exception = Record.Exception(() => new HashValue(hashValue));

        // Assert
        exception.Should().BeNull();
    }

    [Fact]
    public void WhenTheSameEquals_Should_BeTrue()
    {
        // Arrange
        var hashValue1 = new HashValue("hashValue");
        var hashValue2 = new HashValue("hashValue");

        // Act
        var resultTyp = hashValue1.Equals(hashValue2);
        var resultObj = hashValue1.Equals((object)hashValue2);

        // Assert
        resultTyp.Should().BeTrue();
        resultObj.Should().BeTrue();
        hashValue1.Value.Should().Be(hashValue2.Value);
    }

    [Fact]
    public void WhenNotTheSameEquals_Should_BeFalse()
    {
        // Arrange
        var hashValue1 = new HashValue("hashValue1");
        var hashValue2 = new HashValue("hashValue2");

        // Act
        var resultTyp = hashValue1.Equals(hashValue2);
        var resultObj = hashValue1.Equals((object)hashValue2);

        // Assert
        resultTyp.Should().BeFalse();
        resultObj.Should().BeFalse();
    }
    
    [Fact]
    public void WhenOneNull_Should_BeFalse()
    {
        // Arrange
        var hashValue1 = new HashValue("hashValue");
        HashValue? hashValue2 = null;
        object? hashValue3 = null;
        // Act
        var resultTyp = hashValue1.Equals(hashValue2);
        var resultObj = hashValue1.Equals(hashValue3);

        // Assert
        resultTyp.Should().BeFalse();
        resultObj.Should().BeFalse();
    }

    [Fact]
    public void WhenCompare_Should_BeTrue()
    {
        // Arrange
        var hashValue1 = new HashValue("hashValue");
        var hashValue2 = new HashValue("hashValue");

        // Act
        var resultHash = hashValue1.GetHashCode() == hashValue2.GetHashCode();
        var resultEqual = hashValue1 == hashValue2;

        // Assert
        resultHash.Should().BeTrue();
        resultEqual.Should().BeTrue();
    }

    [Fact]
    public void WhenCompareDifferent_Should_BeDifferent()
    {
        // Arrange
        var hashValue1 = new HashValue("hashValue1");
        var hashValue2 = new HashValue("hashValue2");

        // Act
        var resultHash = hashValue1.GetHashCode() != hashValue2.GetHashCode();
        var resultEqual = hashValue1 != hashValue2;

        // Assert
        resultHash.Should().BeTrue();
        resultEqual.Should().BeTrue();
    }

    [Fact]
    public void WhenImplicitOperatorToString_Should_BeEqual()
    {
        // Arrange
        var hashValue = new HashValue("hashValue");

        // Act
        var result = (string)hashValue;

        // Assert
        result.Should().Be(hashValue.Value);
    }
}
