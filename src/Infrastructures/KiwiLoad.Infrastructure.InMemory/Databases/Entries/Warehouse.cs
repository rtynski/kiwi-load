using KiwiLoad.Infrastructure.Databases.Interfaces;

namespace KiwiLoad.Infrastructure.Databases.Entries;
internal class Warehouse : IDisableDate
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime AddDate { get; set; }
    public int AddUserId { get; set; }
    public DateTime UpdateDate { get; set; }
    public int UpdateUserId { get; set; }
    public DateTime? DisableDate { get; set; }
    public int? DisableUserId { get; set; }
}
