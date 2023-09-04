using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SupremTech.Domain;
using SupremTech.EntityFrameworkCore;
using SupremTech.Repositories.Contracts;

namespace SupremTech.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDBContext _context;

        private readonly ILogger _logger;

        public CustomerRepository(AppDBContext context, ILogger<CustomerRepository> logger)
        {
            _context = context; // Inject the AppDBContext through the constructor
            _logger = logger; // Inject the logger through the constructor
        }

        public async Task<Customers> GetCustomer(int id)
        {
            return await _context.CustomersSet.FirstOrDefaultAsync(c => c.CustomerID == id);
        }

        public async Task<string> AddCustomer(Customers customer_entity)
        {
            if (customer_entity == null)
            {
                throw new ArgumentNullException(nameof(customer_entity));
            }
            try
            {
                await _context.CustomersSet.AddAsync(customer_entity);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Customer" + customer_entity.CustomerID + "added successfully");
                return "success";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error occurred while adding a customer.");
                throw;
            }

        }

        public async Task<string> UpdateCustomer(Customers customer_entity)
        {

            if (customer_entity == null)
            {
                throw new ArgumentNullException(nameof(customer_entity));
            }
            try
            {
                // Detach the existing entity from the context
                _context.ChangeTracker.Clear();
                _context.CustomersSet.Update(customer_entity);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Customer Update successfully for CustomerID:" + customer_entity.CustomerID);

                return "success";
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex.Message, "Error occurred while updaing a customer.");
                return "Concurrency conflict occurred.";
            }

        }

        public async Task<string> DeleteCustomer(Customers customer_entity)
        {
            if (customer_entity == null)
            {
                throw new ArgumentNullException(nameof(customer_entity));
            }

            try
            {
                _context.CustomersSet.Remove(customer_entity);
                await _context.SaveChangesAsync();
                return "success";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error occurred while deleting a customer.");
                throw;
            }
        }
    }
}

