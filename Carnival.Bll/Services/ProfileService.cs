using System.Threading.Tasks;
using Carnival.Bll.Interfaces;
using Carnival.Data;
using Carnival.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Carnival.Bll.Services
{
    public class ProfileService:IProfileService
    {
        private CarnivalContext _context;

        public ProfileService(CarnivalContext context)
        {
            _context = context;
        }

        public async Task<UserProfile> GetProfile(string id)
        {
            return await _context.Profiles.SingleOrDefaultAsync(m => m.Id == id);
        }
    }
}