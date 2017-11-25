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
    public class SampleDataService: ISampleDataService
    {
        private readonly CarnivalContext _context;

        public SampleDataService(CarnivalContext context)
        {
            _context = context;
        }

        public async Task<TestData> GetById(int id)
        {
            var test = await _context.TestData.DefaultIfEmpty(null as TestData)
                .SingleOrDefaultAsync(a => a.Id == id.ToString());;
            return test;
        }

        public DbSet<TestData> Get()
        {
            return _context.TestData;
        }

        public async Task<EntityEntry<TestData>> Save(TestData value)
        {
            try
            {
                Task<EntityEntry<TestData>> newTestData = _context.AddAsync(value);
                await _context.SaveChangesAsync();
                return await newTestData;

            }
            catch (DbUpdateException exception)
            {
                Debug.WriteLine("An exception occurred: {0}, {1}", exception.InnerException, exception.Message);
                return null;
            }
        }

        public async Task<bool> Update(TestData value)
        {
            bool recordExists = _context.TestData.Any(a => a.Id == value.Id);

            if (!recordExists)
            {
                return false;
            }

            try
            {
                _context.Update(value);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException exception)
            {
                Debug.WriteLine("An exception occurred: {0}, {1}", exception.InnerException, exception.Message);
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var testData = await _context.TestData
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id.ToString());

            if (testData == null)
            {
                return false;
            }

            try
            {
                _context.TestData.Remove(testData);
                await _context.SaveChangesAsync();
                return true;
                
            }
            catch (DbUpdateException exception)
            {
                Debug.WriteLine("An exception occurred: {0}, {1}", exception.InnerException, exception.Message);
                return false;
            }
        }
    }
}