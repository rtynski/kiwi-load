namespace KiwiLoad.Infrastructure.Databases.Interfaces;
public interface IDisableDate : IUpdateDate
{
    DateTime? DisableDate { get; set; }
    int? DisableUserId { get; set; }
}
