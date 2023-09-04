using SupremTech.Domain;

namespace SupremTech.Repositories.Contracts
{
    public interface ICustomerRepository
    {
        public Task<Customers> GetCustomer(int CustomerID);
        public Task<string> AddCustomer(Customers customer_entity);
        public Task<string> UpdateCustomer(Customers customer_entity);
        public Task<string> DeleteCustomer(Customers customer_entity);


    }
}
