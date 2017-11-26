using System.Threading.Tasks;
using Carnival.Data.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Carnival.Bll.Interfaces
{
    public interface IProfileService
    {
        Task<UserProfile> GetOrCreateProfile(string id);
    }
}
