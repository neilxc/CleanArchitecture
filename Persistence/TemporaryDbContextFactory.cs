using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence
{
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<CleanContext>
    {
        public CleanContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CleanContext>();
            builder.UseSqlite("Data Source=clean.db", optionsBuilder =>
                optionsBuilder.MigrationsAssembly(typeof(CleanContext).GetTypeInfo().Assembly.GetName().Name));
            return new CleanContext(builder.Options);
        }
    }
}