using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repositories.EfCore;

namespace StoreApi.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>

    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            //Configurationbuilder
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();


            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseMySQL(configuration.GetConnectionString("MysqlConnection")
                ,prj=>prj.MigrationsAssembly("StoreApi"));
            return new RepositoryContext(builder.Options);
        }
    }
}
