using GStation.Core.Models;

namespace GStation.Persistence.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Manager> Create(Manager customer);
        Task<Manager> GetById(Guid id);
        Task<List<Manager>> GetAll();
        Task<Manager> Update(Manager customer);
        Task Delete(Guid id);
        Task<Team> CreateVehicle(Team vehicle);
        Task<List<Team>> GetAllVehicles(Guid customerId);
        Task<Manager> GetByPersonId(Guid personId);
    }
}
