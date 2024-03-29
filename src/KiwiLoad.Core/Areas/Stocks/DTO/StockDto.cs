﻿using KiwiLoad.Core.Areas.Stocks.ValueObjects;

namespace KiwiLoad.Core.Areas.Stocks.DTO;
public class StockDto
{
    public StockDto(StockId id, StockName name)
    {
        Id = id;
        Name=name;
    }
    public StockId Id { get; set; }
    public StockName Name { get; }
}
