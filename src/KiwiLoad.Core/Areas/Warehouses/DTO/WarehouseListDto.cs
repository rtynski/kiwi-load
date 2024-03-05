namespace KiwiLoad.Core.Areas.Warehouses.DTO;
public class WarehouseListDto(IEnumerable<WarehouseDto> items)
{
    public IEnumerable<WarehouseDto> Items { get; set; } = items;
}
