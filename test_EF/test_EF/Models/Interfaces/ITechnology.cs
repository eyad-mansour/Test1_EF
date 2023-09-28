using System;
namespace test_EF.Models.Interfaces
{
    public interface ITechnology
    {
        Task<List<Technology>> GetAllTechnologies();

        Task<Technology> GetTechnology(int TechnologyId);

        Task DeleteTechnology(int TechnologyId);

        Task<Technology> UpdateTechnology(int TechnologyId, Technology technology);

        Task<Technology> CreateTechnology(Technology technology);
    }
}

