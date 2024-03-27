namespace KiwiLoad.Api.Controllers.Stocks.Models;

public class StockRes
{
    public StockRes(int id, string name)
    {
        Id=id;
        Name=name;
    }

    public int Id { get; }
    public  string Name { get; }
}
