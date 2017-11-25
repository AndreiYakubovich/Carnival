using System.Collections.Generic;
using Carnival.Bll.Interfaces;
using Carnival.Data;

namespace BLL.Services
{
    public class MaintenanceService:IMaintenanceService
    {
        private readonly CarnivalContext _context;

        public MaintenanceService(CarnivalContext context)
        {
            _context = context;
        }

//        public IEnumerable<ProfileBLL> GetAllProfiles()
//        {
//            IEnumerable<ProfileBLL> AllProfiles =_context.Profile.Local.Select(p=>p.ToProfileBLL());
//            return AllProfiles;
//        }

        public bool EnsureDatabaseCreated()
        {
            return _context.Database.EnsureCreated();
        }
    }
}