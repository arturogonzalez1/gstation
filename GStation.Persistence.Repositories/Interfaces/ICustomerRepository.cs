using GStation.Core.Models;

namespace GStation.Persistence.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> Create(Customer customer);
        Task<Customer> GetById(Guid id);
        Task<List<Customer>> GetAll();
        Task<Customer> Update(Customer customer);
        Task Delete(Guid id);
    }
}
