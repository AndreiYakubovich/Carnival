namespace Carnival.Bll.Interfaces
{
    public interface IMaintenanceService
    {
//        IEnumerable<ProfileBLL> GetAllProfiles();
        bool EnsureDatabaseCreated();
    }
}