using KiwiLoad.Core.Areas.Warehouses.ValueObjects;

namespace KiwiLoad.Core.Areas.Warehouses.DTO;
public class WarehouseDto
{
    public WarehouseDto(WarehouseId id, WarehouseName name)
    {
        Id = id;
        Name = name;
    }
    public WarehouseId Id { get; }
    public WarehouseName Name { get; }
}
