using KiwiLoad.Core.Areas.Warehouses.ValueObjects;

namespace KiwiLoad.Core.Areas.Warehouses.DTO;
public class WarehouseDto(WarehouseId id)
{
    public WarehouseId Id { get; set; } = id;
}
