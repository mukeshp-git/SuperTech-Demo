using Microsoft.EntityFrameworkCore;


namespace SupremTech.EntityFrameworkCore.Tests
{
    public static class DbContextHelper
    {
        public static AppDBContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            .Options;

            return new AppDBContext(options);
        }
    }
}