using GStation.Core.Models;

namespace GStation.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Manager> Create(Manager customer);
        Task<Manager> GetById(Guid id);
        Task<List<Manager>> GetAll();
        Task<Manager> Update(Manager customer);
        Task DeleteById(Guid id);
        Task<Team> CreateVehicle(Team vehicle);
        Task<List<Team>> GetAllVehicles(Guid customerId);
        Task<Manager> GetCustomerByUserId(string userId);
    }
}
