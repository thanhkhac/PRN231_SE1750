using Microsoft.EntityFrameworkCore;

namespace Demo3.Db
{
    public static class DbServiceExtension 
    {
        public static void AddDatabaseService(this IServiceCollection services, string connectionString)
            => services.AddDbContext<CodeFirstDemoContext>(options => options.UseSqlServer(connectionString));
    }
}
