using System;
using System.Diagnostics;
using System.Linq;
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
        private readonly CarnivalContext _context;

        public ProfileService(CarnivalContext context)
        {
            _context = context;
        }

        public async Task<UserProfile> GetOrCreateProfile(string id)
        {
            var newProfile = await _context.Profiles.FirstOrDefaultAsync(p=>p.Id == id);
            if (newProfile == null)
            {
                newProfile = new UserProfile(id);
                await _context.Profiles.AddAsync(newProfile);
                await _context.SaveChangesAsync();
            }
            return newProfile;
        }

        public async Task<EntityEntry<UserProfile>> UpdateProfileAsync(UserProfile profile)
        {
            try
            {
                EntityEntry<UserProfile> result = _context.Profiles.Update(profile);
                await _context.SaveChangesAsync();
                return result;
            }
            catch (DbUpdateException exception)
            {
                Debug.WriteLine("An exception occurred: {0}, {1}", exception.InnerException, exception.Message);
                return null;
            }
        }
    }
}