using Microsoft.Extensions.Logging;
using Moq;
using SupremTech.Domain;
using SupremTech.EntityFrameworkCore.Tests;


namespace SupremTech.Repositories.Tests
{
    [TestFixture]
    public class CustomerRepositoryTests
    {
        [Test]
        public async Task GetCustomer_ReturnsCustomerIfExists()
        {
            // Mock dependencies 
            var dbContext = DbContextHelper.GetInMemoryDbContext();
            var loggerMock = new Mock<ILogger<CustomerRepository>>();
            var repository = new CustomerRepository(dbContext, loggerMock.Object);

            // Add a sample customer to the in-memory database for testing
            var sampleCustomer = new Customers { CustomerID = 1, FirstName = "John Doe"};
            dbContext.CustomersSet.Add(sampleCustomer);
            dbContext.SaveChanges();
            
            var result = await repository.GetCustomer(1);

            Assert.NotNull(result);
            Assert.AreEqual(result.FirstName, "John Doe");


        }

        [Test]
        public async Task GetCustomer_ReturnsNullForNonExistentCustomer()
        {
            // Mock dependencies 
            var dbContext = DbContextHelper.GetInMemoryDbContext();
            var loggerMock = new Mock<ILogger<CustomerRepository>>();
            var repository = new CustomerRepository(dbContext, loggerMock.Object);

            var result = await repository.GetCustomer(999);

            Assert.Null(result);
        }

        [Test]
        public async Task AddCustomer_AddsCustomerToDatabase()
        {
            // Mock dependencies 
            var dbContext = DbContextHelper.GetInMemoryDbContext();
            var loggerMock = new Mock<ILogger<CustomerRepository>>();
            var repository = new CustomerRepository(dbContext, loggerMock.Object);
            var newCustomer = new Customers { CustomerID = 1, FirstName = "Alice" };

            var result = await repository.AddCustomer(newCustomer);

            Assert.AreEqual(result,"success");
            var addedCustomer = await dbContext.CustomersSet.FindAsync(1);
            Assert.NotNull(addedCustomer);
            Assert.AreEqual(addedCustomer.FirstName, "Alice");
        }


    }
}