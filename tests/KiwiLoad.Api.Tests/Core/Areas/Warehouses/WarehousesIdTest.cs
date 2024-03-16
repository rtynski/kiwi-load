using FluentAssertions;
using KiwiLoad.Core.Areas.Warehouses.ValueObjects;
using KiwiLoad.Core.Exceptions.Auth;
using KiwiLoad.Core.Exceptions.Warehouses;

namespace KiwiLoad.Api.Tests.Core.Areas.Warehouses;
public class WarehousesIdTest
{
    [Fact]
    public void WhenEmpty_Should_GetExceptions()
    {
        // Arrange
        var warehouseIdValue = 0;
        var exceptionMessage = "Invalid warehouse id: 0.";

        // Act
        var exception = Record.Exception(() => new WarehouseId(warehouseIdValue));

        // Assert
        exception.Should().NotBeNull();
        exception.Should().BeOfType<KiwiLoadWarehousesInvalidIdException>();
        exceptionMessage.Should().Be(exception.Message);
    }

    [Fact]
    public void WhenNull_Should_GetExceptions()
    {
        // Arrange
        int? hashValue = null;
        var exceptionMessage = "Invalid warehouse id: null.";

        // Act
        var exception = Record.Exception(() => new WarehouseId(hashValue));

        // Assert
        exception.Should().NotBeNull();
        exception.Should().BeOfType<KiwiLoadWarehousesInvalidIdException>();
        exceptionMessage.Should().Be(exception.Message);
    }

    [Fact]
    public void WhenNotNull_Should_NoException()
    {
        // Arrange
        var warehouseIdValue = 1;

        // Act
        var exception = Record.Exception(() => new WarehouseId(warehouseIdValue));

        // Assert
        exception.Should().BeNull();
    }

    [Fact]
    public void WhenTheSameEquals_Should_BeTrue()
    {
        // Arrange
        var warehouseIdValue1 = new WarehouseId(1);
        var warehouseIdValue2 = new WarehouseId(1);

        // Act
        var resultTyp = warehouseIdValue1.Equals(warehouseIdValue2);
        var resultObj = warehouseIdValue1.Equals((object)warehouseIdValue2);

        // Assert
        resultTyp.Should().BeTrue();
        resultObj.Should().BeTrue();
        warehouseIdValue1.Value.Should().Be(warehouseIdValue2.Value);
    }

    [Fact]
    public void WhenNotTheSameEquals_Should_BeFalse()
    {
        // Arrange
        var warehouseIdValue1 = new WarehouseId(1);
        var warehouseIdValue2 = new WarehouseId(2);

        // Act
        var resultTyp = warehouseIdValue1.Equals(warehouseIdValue2);
        var resultObj = warehouseIdValue1.Equals((object)warehouseIdValue2);

        // Assert
        resultTyp.Should().BeFalse();
        resultObj.Should().BeFalse();
    }

    [Fact]
    public void WhenOneNull_Should_BeFalse()
    {
        // Arrange
        var warehouseIdValue1 = new WarehouseId(1);
        WarehouseId? warehouseIdValue2 = null;
        object? warehouseIdValue3 = null;
        // Act
        var resultTyp = warehouseIdValue1.Equals(warehouseIdValue2);
        var resultObj = warehouseIdValue1.Equals(warehouseIdValue3);

        // Assert
        resultTyp.Should().BeFalse();
        resultObj.Should().BeFalse();
    }

    [Fact]
    public void WhenCompare_Should_BeTrue()
    {
        // Arrange
        var warehouseIdValue1 = new WarehouseId(1);
        var warehouseIdValue2 = new WarehouseId(1);

        // Act
        var resultHash = warehouseIdValue1.GetHashCode() == warehouseIdValue2.GetHashCode();
        var resultEqual = warehouseIdValue1 == warehouseIdValue2;

        // Assert
        resultHash.Should().BeTrue();
        resultEqual.Should().BeTrue();
    }

    [Fact]
    public void WhenCompareDifferent_Should_BeDifferent()
    {
        // Arrange
        var warehouseIdValue1 = new WarehouseId(1);
        var warehouseIdValue2 = new WarehouseId(2);

        // Act
        var resultHash = warehouseIdValue1.GetHashCode() != warehouseIdValue2.GetHashCode();
        var resultEqual = warehouseIdValue1 != warehouseIdValue2;

        // Assert
        resultHash.Should().BeTrue();
        resultEqual.Should().BeTrue();
    }

    [Fact]
    public void WhenImplicitOperatorToString_Should_BeEqual()
    {
        // Arrange
        var initValue = 1;
        var warehouseIdValue1 = new WarehouseId(1);

        // Act
        var result = warehouseIdValue1.Value;

        // Assert
        result.Should().Be(initValue);
    }
}
