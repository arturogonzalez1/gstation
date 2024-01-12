using GStation.Core.Models;

namespace GStation.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> Create(Customer customer);
        Task<Customer> GetById(Guid id);
        Task<List<Customer>> GetAll();
        Task<Customer> Update(Customer customer);
        Task DeleteById(Guid id);
        Task<Vehicle> CreateVehicle(Vehicle vehicle);
        Task<List<Vehicle>> GetAllVehicles(Guid customerId);
        Task<Customer> GetCustomerByUserId(string userId);
    }
}
