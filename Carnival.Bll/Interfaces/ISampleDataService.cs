using System.Threading.Tasks;
using Carnival.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Carnival.Bll.Interfaces
{
    public interface ISampleDataService
    {
        Task<TestData> GetById(int id);
        DbSet<TestData> Get();
        Task<EntityEntry<TestData>> Save(TestData value);
        Task<bool> Update(TestData value);
        Task<bool> Delete(int id);

    }
}
