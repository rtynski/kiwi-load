using KiwiLoad.Infrastructure.Databases.Interfaces;

namespace KiwiLoad.Infrastructure.Databases.Entries;
public class User : IDisableDate
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime AddDate { get; set; }
    public int AddUserId { get; set; }
    public DateTime UpdateDate { get; set; }
    public int UpdateUserId { get; set; }
    public DateTime? DisableDate { get; set; }
    public int? DisableUserId { get; set; }
}
