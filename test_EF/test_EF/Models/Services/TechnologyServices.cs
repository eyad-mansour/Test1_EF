using System;
using test_EF.Models.Interfaces;
using test_EF.Data;
using Microsoft.EntityFrameworkCore;

namespace test_EF.Models.Services
{
    public class TechnologyServices : ITechnology
    {
        private SchoolDbContext _context;

        public TechnologyServices(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Technology> CreateTechnology(Technology technology)
        {
            _context.Entry(technology).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return technology;
        }

        public async Task DeleteTechnology(int TechnologyId)
        {
            Technology technology = await GetTechnology(TechnologyId);
            _context.Entry(technology).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Technology>> GetAllTechnologies()
        {
            var technologies = await _context.Technologies.ToListAsync();
            return technologies;
        }

        public async Task<Technology> GetTechnology(int TechnologyId)
        {
            Technology technology = await _context.Technologies.FindAsync(TechnologyId);
            return technology;
        }

        public async Task<Technology> UpdateTechnology(int TechnologyId, Technology technology)
        {
            _context.Entry(technology).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return technology;
        }
    }
}

