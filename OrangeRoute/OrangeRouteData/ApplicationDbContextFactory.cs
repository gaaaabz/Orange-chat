using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OrangeRouteData;

namespace OrangeRouteData
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseOracle("User Id=559597;Password=311005;Data Source=oracle.fiap.com.br;");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
