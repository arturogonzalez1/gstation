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
    }
}
