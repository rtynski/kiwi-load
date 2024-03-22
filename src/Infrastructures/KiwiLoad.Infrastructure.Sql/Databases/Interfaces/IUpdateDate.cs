namespace KiwiLoad.Infrastructure.Databases.Interfaces;
public interface IUpdateDate : IAddDate 
{
    DateTime UpdateDate { get; set; }
    int UpdateUserId { get; set; }
}
